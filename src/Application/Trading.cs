using System.Diagnostics.CodeAnalysis;

namespace Application;

[ExcludeFromCodeCoverage]
public class Trading
{
    public Dictionary<string, int> Shares { get; } = new();
    public TradingBook Book { get; }
    public TradingClock Clock { get; }

    public Trading(TradingClock? clock = null)
    {
        Book = new TradingBook();
        Clock = clock ?? new TradingClock();
    }

    public void Execute(TradingOrder order)
    {
        if (!Clock.IsBeforeCloseOfTrading(order)) return;
        
        switch (order.Type)
        {
            case TradingType.Buy: Buy(order); break;
            case TradingType.Sell: Sell(order); break;
            default: throw new ArgumentOutOfRangeException();
        }
        
        Book.Register(order);
    }

    public void Buy(TradingOrder order)
    {
        if (Shares.ContainsKey(order.Asset))
            Shares[order.Asset] += order.Quantity;
        else
            Shares[order.Asset] = order.Quantity;
    }

    public void Sell(TradingOrder order)
    {
        if (!Shares.ContainsKey(order.Asset)) return;
        Shares[order.Asset] -= order.Quantity;
    }
}
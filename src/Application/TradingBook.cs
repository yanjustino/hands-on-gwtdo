namespace Application;

public class TradingBook
{
    private List<TradingOrder> Orders { get; set; }

    public TradingBook()
    {
        Orders = new List<TradingOrder>();
    }

    public void Register(TradingOrder order)
        => Orders.Add(order);

    public IEnumerable<TradingOrder> GetOrderByType(TradingType type, string asset, int quantity)
        => Orders.Where(x => x.Type == type && x.Asset == asset && x.Quantity == quantity);
}
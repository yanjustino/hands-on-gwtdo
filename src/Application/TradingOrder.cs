namespace Application;

public record TradingOrder(TradingType Type, string Asset, int Quantity, DateTime OrderDate);
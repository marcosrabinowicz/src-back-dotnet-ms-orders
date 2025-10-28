namespace Orders.Domain.Entities;

public sealed record OrderItem(string Sku, int Quantity, decimal UnitPrice);

public sealed class Order
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public required string CustomerId { get; init; }
    public required List<OrderItem> Items { get; init; } = [];
    public decimal Total => Items.Sum(i => i.Quantity * i.UnitPrice);
}

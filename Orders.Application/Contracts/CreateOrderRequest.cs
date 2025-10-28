using Orders.Domain.Entities;

namespace Orders.Application.Contracts;

public sealed record CreateOrderRequest(string CustomerId, List<OrderItem> Items);
public sealed record OrderCreatedEvent(Guid OrderId, string CustomerId, decimal Total, DateTime CreatedAt);

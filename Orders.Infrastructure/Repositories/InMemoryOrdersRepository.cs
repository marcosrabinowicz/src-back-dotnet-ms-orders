using Orders.Application.Abstractions;
using Orders.Domain.Entities;

namespace Orders.Infrastructure.Repositories;

public sealed class InMemoryOrdersRepository : IOrdersRepository
{
    private readonly Dictionary<Guid, Order> _db = new();

    public Task<Order?> GetAsync(Guid id) => Task.FromResult(_db.TryGetValue(id, out var o) ? o : null);
    public Task<List<Order>> GetAllAsync() => Task.FromResult(_db.Values.ToList());
    public Task CreateAsync(Order order) { _db[order.Id] = order; return Task.CompletedTask; }
    public Task<bool> DeleteAsync(Guid id) => Task.FromResult(_db.Remove(id));
}

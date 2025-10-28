using Orders.Domain.Entities;

namespace Orders.Application.Abstractions;

public interface IOrdersRepository
{
    Task<Order?> GetAsync(Guid id);
    Task<List<Order>> GetAllAsync();
    Task CreateAsync(Order order);
    Task<bool> DeleteAsync(Guid id);
}

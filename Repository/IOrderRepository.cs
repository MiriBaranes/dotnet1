namespace dotnet1.Repository;

using dotnet1.Dto;
using dotnet1.Entity;

public interface IOrderRepository
{
    Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId);
    Task<Order?> GetByIdAsync(int id);
    Task AddAsync(Order order);
}

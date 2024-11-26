namespace dotnet1.Service;
using dotnet1.Dto;
using dotnet1.Entity;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId);
    Task<Order?> GetOrderByIdAsync(int orderId);
    Task<Order> CreateOrderAsync(int customerId, Order order);
}

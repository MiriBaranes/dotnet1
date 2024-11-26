namespace dotnet1.Service;
using dotnet1.Data;
using dotnet1.Dto;
using dotnet1.Entity;
using dotnet1.Repository;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId)
    {
        return await _repository.GetOrdersByCustomerIdAsync(customerId);
    }

    public async Task<Order?> GetOrderByIdAsync(int orderId)
    {
        return await _repository.GetByIdAsync(orderId);
    }

    public async Task<Order> CreateOrderAsync(int customerId, Order order)
{
    order.CustomerId = customerId;


    // חישוב TotalAmount מתוך SubTotal של פרטי ההזמנה
    order.TotalAmount = order.OrderDetails.Sum(od => od.SubTotal);

    await _repository.AddAsync(order);
    return order;
}
   
}

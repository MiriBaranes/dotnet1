namespace dotnet1.Repository;

using AutoMapper;
using dotnet1.Data;
using dotnet1.Dto;
using dotnet1.Entity;
using Microsoft.EntityFrameworkCore;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public OrderRepository(AppDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper= mapper;
    }
    public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId)
    {
        var orders = await _context.Orders
            .Where(o => o.CustomerId == customerId)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .ToListAsync();
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }


    public async Task<Order?> GetByIdAsync(int orderId)
    {
        return await _context.Orders
            .Include(o => o.OrderDetails)
            .FirstOrDefaultAsync(o => o.OrderId == orderId); 
    }


    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
    {
        throw new NotImplementedException();
    }
}

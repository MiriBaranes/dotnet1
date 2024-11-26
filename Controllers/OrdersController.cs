using Microsoft.AspNetCore.Mvc;
using dotnet1.Service;
using Microsoft.AspNetCore.Authorization;
using dotnet1.Entity;
using dotnet1.Dto;

[ApiController]
[Route("api/[controller]")]
[Authorize] // דורש משתמשים מאומתים
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly ICustomerService _customerService;

    public OrdersController(IOrderService orderService,ICustomerService customerService)
    {
        _orderService = orderService;
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserOrders()
    {
        // נשלוף את מזהה המשתמש מהטוקן
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Unauthorized(new { Message = "User is not authorized" });
        
        int customerId= (int) await _customerService.GetCustomerIdByUserIdAsync(userId);
        var orders = await _orderService.GetOrdersByCustomerIdAsync(customerId);
        return Ok(orders);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Unauthorized(new { Message = "User is not authorized" });

        // שליפת CustomerId לפי UserId
        int customerId = (int)await _customerService.GetCustomerIdByUserIdAsync(userId);

        // יצירת אובייקט Order
        var order = new Order
        {
            CustomerId = customerId,
            OrderDate = request.OrderDate,
            OrderDetails = request.OrderDetails.Select(od => new OrderDetail
            {
                ProductId = od.ProductId,
                Quantity = od.Quantity,
                SubTotal = od.SubTotal // שימוש ב-SubTotal מהבקשה
            }).ToList()
        };

        // הוספת ההזמנה
        var createdOrder = await _orderService.CreateOrderAsync(customerId, order);

        return Ok(new { Message = "Order created successfully", OrderId = createdOrder.OrderId });
    }
}

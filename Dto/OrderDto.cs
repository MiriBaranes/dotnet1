namespace dotnet1.Dto;
public class OrderDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderDetailDto> OrderDetails { get; set; }=[];
}
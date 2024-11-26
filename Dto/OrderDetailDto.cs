namespace dotnet1.Dto;
public class OrderDetailDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal SubTotal { get; set; }
}

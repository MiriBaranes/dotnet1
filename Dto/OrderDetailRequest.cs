namespace dotnet1.Dto;
public class OrderDetailRequest
    {
        public int ProductId { get; set; } 
        public int Quantity { get; set; } 
        public decimal SubTotal { get; set; } 
    }
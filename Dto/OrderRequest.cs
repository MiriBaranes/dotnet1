namespace dotnet1.Dto;
public class OrderRequest
    {
        public DateTime OrderDate { get; set; } 
        public decimal TotalAmount { get; set; } 
        public List<OrderDetailRequest> OrderDetails { get; set; } = new List<OrderDetailRequest>(); // רשימת פרטי ההזמנה
    }
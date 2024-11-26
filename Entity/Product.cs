namespace dotnet1.Entity{
    public class Product
{
    
    public int ProductId { get; set; }
    public required string Name { get; set; }
    public int CategoryId { get; set; }
    public Category ?Category { get; set; }
    public decimal Price { get; set; }
}

}
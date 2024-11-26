namespace dotnet1.Entity{
    public class Category
{
    
    public int CategoryId { get; set; }
    public required string Name { get; set; }
    public ICollection<Product> Products { get; set; } = [];
}

}
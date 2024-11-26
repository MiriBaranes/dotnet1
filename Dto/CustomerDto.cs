using System.ComponentModel.DataAnnotations;
using dotnet1.Entity;

namespace dotnet1.Dto{
    public class CustomerDto
{
    public int CustomerId { get; set; }
    [Required(ErrorMessage = "First Name is required")]
    public string ?FirstName { get; set; }
    [Required(ErrorMessage = "Last Name is required")]
    public string ?LastName { get; set; }
    [Required(ErrorMessage = "Email is required")]
    public string ?Email { get; set; }
    [Required(ErrorMessage = "Adress is required")]
    public string ?Address { get; set; }
    [Required(ErrorMessage = "Phone is required")]
    public string ?Phone { get; set; }
    public ICollection<Order> ?Orders { get; set; }
}

}


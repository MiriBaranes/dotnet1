using System.ComponentModel.DataAnnotations;

namespace dotnet1.Dto{
public class LoginRequest
{
    [Required(ErrorMessage = "Email is required")]
      [EmailAddress]
    public required string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; set; }
}
}
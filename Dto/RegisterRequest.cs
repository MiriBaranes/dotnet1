using System.ComponentModel.DataAnnotations;

namespace dotnet1.Dto{
    public class RegisterRequest
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [MinLength(6)]
    public required string Password { get; set; }

    [Required]
    [MinLength(2)]
    public required string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    public required string LastName { get; set; }

    [Required]
    [MaxLength(200)]
    public required string Address { get; set; }
    [Required]  
    [Phone]
    public required string Phone { get; set; }
}

}
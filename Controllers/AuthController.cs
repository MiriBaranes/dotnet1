using dotnet1.Dto;
using dotnet1.Entity;
using dotnet1.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly ICustomerService _IcustomerService;
    private readonly IJwtService _jwtService;

    public AuthController(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        IConfiguration configuration,
        ICustomerService IcustomerService,
        IJwtService IjwtService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _IcustomerService= IcustomerService;
        _jwtService= IjwtService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { Message = "Invalid data provided", Errors = ModelState.Values.SelectMany(v => v.Errors) });

        var user = new IdentityUser
        {
            UserName = request.Email,
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return BadRequest(new { Message = "User registration failed", Errors = result.Errors });

        var customer = new Customer
        {
            UserId = user.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email= request.Email,
            Address = request.Address,
            Phone = request.Phone
        };

        await _IcustomerService.AddCustomerAsync(customer);
        var token = _jwtService.GenerateJwtToken(user);
        return Ok(new
        {
            Message = "User registered successfully",
            UserId = user.Id,
            Token = token
        });
    }




    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { Message = "Invalid data provided", Errors = ModelState.Values.SelectMany(v => v.Errors) });

        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null || string.IsNullOrEmpty(user.UserName))
            return Unauthorized("Invalid credentials");

        var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);

        if (!result.Succeeded)
            return Unauthorized("Invalid credentials");

        var token = _jwtService.GenerateJwtToken(user);

        return Ok(new { Token = token });
    }




}


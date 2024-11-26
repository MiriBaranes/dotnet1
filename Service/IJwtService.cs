using Microsoft.AspNetCore.Identity;

namespace dotnet1.Service;
public interface IJwtService
{
    string GenerateJwtToken(IdentityUser user);
}
using Microsoft.Extensions.Configuration;

namespace FAATPRO.Infrastructure.Services;

public class JwtService
{
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Guid userId, string email, string role)
    {
        return "JWT_TOKEN_GENERATED";
    }
}
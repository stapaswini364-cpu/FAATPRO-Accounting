using FAATPRO.Domain.Entities;

namespace FAATPRO.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user, IList<string> roles);
}
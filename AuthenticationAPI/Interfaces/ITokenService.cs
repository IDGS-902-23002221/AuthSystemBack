using AuthenticationAPI.Models;

namespace AuthenticationAPI.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(ApplicationUser user);

        string GenerateRefreshToken();
    }
}

using AuthenticationAPI.DTO;

namespace AuthenticationAPI.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> RegisterAsync(RegisterRequestDTO dto);
        Task<AuthResponseDTO> LoginAsync(LoginRequestDTO dto);

        Task LogOutAsync(string userId);

    }
}

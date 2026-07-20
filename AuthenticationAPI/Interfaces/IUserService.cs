using AuthenticationAPI.DTO;

namespace AuthenticationAPI.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(string id);
        Task<bool>DeleteAsync(string id);
        Task<bool>AssingRoleAsync(string id, string role);
    }
}

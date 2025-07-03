using AplicatieInterviu.DTOs;
using AplicatieInterviu.Models;

namespace AplicatieInterviu.Service.Interface
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task AddAsync(UserDto user, string password);
        Task UpdateAsync(UserDto user, string password);
        Task DeleteAsync(int id);

        Task<User?> LoginAsync(LoginDto dto);
        Task RegisterUserWithCompanyAsync(UserDto userDto, CompanieDto companieDto, string password);
        Task<List<UserDto>> GetUsersByCompanyIdAsync(int companyId);
    }
}

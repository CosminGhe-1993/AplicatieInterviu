using AplicatieInterviu.DTOs;
using AplicatieInterviu.Models;

namespace AplicatieInterviu.Service.Interface
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAllAsync();
        Task<RoleDto?> GetByIdAsync(int id);
        Task AddAsync(RoleDto role);
        Task UpdateAsync(RoleDto role);
        Task DeleteAsync(int id);
    }
}

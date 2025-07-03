using AplicatieInterviu.DTOs;
using AplicatieInterviu.Mappings;
using AplicatieInterviu.Models;
using AplicatieInterviu.Repo.Interface;
using AplicatieInterviu.Service.Interface;

namespace AplicatieInterviu.Service.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<RoleDto>> GetAllAsync()
        {
            var roluri = await _roleRepository.GetAllAsync();
            return roluri.Select(r => RoleMapper.MapToDto(r)).ToList();
        }

        public async Task<RoleDto?> GetByIdAsync(int id)
        {
            var rol = await _roleRepository.GetByIdAsync(id);
            return RoleMapper.MapToDto(rol);
        }

        public async Task AddAsync(RoleDto role)
        {
            var roleToAdd = RoleMapper.MapToCreate(role);
            await _roleRepository.AddAsync(roleToAdd);
        } 

        public async Task UpdateAsync(RoleDto role)
        {
            var roleToUpdate = RoleMapper.MapToModel(role);
            await _roleRepository.UpdateAsync(roleToUpdate);
        }

        public async Task DeleteAsync(int id) => await _roleRepository.DeleteAsync(id);
    }
}

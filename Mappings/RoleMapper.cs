using AplicatieInterviu.DTOs;
using AplicatieInterviu.Models;

namespace AplicatieInterviu.Mappings
{
    public static class RoleMapper
    {
        public static Role MapToCreate(RoleDto dto)
        {
            return new Role
            {
                Name = dto.Name
            };
        }

        public static Role MapToModel(RoleDto dto)
        {
            return new Role
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static RoleDto MapToDto(Role model)
        {
            return new RoleDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }

}

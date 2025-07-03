using AplicatieInterviu.DTOs;
using AplicatieInterviu.Models;

namespace AplicatieInterviu.Mappings
{
    public static class UserMapper
    {
        public static User MapToCreate(UserDto userDto, LoginDto loginDto)
        {
            return new User
            {
                Nume = userDto.Nume,
                Prenume = userDto.Prenume,
                Email = userDto.Email,
                Phone = userDto.Phone,
                RoleId = userDto.RoleId,
                CompanyId = userDto.CompanyId,
                Password = loginDto.Password
            };
        }

        public static User MapToModel(UserDto userDto, LoginDto loginDto)
        {
            return new User
            {
                Id = userDto.Id,
                Nume = userDto.Nume,
                Prenume = userDto.Prenume,
                Email = userDto.Email,
                Phone = userDto.Phone,
                RoleId = userDto.RoleId,
                CompanyId = userDto.CompanyId,
                Password = loginDto.Password
            };
        }

        public static UserDto MapToDto(User model)
        {
            return new UserDto
            {
                Id = model.Id,
                Nume = model.Nume,
                Prenume = model.Prenume,
                Email = model.Email,
                Phone = model.Phone,
                RoleId = model.RoleId,
                CompanyId = model.CompanyId
            };
        }
    }

}

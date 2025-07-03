using AplicatieInterviu.DTOs;
using AplicatieInterviu.Mappings;
using AplicatieInterviu.Models;
using AplicatieInterviu.Repo.Interface;
using AplicatieInterviu.Service.Interface;

namespace AplicatieInterviu.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanieService _companieService;
        public UserService(IUserRepository userRepository, ICompanieService companieService)
        {
            _userRepository = userRepository;
            _companieService = companieService;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(s => UserMapper.MapToDto(s)).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return UserMapper.MapToDto(user);
        }

        public async Task AddAsync(UserDto userDto, string password)
        {
            LoginDto loginDto = new LoginDto();
            loginDto.Password = password;
            var userToAdd = UserMapper.MapToCreate(userDto, loginDto);
            await _userRepository.AddAsync(userToAdd);
        }

        public async Task UpdateAsync(UserDto user, string password)
        {
            LoginDto loginDto = new LoginDto();
            loginDto.Password = password;
            var userToUpdate = UserMapper.MapToModel(user, loginDto);
            await _userRepository.UpdateAsync(userToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<User?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByCompanyNameAndEmailAsync(dto.Company, dto.Email);

            if (user == null)
                return null;

            if (user.Password != dto.Password)
                return null;

            return user;
        }

        public async Task RegisterUserWithCompanyAsync(UserDto userDto, CompanieDto companieDto, string password)
        {
            var nouaCompanie = await _companieService.AddAsync(companieDto);
            userDto.CompanyId = nouaCompanie.Id;
            await AddAsync(userDto, password);
        }
        public async Task<List<UserDto>> GetUsersByCompanyIdAsync(int companyId)
        {
            var users = await _userRepository.GetUsersByCompanyIdAsync(companyId);
            return users.Select(user => UserMapper.MapToDto(user)).ToList();
        }
    }
}

using AplicatieInterviu.Models;

namespace AplicatieInterviu.Repo.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);

        Task<User?> GetByCompanyNameAndEmailAsync(string companyName, string email);
        Task<List<User>> GetUsersByCompanyIdAsync(int companyId);

    }
}

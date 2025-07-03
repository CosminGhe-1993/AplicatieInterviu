using AplicatieInterviu.Models;

namespace AplicatieInterviu.Repo.Interface
{
    public interface ICompanieRepository
    {
        Task<List<Companie>> GetAllAsync();
        Task<Companie?> GetByIdAsync(int id);
        Task <Companie> AddAsync(Companie companie);
        Task UpdateAsync(Companie companie);
        Task DeleteAsync(int id);
        Task <Companie> GetByNameAsync(string name);
    }
}

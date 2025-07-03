using AplicatieInterviu.DTOs;
using AplicatieInterviu.Models;

namespace AplicatieInterviu.Service.Interface
{
    public interface ICompanieService
    {
        Task<List<CompanieDto>> GetAllAsync();
        Task<CompanieDto?> GetByIdAsync(int id);
        Task<CompanieDto> AddAsync(CompanieDto companie);
        Task UpdateAsync(CompanieDto companie);
        Task DeleteAsync(int id);
        Task <CompanieDto?> GetByNameAsync(string name);
    }
}

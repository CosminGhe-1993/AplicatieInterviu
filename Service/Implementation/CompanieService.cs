using AplicatieInterviu.DTOs;
using AplicatieInterviu.Mappings;
using AplicatieInterviu.Models;
using AplicatieInterviu.Repo.Interface;
using AplicatieInterviu.Service.Interface;

namespace AplicatieInterviu.Service.Implementation
{
    public class CompanieService : ICompanieService
    {
        private readonly ICompanieRepository _companieRepository;

        public CompanieService(ICompanieRepository companieRepository)
        {
            _companieRepository = companieRepository;
        }

        public async Task<List<CompanieDto>> GetAllAsync()
        {
            var companii = await _companieRepository.GetAllAsync();
            return companii.Select(c=>CompanieMapper.MapToDto(c)).ToList();
        }

        public async Task<CompanieDto?> GetByIdAsync(int id)
        {
            var companie = await _companieRepository.GetByIdAsync(id);
            if (companie == null)
            {
                return null;
            }
            return CompanieMapper.MapToDto(companie);
        } 

        public async Task<CompanieDto> AddAsync(CompanieDto companie)
        {
            var companieToCreate = CompanieMapper.MapToCreate(companie);
            return CompanieMapper.MapToDto(await _companieRepository.AddAsync(companieToCreate));
        }

        public async Task UpdateAsync(CompanieDto companie)
        {
            var companieToUpdate = CompanieMapper.MapToModel(companie);
            await _companieRepository.UpdateAsync(companieToUpdate);
        } 

        public async Task DeleteAsync(int id) => await _companieRepository.DeleteAsync(id);

        public async Task<CompanieDto?> GetByNameAsync(string name)
        {
            var companie = await _companieRepository.GetByNameAsync(name);
            return CompanieMapper.MapToDto(companie);
        }
    }
}

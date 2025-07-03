using AplicatieInterviu.DTOs;
using AplicatieInterviu.Models;

namespace AplicatieInterviu.Mappings
{
    public static class CompanieMapper
    {
        public static Companie MapToCreate(CompanieDto dto)
        {
            return new Companie
            {
                Name = dto.Name,
                Location = dto.Location
            };
        }

        public static Companie MapToModel(CompanieDto dto)
        {
            return new Companie
            {
                Id = dto.Id,
                Name = dto.Name,
                Location = dto.Location
            };
        }

        public static CompanieDto MapToDto(Companie model)
        {
            return new CompanieDto
            {
                Id = model.Id,
                Name = model.Name,
                Location = model.Location   
            };
        }
    }

}

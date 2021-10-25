using Entities;
using Entities.DTOs;
using Entities.RepositoryInterfaces;
using Infrastructure.Repository;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ISpecialsService
    {
        public Task<object> GetAllSpecials();
        public Task<object> GetSpecial(int id);
        public Task Create(CreateSpecial model);
        public Task Edit(int id, EditSpecial model);
        public Task Delete(int id);
    }
    public class SpecialsService : ISpecialsService
    {
        private readonly ISpecialRepository _specialRepository;

        public SpecialsService(ISpecialRepository specialRepository)
        {
            _specialRepository = specialRepository;
        }

        public async Task<object> GetAllSpecials()
        {
            return await _specialRepository.GetAllSpecials();
        }

        public async Task<object> GetSpecial(int id)
        {
            var Special = await _specialRepository.GetSpecial(id);
            return (Special);
        }
        public async Task Create(CreateSpecial model)
        {
            await _specialRepository.AddSpecial(new Special { Name = model.Name, Price = model.Price });

        }
        public async Task Edit(int id, EditSpecial model)
        {
            var Special = await _specialRepository.GetSpecial(id);
            await _specialRepository.EditSpecial(Special, model.Name, model.Price);

        }
        public async Task Delete(int id)
        {
            var Extra = await _specialRepository.GetSpecial(id);
            await _specialRepository.Delete(Extra);
        }

    }
}

using Entities.DTOs;
using Entities.RepositoryInterfaces;
using Infrastructure.Repository;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IExtraFeaturesService
    {
        public Task<object> GetAllFeatures();
        public Task<object> GetFeature(int id);
        public Task Create(CreateFeature model);
        public Task Edit(int id, string name);
        public Task Delete(int id);
    }

    public class ExtraFeaturesService : IExtraFeaturesService
    {
        private readonly IPossibleExtrasRepository _possibleExtrasRepository;

        public ExtraFeaturesService(IPossibleExtrasRepository possibleExtrasRepository)
        {
            _possibleExtrasRepository = possibleExtrasRepository;
        }

        public async Task<object> GetAllFeatures()
        {
            return await _possibleExtrasRepository.GetAllPossibleExtras();
        }

        public async Task<object> GetFeature(int id)
        {
            var Extra = await _possibleExtrasRepository.GetAndShowPossibleExtra(id);
            return (Extra);
        }

        public async Task Create(CreateFeature model)
        {
            await _possibleExtrasRepository.AddPossibleExtra(model.Name);

        }

        public async Task Edit(int id, string name)
        {
            var Extra = await _possibleExtrasRepository.GetPossibleExtra(id);
            await _possibleExtrasRepository.EditPossibleExtras(Extra, name);

        }

        public async Task Delete(int id)
        {
            var Extra = await _possibleExtrasRepository.GetPossibleExtra(id);
            await _possibleExtrasRepository.Delete(Extra);
        }

    }
}

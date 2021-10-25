using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entities.RepositoryInterfaces
{
    public interface ISpecialRepository
    {
        public Task<List<Special>> GetAllSpecials();
        public Task<Special> GetSpecial(int id);
        public Task AddSpecial(Special Special);
        public Task EditSpecial(Special Special, string name, string price);
        public Task Delete(Special Special);
    }
}

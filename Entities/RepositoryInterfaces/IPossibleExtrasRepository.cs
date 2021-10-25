using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Entities.RepositoryInterfaces
{
    public interface IPossibleExtrasRepository
    {
        public Task<List<GetPossibleExtra>> GetAllPossibleExtras();
        public Task<GetPossibleExtra> GetAndShowPossibleExtra(int id);
        public Task<PossibleExtras> GetPossibleExtra(int id);
        public Task AddPossibleExtra(String Path);
        public Task EditPossibleExtras(PossibleExtras possibleExtra, string name);
        public Task Delete(PossibleExtras possibleExtra);
    }
}

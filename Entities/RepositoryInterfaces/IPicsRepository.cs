using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entities.RepositoryInterfaces
{
    public interface IPicsRepository
    {
        public Task<List<Pic>> GetAllPics();
        public Task<Pic> GetPicture(int id);
        public Task AddPicPath(String Path);
        public Task EditPicPath(Pic picture, String Path);
        public Task Delete(Pic pic);
    }
}

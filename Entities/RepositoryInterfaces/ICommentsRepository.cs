using System.Threading.Tasks;
using System.Collections.Generic;
using Entities.DTOs;

namespace Entities.RepositoryInterfaces
{
    public interface ICommentsRepository
    {
        public Task Add(CreateComment Comment);
    }
}

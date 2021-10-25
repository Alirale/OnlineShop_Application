using Entities.DTOs;
using Entities.RepositoryInterfaces;
using Infrastructure.Repository;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICommentsService
    {
        public Task Add(CreateComment Comment);
    }
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }
        public async Task Add(CreateComment Comment)
        {
            await _commentsRepository.Add(Comment);
        }
    }
}

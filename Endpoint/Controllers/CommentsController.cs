using Application.Services;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly ICommentsService _commentsService;
        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        /// <summary>
        /// افزودن کامنت برای محصول با آیدی
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> Post(CreateComment Comment)
        {
            if (Comment != null)
            {
                await _commentsService.Add(Comment);
            }

            return Ok();
        }
    }
}

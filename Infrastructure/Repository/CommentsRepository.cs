using Entities;
using Entities.DTOs;
using Entities.RepositoryInterfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Infrastructure.Repository
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly DatabaseContext _context;
        public CommentsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(CreateComment Comment)
        {
            var Product = await _context.Products.Include(p => p.Extras).ThenInclude(p => p.ExtraValues).Include(p => p.Specials)
                .FirstOrDefaultAsync(p => p.Id == Comment.ProductId);
            await _context.Comments.AddAsync(new Comment { Name = Comment.Name, CommentText = Comment.CommentText, Product = Product, ProductId = Product.Id });
            await _context.SaveChangesAsync();
        }
    }
}

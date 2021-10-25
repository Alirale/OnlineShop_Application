using Entities;
using Entities.RepositoryInterfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{

    public class PicsRepository : IPicsRepository
    {
        private readonly DatabaseContext _context;
        public PicsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Pic>> GetAllPics()
        {
            return (await _context.Pics.ToListAsync());
        }

        public async Task<Pic> GetPicture(int id)
        {
            var Picture = await _context.Pics.FirstOrDefaultAsync(m => m.Id == id);
            return (Picture);
        }

        public async Task AddPicPath(String Path)
        {
            _context.Pics.Add(new Pic { ImagePath = Path });
            await _context.SaveChangesAsync();
        }

        public async Task EditPicPath(Pic picture, String Path)
        {
            picture.ImagePath = Path;
            _context.Update(picture);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Pic pic)
        {
            _context.Pics.Remove(pic);
            await _context.SaveChangesAsync();
        }

    }
}

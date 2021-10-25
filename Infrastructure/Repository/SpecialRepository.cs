using Entities;
using Entities.RepositoryInterfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{

    public class SpecialRepository : ISpecialRepository
    {
        private readonly DatabaseContext _context;
        public SpecialRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Special>> GetAllSpecials()
        {
            return (await _context.Specials.ToListAsync());
        }

        public async Task<Special> GetSpecial(int id)
        {
            var Special = await _context.Specials.FirstOrDefaultAsync(m => m.Id == id);
            return (Special);
        }
        public async Task AddSpecial(Special Special)
        {
            await _context.Specials.AddAsync(new Special { Name = Special.Name, Price = Special.Price });
            await _context.SaveChangesAsync();
        }
        public async Task EditSpecial(Special Special, string name, string price)
        {
            Special.Price = Convert.ToDouble(price);
            Special.Name = name;
            _context.Update(Special);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Special Special)
        {
            _context.Specials.Remove(Special);
            await _context.SaveChangesAsync();
        }

    }
}

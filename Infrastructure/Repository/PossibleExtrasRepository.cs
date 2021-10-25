using Entities;
using Entities.DTOs;
using Entities.RepositoryInterfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{

    public class PossibleExtrasRepository : IPossibleExtrasRepository
    {
        private readonly DatabaseContext _context;
        public PossibleExtrasRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<GetPossibleExtra>> GetAllPossibleExtras()
        {
            var Extras = await _context.PossibleExtras.ToListAsync();
            List<GetPossibleExtra> PossibleExtras = new List<GetPossibleExtra>();
            foreach (var item in Extras)
            {
                PossibleExtras.Add(new GetPossibleExtra() { Id = item.Id, Name = item.Name });
            }

            return PossibleExtras;
        }

        public async Task<GetPossibleExtra> GetAndShowPossibleExtra(int id)
        {
            var Extra = await _context.PossibleExtras.FirstOrDefaultAsync(m => m.Id == id);
            return (new GetPossibleExtra() { Id = Extra.Id, Name = Extra.Name });
        }

        public async Task AddPossibleExtra(string name)
        {
            await _context.PossibleExtras.AddAsync(new PossibleExtras { Name = name });
            await _context.SaveChangesAsync();
        }

        public async Task EditPossibleExtras(PossibleExtras possibleExtra, string name)
        {
            possibleExtra.Name = name;
            _context.Update(possibleExtra);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(PossibleExtras possibleExtra)
        {
            _context.PossibleExtras.Remove(possibleExtra);
            await _context.SaveChangesAsync();
        }

        public async Task<PossibleExtras> GetPossibleExtra(int id)
        {
            var Extra = await _context.PossibleExtras.FirstOrDefaultAsync(m => m.Id == id);
            return (Extra);
        }
    }
}

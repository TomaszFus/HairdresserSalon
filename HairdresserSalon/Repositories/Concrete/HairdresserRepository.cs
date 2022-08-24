using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using HairdresserSalon.Data;
using Microsoft.EntityFrameworkCore;

namespace HairdresserSalon.Repositories.Concrete
{
    public class HairdresserRepository : IHairdresserRepository
    {
        private readonly HairdresserDbContext _context;
        public HairdresserRepository(HairdresserDbContext context)
        {
            _context = context;
        }

        public async Task AddHairdresser(HairdresserModel hairdresser)
        {
            await _context.Hairdressers.AddAsync(hairdresser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHairdresser(Guid id)
        {
            HairdresserModel result = _context.Hairdressers.SingleOrDefault(x => x.Id == id);
            result.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HairdresserModel>> GetAllHairdressers()
        {
            return await _context.Hairdressers.Where(x=>x.IsDeleted==false).ToListAsync();
        }

        public async Task<HairdresserModel> GetHairdresser(Guid id)
        {
            return await _context.Hairdressers.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

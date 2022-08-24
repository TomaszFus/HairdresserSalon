using HairdresserSalon.Data;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Concrete
{
    public class HourRepository : IHourRepository
    {
        private readonly HairdresserDbContext _context;
        public HourRepository(HairdresserDbContext context)
        {
            _context = context;
        }

        public async Task AddHour(HourModel hour)
        {
            await _context.Hours.AddAsync(hour);
            await _context.SaveChangesAsync();        
        }

        public async Task Delete(Guid id)
        {
            var result = _context.Hours.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                _context.Hours.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<HourModel> GetHour(Guid id)
        {
            return await _context.Hours.Where(x=>x.Id==id).Include(x=>x.Day).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<HourModel>> GetHoursForDay(Guid dayId)
        {
            return await _context.Hours.Where(x => x.Day.Id == dayId).ToListAsync();
        }

        public async Task Update(HourModel hour)
        {
            _context.Update(hour);
            await _context.SaveChangesAsync();
        }
    }
}

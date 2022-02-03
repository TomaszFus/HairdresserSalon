using HairdresserSalon.Data;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
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
    }
}

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
    public class DayRepository : IDayRepository
    {
        private readonly HairdresserDbContext _context;
        public DayRepository(HairdresserDbContext context)
        {
            _context = context;
        }

        public async Task AddDay(DayModel day)
        {
            await _context.Days.AddAsync(day);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DayModel>> GetAllDays()
        {
            return await _context.Days.Include(x=>x.Hairdresser).Include(x=>x.Hours).ToListAsync();
        }

        public async Task<IEnumerable<DayModel>> GetAllDaysForHairdresser(Guid id)
        {
            return await _context.Days.Include(x => x.Hairdresser).Include(x => x.Hours).Where(x => x.Hairdresser.Id == id).ToListAsync();
        }

        public async Task<IEnumerable<DayModel>> GetAvailableDates()
        {
            return await _context.Days.Where(x=>x.Date>=DateTime.Today).Include(x => x.Hairdresser).Where(x=>x.Hairdresser.IsDeleted==false).Include(x => x.Hours).ToListAsync();
        }

        public async Task<DayModel> GetDayWithHairdresser(Guid id)
        {
            return await _context.Days.Where(x => x.Id == id).Include(x => x.Hairdresser).SingleOrDefaultAsync();
        }

        public async Task<DayModel> GetDayWithHairdresserAndHours(Guid id)
        {
            return await _context.Days.Where(x => x.Id == id).Include(x => x.Hairdresser).Include(x => x.Hours).FirstOrDefaultAsync();
        }

        public async Task<DayModel> GetDayWithAvailableHours(Guid id)
        {
            return await _context.Days.Where(x => x.Id == id).Include(x => x.Hairdresser).Include(x => x.Hours.Where(y=>y.Available==true).OrderBy(z=>z.Hour)).FirstOrDefaultAsync();
        }

        public async Task<DayModel> GetDay(Guid id)
        {
            return await _context.Days.Where(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}

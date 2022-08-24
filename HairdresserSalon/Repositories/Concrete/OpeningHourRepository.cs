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
    public class OpeningHourRepository : IOpeningHourRepository
    {
        private readonly HairdresserDbContext _context;
        public OpeningHourRepository(HairdresserDbContext context)
        {
            _context = context;
        }
        public async Task<OpeningHourModel> GetHour(int id)
        {
            return await _context.OpeningHours.Where(x => x.Id == id).OrderBy(x=>x.Id).FirstOrDefaultAsync();
        }

        public async Task Update(int id, OpeningHourModel openingHourModel)
        {
            var result = _context.OpeningHours.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Open = openingHourModel.Open;
                result.Close = openingHourModel.Close;
                result.IsOpen = openingHourModel.IsOpen;
                await _context.SaveChangesAsync();
            }
        }
    }
}

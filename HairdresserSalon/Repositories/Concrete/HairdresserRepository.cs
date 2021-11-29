using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using HairdresserSalon.Data;

namespace HairdresserSalon.Repositories.Concrete
{
    public class HairdresserRepository : IHairdresserRepository
    {
        private readonly HairdresserDbContext _context;
        public HairdresserRepository(HairdresserDbContext context)
        {
            _context = context;
        }

        public void AddHairdresser(HairdresserModel hairdresser)
        {
            _context.Hairdressers.Add(hairdresser);
            _context.SaveChanges();
        }

        public IEnumerable<HairdresserModel> GetAllHairdressers()
        {
            return _context.Hairdressers.ToList();
        }
    }
}

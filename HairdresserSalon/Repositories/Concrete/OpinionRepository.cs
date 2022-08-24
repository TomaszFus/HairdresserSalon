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
    public class OpinionRepository : IOpinionRepository
    {
        private readonly HairdresserDbContext _context;
        public OpinionRepository(HairdresserDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<VisitModel>> GetAllOpinions()
        {
            return await _context.Visits.Include(x => x.Opinion).Where(x=>x.Opinion!=null).Include(x => x.Service).Include(x => x.Customer).Include(x=>x.Hairdresser).OrderByDescending(x=>x.Opinion.Date).ToListAsync();
        }
    }
}

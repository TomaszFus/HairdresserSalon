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
    public class VisitRepository : IVisitRepository
    {
        private readonly HairdresserDbContext _context;
        public VisitRepository(HairdresserDbContext context)
        {
            _context = context;
        }

        public async Task AddOpinion(VisitModel visit)
        {
            _context.Visits.Update(visit);
            await _context.SaveChangesAsync();
        }

        public async Task AddVisit(VisitModel visit)
        {
            await _context.Visits.AddAsync(visit);
            await _context.SaveChangesAsync();
        }

        public async Task CancelVisit(Guid id)
        {
            var visitToCancel = _context.Visits.SingleOrDefault(x => x.Id == id);
            visitToCancel.Canceled = true;
            await _context.SaveChangesAsync();

        }

        public async Task Discount(Guid id)
        {
            var visit = _context.Visits.SingleOrDefault(x => x.Id == id);
            visit.Price = visit.Price - visit.Price * 20 / 100;
            await _context.SaveChangesAsync();
        }

        public async Task EndVisit(Guid id)
        {
            var visitToEnd = _context.Visits.SingleOrDefault(x => x.Id == id);
            visitToEnd.Ended = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VisitModel>> GetAllVisits()
        {
            return await _context.Visits.Where(x => x.Canceled == false && x.Ended == false).Include(x=>x.Customer).Include(x=>x.Date.Day).Include(x=>x.Hairdresser).Include(x=>x.Service).ToListAsync();
        }

        public async Task<VisitModel> GetVisitDetails(Guid id)
        {
            return await _context.Visits.Where(x=>x.Id==id).Include(x => x.Customer).Include(x => x.Date.Day).Include(x => x.Hairdresser).Include(x => x.Service).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<VisitModel>> GetVisitsForCustomer(Guid id)
        {
            return await _context.Visits.Where(x=>x.Customer.Id==id).Where(x=>x.Canceled == false && x.Ended == false).Include(x => x.Date.Day).Include(x => x.Hairdresser).Include(x => x.Service).ToListAsync();
        }

        public async Task<IEnumerable<VisitModel>> GetVisitsForHairdresser(Guid id)
        {
            return await _context.Visits.Where(x => x.Hairdresser.Id == id && x.Canceled == false && x.Ended == false).ToListAsync();
        }

        public async Task<IEnumerable<VisitModel>> GetVisitsHistory(Guid id)
        {
            return await _context.Visits.Where(x => x.Customer.Id == id).Where(x=>x.Ended==true).Include(x => x.Date.Day).Include(x => x.Hairdresser).Include(x => x.Service).Include(x=>x.Opinion).ToListAsync();
        }

        public async Task<IEnumerable<VisitModel>> VisitsArchive()
        {
            return await _context.Visits.Where(x => x.Ended == true || x.Canceled == true).Include(x => x.Date.Day).Include(x => x.Hairdresser).Include(x => x.Service).Include(x => x.Opinion).Include(x => x.Customer).ToListAsync();
        }
    }
}

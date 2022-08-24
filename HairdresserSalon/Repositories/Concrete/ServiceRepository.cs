using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairdresserSalon.Repositories.Abstract;
using HairdresserSalon.Data;
using HairdresserSalon.Models;
using Microsoft.EntityFrameworkCore;

namespace HairdresserSalon.Repositories.Concrete
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly HairdresserDbContext _context;
        public ServiceRepository(HairdresserDbContext context)
        {
            _context = context;
        }

        public async Task AddService(ServiceModel service)
        {
            await _context.Services.AddAsync(service);
            _context.SaveChanges();
        }

        public async Task<ServiceModel> Get(Guid id)
        {
            return await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ServiceModel>> GetAllServices()
        {
            return await _context.Services.Where(x=>x.IsDeleted==false).ToListAsync();
        }

        public async Task Update(Guid id, ServiceModel serviceModel)
        {
            var result = _context.Services.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Name = serviceModel.Name;
                result.Price = serviceModel.Price;
                result.Duration = serviceModel.Duration;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var result = _context.Services.SingleOrDefault(x => x.Id == id);
            if (result!=null)
            {
                result.IsDeleted = true;
                _context.SaveChanges();
            }
        }
    }
}

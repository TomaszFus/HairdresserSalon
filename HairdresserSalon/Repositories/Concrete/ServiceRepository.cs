using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairdresserSalon.Repositories.Abstract;
using HairdresserSalon.Data;
using HairdresserSalon.Models;

namespace HairdresserSalon.Repositories.Concrete
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly HairdresserDbContext _context;
        public ServiceRepository(HairdresserDbContext context)
        {
            _context = context;
        }

        public void AddService(ServiceModel service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public ServiceModel Get(int id)
        {
            return _context.Services.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ServiceModel> GetAllServices()
        {
            return _context.Services.ToList();
        }
    }
}

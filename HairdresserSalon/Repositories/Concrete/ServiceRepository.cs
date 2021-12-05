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

        public ServiceModel Get(Guid id)
        {
            return _context.Services.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ServiceModel> GetAllServices()
        {
            return _context.Services.ToList();
        }

        public void Update(Guid id, ServiceModel serviceModel)
        {
            var result = _context.Services.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Name = serviceModel.Name;
                result.Price = serviceModel.Price;

                _context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            var result = _context.Services.SingleOrDefault(x => x.Id == id);
            if (result!=null)
            {
                _context.Services.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}

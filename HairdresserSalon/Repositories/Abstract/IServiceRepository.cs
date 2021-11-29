using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Abstract
{
    public interface IServiceRepository
    {
        void AddService(ServiceModel service);
        IEnumerable<ServiceModel> GetAllServices();
        ServiceModel Get(int id);
    }
}

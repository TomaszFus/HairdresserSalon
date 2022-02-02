using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Abstract
{
    public interface IServiceRepository
    {
        Task AddService(ServiceModel service);
        Task<IEnumerable<ServiceModel>> GetAllServices();
        Task<ServiceModel> Get(Guid id);
        Task Update(Guid id, ServiceModel serviceModel);
        Task Delete(Guid id);
    }
}

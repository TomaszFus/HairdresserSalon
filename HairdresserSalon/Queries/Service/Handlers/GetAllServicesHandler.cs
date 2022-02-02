using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;

namespace HairdresserSalon.Queries.Service.Handlers
{
    public class GetAllServicesHandler : IQueryHandler<GetAllServices, IEnumerable<ServiceModel>>
    {
        private readonly IServiceRepository _serviceRepository;
        public GetAllServicesHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<IEnumerable<ServiceModel>> HandleAsync(GetAllServices query)
        {
            return await _serviceRepository.GetAllServices();
        }
    }
}

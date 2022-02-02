using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;

namespace HairdresserSalon.Queries.Service.Handlers
{
    public class GetServiceHandler : IQueryHandler<GetService, ServiceModel>
    {
        private readonly IServiceRepository _serviceRepository;
        public GetServiceHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ServiceModel> HandleAsync(GetService query)
        {
            return await _serviceRepository.Get(query.Id);
        }
    }
}

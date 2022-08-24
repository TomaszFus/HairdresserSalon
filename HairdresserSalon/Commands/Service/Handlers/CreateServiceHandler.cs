using Convey.CQRS.Commands;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Service.Handlers
{
    public class CreateServiceHandler : ICommandHandler<CreateService>
    {
        private readonly IServiceRepository _serviceRepository;
        public CreateServiceHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task HandleAsync(CreateService command)
        {
            ServiceModel service = ServiceModel.Create(Guid.NewGuid(), command.Name, command.Price, command.Duration, false);
            await _serviceRepository.AddService(service);
        }
    }
}

using Convey.CQRS.Commands;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Service.Handlers
{
    public class UpdateInformationHandler : ICommandHandler<UpdateService>
    {
        private readonly IServiceRepository _serviceRepository;
        public UpdateInformationHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task HandleAsync(UpdateService command)
        {
            ServiceModel service = new ServiceModel();
            service.Name = command.Name;
            service.Price = command.Price;
            service.Duration = command.Duration;

            await _serviceRepository.Update(command.Id, service);
        }
    }
}

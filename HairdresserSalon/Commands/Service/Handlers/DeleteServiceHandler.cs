using Convey.CQRS.Commands;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Service.Handlers
{
    public class DeleteServiceHandler : ICommandHandler<DeleteService>
    {
        private readonly IServiceRepository _serviceRepository;
        public DeleteServiceHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task HandleAsync(DeleteService command)
        {
            await _serviceRepository.Delete(command.Id);
        }
    }
}

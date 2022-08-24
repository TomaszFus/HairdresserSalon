using Convey.CQRS.Commands;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Hour.Handlers
{
    public class DeleteHandler : ICommandHandler<Delete>
    {
        private readonly IHourRepository _hourRepository;
        public DeleteHandler(IHourRepository hourRepository)
        {
            _hourRepository = hourRepository;
        }
        public async Task HandleAsync(Delete command)
        {
            await _hourRepository.Delete(command.Id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;

namespace HairdresserSalon.Commands.Hairdresser.Handlers
{
    public class CreateHairdresserHandler : ICommandHandler<CreateHairdresser>
    {
        private readonly IHairdresserRepository _hairdresserRepository;
        public CreateHairdresserHandler(IHairdresserRepository hairdresserRepository)
        {
            _hairdresserRepository = hairdresserRepository;
        }

        public async Task HandleAsync(CreateHairdresser command)
        {
            HairdresserModel hairdresser = HairdresserModel.Create(Guid.NewGuid(), command.Name, false);
            await _hairdresserRepository.AddHairdresser(hairdresser);
        }
    }
}

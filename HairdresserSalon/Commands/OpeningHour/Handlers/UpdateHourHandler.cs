using Convey.CQRS.Commands;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.OpeningHour.Handlers
{
    public class UpdateHourHandler : ICommandHandler<UpdateHour>
    {
        private readonly IOpeningHourRepository _openingHourRepository;
        public UpdateHourHandler(IOpeningHourRepository openingHourRepository)
        {
            _openingHourRepository = openingHourRepository;
        }

        public async Task HandleAsync(UpdateHour command)
        {
            OpeningHourModel openingHour = new OpeningHourModel();
            openingHour.Open = command.Open;
            openingHour.Close = command.Close;
            openingHour.IsOpen = command.IsOpen;

            await _openingHourRepository.Update(command.Id, openingHour);
        }
    }
}

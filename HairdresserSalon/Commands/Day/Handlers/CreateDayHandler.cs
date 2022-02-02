using Convey.CQRS.Commands;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Day.Handlers
{
    public class CreateDayHandler : ICommandHandler<CreateDay>
    {
        private readonly IDayRepository _dayRepository;
        private readonly IHairdresserRepository _hairdresserRepository;
        public CreateDayHandler(IDayRepository dayRepository, IHairdresserRepository hairdresserRepository)
        {
            _dayRepository = dayRepository;
            _hairdresserRepository = hairdresserRepository;
        }
        public async Task HandleAsync(CreateDay command)
        {
            HairdresserModel hairdresser = await GetHairdresser(command.Id);
            DayModel day = DayModel.Create(Guid.NewGuid(), command.Date, hairdresser);
            await _dayRepository.AddDay(day);
        }

        public async Task<HairdresserModel> GetHairdresser(Guid id)
        {
            return await _hairdresserRepository.GetHairdresser(id);
        }
    }
}

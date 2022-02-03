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
        private readonly IHourRepository _hourRepository;
        public CreateDayHandler(IDayRepository dayRepository, IHairdresserRepository hairdresserRepository, IHourRepository hourRepository)
        {
            _dayRepository = dayRepository;
            _hairdresserRepository = hairdresserRepository;
            _hourRepository = hourRepository;
        }
        public async Task HandleAsync(CreateDay command)
        {
            Guid id = Guid.NewGuid();
            HairdresserModel hairdresser = await GetHairdresser(command.Id);
            DayModel day = DayModel.Create(id, command.Date, hairdresser);
            await _dayRepository.AddDay(day);
            await AddHoursToDay(day);
        }

        public async Task<HairdresserModel> GetHairdresser(Guid id)
        {
            return await _hairdresserRepository.GetHairdresser(id);
        }

        public async Task AddHoursToDay(DayModel day)
        {
            DateTime hour = day.Date.AddHours(10);
            HourModel hourModel = HourModel.Create(Guid.NewGuid(), hour, true, day);
            await _hourRepository.AddHour(hourModel);
            DateTime tmp=hour;
            while(tmp.Hour <17)
            {
                HourModel hourModel2 = HourModel.Create(Guid.NewGuid(), tmp.AddMinutes(30), true, day);
                await _hourRepository.AddHour(hourModel2);
                tmp = hourModel2.Hour;
            }
        }
    }
}

using Convey.CQRS.Commands;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Hour.Handlers
{
    public class AddHourHandler : ICommandHandler<AddHour>
    {
        private readonly IDayRepository _dayRepository;
        private readonly IHourRepository _hourRepository;
        public AddHourHandler(IDayRepository dayRepository, IHourRepository hourRepository)
        {
            _dayRepository = dayRepository;
            _hourRepository = hourRepository;
        }
        public async Task HandleAsync(AddHour command)
        {
            DayModel day = GetDay(command.DayId).Result;
            var h = command.Hour.Hour;
            var min = command.Hour.Minute;
            TimeSpan ts = new TimeSpan(h, min, 0);
            DateTime newHour = day.Date.Date + ts;
            HourModel hour = HourModel.Create(Guid.NewGuid(), newHour, true, day);
            await _hourRepository.AddHour(hour);
            
        }

        public async Task<DayModel> GetDay(Guid id)
        {
            return await _dayRepository.GetDay(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;

namespace HairdresserSalon.Queries.Day.Handlers
{
    public class GetDayAndHairdresserHandler : IQueryHandler<GetDayAndHairdresser, DayModel>
    {
        private readonly IDayRepository _dayRepository;
        public GetDayAndHairdresserHandler(IDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }

        public async Task<DayModel> HandleAsync(GetDayAndHairdresser query)
        {
            return await _dayRepository.GetDayWithHairdresser(query.Id);
        }
    }
}

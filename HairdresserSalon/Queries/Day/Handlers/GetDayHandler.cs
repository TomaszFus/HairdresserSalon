using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Day.Handlers
{
    public class GetDayHandler : IQueryHandler<GetDay, DayModel>
    {
        private readonly IDayRepository _dayRepository;
        public GetDayHandler(IDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }
        public async Task<DayModel> HandleAsync(GetDay query)
        {
            return await _dayRepository.GetDayWithAvailableHours(query.Id);
        }
    }
}

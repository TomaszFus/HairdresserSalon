using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Hour.Handlers
{
    public class GetHoursForDayHandler : IQueryHandler<GetHoursForDay, IEnumerable<HourModel>>
    {
        private readonly IHourRepository _hourRepository;
        public GetHoursForDayHandler(IHourRepository hourRepository)
        {
            _hourRepository = hourRepository;
        }
        public async Task<IEnumerable<HourModel>> HandleAsync(GetHoursForDay query)
        {
            return await _hourRepository.GetHoursForDay(query.Id);
        }
    }
}

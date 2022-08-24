using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;

namespace HairdresserSalon.Queries.Hour.Handlers
{
    public class GetHourHandler : IQueryHandler<GetHour, HourModel>
    {
        private readonly IHourRepository _hourRepository;
        public GetHourHandler(IHourRepository hourRepository)
        {
            _hourRepository = hourRepository;
        }
        public async Task<HourModel> HandleAsync(GetHour query)
        {
            return await _hourRepository.GetHour(query.Id);
        }
    }
}

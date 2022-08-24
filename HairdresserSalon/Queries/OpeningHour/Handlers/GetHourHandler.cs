using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.OpeningHour.Handlers
{
    public class GetHourHandler : IQueryHandler<GetHour, OpeningHourModel>
    {
        private readonly IOpeningHourRepository _openingHourRepository;
        public GetHourHandler(IOpeningHourRepository openingHourRepository)
        {
            _openingHourRepository = openingHourRepository;
        }

        public async Task<OpeningHourModel> HandleAsync(GetHour query)
        {
            return await _openingHourRepository.GetHour(query.Id);
        }
    }
}

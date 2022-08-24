using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Hairdresser.Handlers
{
    public class GetHairdresserHandler : IQueryHandler<GetHairdresser, HairdresserModel>
    {
        private readonly IHairdresserRepository _hairdresserRepository;
        public GetHairdresserHandler(IHairdresserRepository hairdresserRepository)
        {
            _hairdresserRepository = hairdresserRepository;
        }
        public async Task<HairdresserModel> HandleAsync(GetHairdresser query)
        {
            return await _hairdresserRepository.GetHairdresser(query.Id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;

namespace HairdresserSalon.Queries.Hairdresser.Handlers
{
    public class GetAllHairdressersHandler : IQueryHandler<GetAllHairdressers, IEnumerable<HairdresserModel>>
    {
        private readonly IHairdresserRepository _hairdresserRepository;
        public GetAllHairdressersHandler(IHairdresserRepository hairdresserRepository)
        {
            _hairdresserRepository = hairdresserRepository;
        }


        public async Task<IEnumerable<HairdresserModel>> HandleAsync(GetAllHairdressers query)
        {
            return await _hairdresserRepository.GetAllHairdressers();
        }
    }
}

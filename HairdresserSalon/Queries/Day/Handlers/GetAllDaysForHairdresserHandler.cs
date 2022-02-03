using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Day.Handlers
{
    public class GetAllDaysForHairdresserHandler : IQueryHandler<GetAllDaysForHairdresser, IEnumerable<DayModel>>
    {
        private readonly IDayRepository _dayRepository;
        public GetAllDaysForHairdresserHandler(IDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }

        public async Task<IEnumerable<DayModel>> HandleAsync(GetAllDaysForHairdresser query)
        {
            var list = await _dayRepository.GetAllDaysForHairdresser(query.Id);
            foreach (var item in list)
            {
                item.Hours = item.Hours.OrderBy(x => x.Hour).ToList();
            }
            
            return list.OrderBy(x => x.Date);
        }
    }
}

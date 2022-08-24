using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;

namespace HairdresserSalon.Queries.Day.Handlers
{
    public class GetAllAvailableDatesHandler : IQueryHandler<GetAllAvailableDates, IEnumerable<DayModel>>
    {
        private readonly IDayRepository _dayRepository;
        public GetAllAvailableDatesHandler(IDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }
        public async Task<IEnumerable<DayModel>> HandleAsync(GetAllAvailableDates query)
        {
            var list = await _dayRepository.GetAvailableDates();
            foreach (var item in list)
            {
                if (item.Date == DateTime.Today)
                {
                    item.Hours = item.Hours.Where(x => x.Hour.Hour > DateTime.Now.Hour).ToList();
                }
                item.Hours = item.Hours.OrderBy(x => x.Hour).Where(x=>x.Available==true).ToList();
            }
            list = list.Where(x => x.Hours.Count != 0).ToList();
            return list.OrderBy(x => x.Date);
        }
    }
}

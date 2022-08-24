using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;

namespace HairdresserSalon.Queries.Visit.Handlers
{
    public class GetAllVisitsHandler : IQueryHandler<GetAllVisits, IEnumerable<VisitModel>>
    {
        private readonly IVisitRepository _visitRepository;
        public GetAllVisitsHandler(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }
        public async Task<IEnumerable<VisitModel>> HandleAsync(GetAllVisits query)
        {
            var list = await _visitRepository.GetAllVisits();
            return list.OrderBy(x => x.Date.Day.Date).OrderBy(x=>x.Date.Hour);
        }
    }
}

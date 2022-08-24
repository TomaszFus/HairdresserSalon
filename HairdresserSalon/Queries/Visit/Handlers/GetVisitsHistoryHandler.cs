using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Visit.Handlers
{
    public class GetVisitsHistoryHandler : IQueryHandler<GetVisitsHistory, IEnumerable<VisitModel>>
    {
        private readonly IVisitRepository _visitRepository;
        public GetVisitsHistoryHandler(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        public async Task<IEnumerable<VisitModel>> HandleAsync(GetVisitsHistory query)
        {
            var list = await _visitRepository.GetVisitsHistory(query.Id);
            return list.OrderByDescending(x => x.Date.Day.Date);
        }
    }
}

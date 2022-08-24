using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Visit.Handlers
{
    public class GetVisitsArchiveHandler : IQueryHandler<GetVisitsArchive, IEnumerable<VisitModel>>
    {
        private readonly IVisitRepository _visitRepository;
        public GetVisitsArchiveHandler(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }
        public async Task<IEnumerable<VisitModel>> HandleAsync(GetVisitsArchive query)
        {
            var list = await _visitRepository.VisitsArchive();
            return list.OrderByDescending(x => x.Date.Day.Date).OrderByDescending(x => x.Date.Hour);
        }
    }
}

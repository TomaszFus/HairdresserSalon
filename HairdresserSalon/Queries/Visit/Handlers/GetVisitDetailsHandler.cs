using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Visit.Handlers
{
    public class GetVisitDetailsHandler : IQueryHandler<GetVisitDetails, VisitModel>
    {
        private readonly IVisitRepository _visitRepository;
        public GetVisitDetailsHandler(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }
        public async Task<VisitModel> HandleAsync(GetVisitDetails query)
        {
            return await _visitRepository.GetVisitDetails(query.Id);
        }
    }
}

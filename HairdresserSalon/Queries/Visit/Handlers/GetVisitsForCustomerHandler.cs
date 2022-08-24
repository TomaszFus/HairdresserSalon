using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Visit.Handlers
{
    public class GetVisitsForCustomerHandler : IQueryHandler<GetVisitsForCustomer, IEnumerable<VisitModel>>
    {
        private readonly IVisitRepository _visitRepository;
        public GetVisitsForCustomerHandler(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        public async Task<IEnumerable<VisitModel>> HandleAsync(GetVisitsForCustomer query)
        {
            return await _visitRepository.GetVisitsForCustomer(query.Id);
        }
    }
}

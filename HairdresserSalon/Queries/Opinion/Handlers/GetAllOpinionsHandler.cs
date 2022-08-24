using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Opinion.Handlers
{
    public class GetAllOpinionsHandler : IQueryHandler<GetAllOpinions, IEnumerable<VisitModel>>
    {
        private readonly IOpinionRepository _opinionRepository;
        public GetAllOpinionsHandler(IOpinionRepository opinionRepository)
        {
            _opinionRepository = opinionRepository;
        }
        public async Task<IEnumerable<VisitModel>> HandleAsync(GetAllOpinions query)
        {
            return await _opinionRepository.GetAllOpinions();
        }
    }
}

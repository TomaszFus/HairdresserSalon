using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Information.Handler
{
    public class GetInformationHandler : IQueryHandler<GetInformation, InformationModel>
    {
        private readonly IInformationRepository _informationRepository;
        public GetInformationHandler(IInformationRepository informationRepository)
        {
            _informationRepository = informationRepository;
        }

        public async Task<InformationModel> HandleAsync(GetInformation query)
        {
            return await _informationRepository.GetInformation();
        }
    }
}

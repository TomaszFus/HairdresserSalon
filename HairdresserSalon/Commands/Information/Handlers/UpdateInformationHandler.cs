using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Queries.Information;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Information.Handlers
{
    public class UpdateInformationHandler : ICommandHandler<UpdateInformation>
    {
        private readonly IInformationRepository _informationRepository;
        private readonly IQueryDispatcher _queryDispatcher;
        public UpdateInformationHandler(IInformationRepository informationRepository, IQueryDispatcher queryDispatcher)
        {
            _informationRepository = informationRepository;
            _queryDispatcher = queryDispatcher;
        }
        

        public async Task HandleAsync(UpdateInformation command)
        {
            var info = _queryDispatcher.QueryAsync(new GetInformation()).Result;
            info.Street = command.Street;
            info.City = command.City;
            info.PhoneNumber = command.PhoneNumber;
            await _informationRepository.Update(info);
            
        }
    }
}

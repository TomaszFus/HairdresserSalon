using Convey.CQRS.Commands;
using HairdresserSalon.Commands.Visit;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Hairdresser.Handlers
{
    public class DeleteHairdresserHandler : ICommandHandler<DeleteHairdresser>
    {
        private readonly IHairdresserRepository _hairdresserRepository;
        private readonly IVisitRepository _visitRepository;
        private readonly ICommandDispatcher _commandDispatcher;
        public DeleteHairdresserHandler(IHairdresserRepository hairdresserRepository, IVisitRepository visitRepository, ICommandDispatcher commandDispatcher)
        {
            _hairdresserRepository = hairdresserRepository;
            _visitRepository = visitRepository;
            _commandDispatcher = commandDispatcher;
        }
        public async Task HandleAsync(DeleteHairdresser command)
        {
            var list = GetVisits(command.Id).Result;
            await CencelVisits(list);
            await _hairdresserRepository.DeleteHairdresser(command.Id);
        }

        public async Task<IEnumerable<VisitModel>> GetVisits(Guid id)
        {
            var visits = _visitRepository.GetVisitsForHairdresser(id).Result;
            return visits;
        }

        public async Task CencelVisits(IEnumerable<VisitModel> list)
        {
            foreach (var item in list)
            {
                await _commandDispatcher.SendAsync(new CancelVisit(item.Id, 2));
            }
        }




    }
}

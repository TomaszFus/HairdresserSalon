using Convey.CQRS.Commands;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Visit.Handlers
{
    public class AddOpinionHandler : ICommandHandler<AddOpinion>
    {
        private readonly IVisitRepository _visitRepository;
        public AddOpinionHandler(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }
        public async Task HandleAsync(AddOpinion command)
        {
            OpinionModel opinion = command.Visit.Opinion;
            VisitModel visit = GetVisit(command.Visit.Id).Result;
            opinion.Hairdresser = visit.Hairdresser;
            visit.Opinion = opinion;
            visit.Opinion.Date = DateTime.Now;
            await _visitRepository.AddOpinion(visit);

        }

        public async Task<VisitModel> GetVisit(Guid id)
        {
            return await _visitRepository.GetVisitDetails(id);
        }
    }
}

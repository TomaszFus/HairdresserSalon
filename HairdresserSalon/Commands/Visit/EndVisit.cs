using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Visit
{
    public class EndVisit : ICommand
    {
        public Guid VisitId { get; set; }

        public EndVisit(Guid visitId)
        {
            VisitId = visitId;
        }
    }
}

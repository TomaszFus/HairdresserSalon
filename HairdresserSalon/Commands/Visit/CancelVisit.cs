using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Visit
{
    public class CancelVisit : ICommand
    {
        public Guid VisitId { get; set; }
        public int Source { get; set; }

        public CancelVisit(Guid visitId, int source)
        {
            VisitId = visitId;
            Source = source;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using HairdresserSalon.Models;

namespace HairdresserSalon.Commands.Visit
{
    public class CreateVisit : ICommand
    {
        public Guid ServiceId { get; set; }
        public Guid UserId { get; set; }
        public Guid HairdresserId { get; set; }
        public Guid DateId { get; set; }
        public VisitModel Visit { get; set; }
        public CreateVisit(Guid serviceId, Guid userId, Guid hairdresserId, Guid dateId, VisitModel visit)
        {
            ServiceId = serviceId;
            UserId = userId;
            HairdresserId = hairdresserId;
            DateId = dateId;
            Visit = visit;
        }
    }
}

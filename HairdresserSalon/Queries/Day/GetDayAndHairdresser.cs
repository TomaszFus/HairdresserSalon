using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Models;

namespace HairdresserSalon.Queries.Day
{
    public class GetDayAndHairdresser : IQuery<DayModel>
    {
        public Guid Id { get; set; }
    }
}

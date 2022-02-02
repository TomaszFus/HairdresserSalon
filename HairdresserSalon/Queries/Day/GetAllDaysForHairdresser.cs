using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Day
{
    public class GetAllDaysForHairdresser : IQuery<IEnumerable<DayModel>>
    {
        public Guid Id { get; set; }
    }
}

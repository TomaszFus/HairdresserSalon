using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Hour
{
    public class GetHoursForDay : IQuery<IEnumerable<HourModel>>
    {
        public Guid Id { get; set; }
    }
}

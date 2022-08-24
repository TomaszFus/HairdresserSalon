using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Models;

namespace HairdresserSalon.Queries.Hour
{
    public class GetHour : IQuery<HourModel>
    {
        public Guid Id { get; set; }
    }
}

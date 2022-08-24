using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Hairdresser
{
    public class GetHairdresser : IQuery<HairdresserModel>
    {
        public Guid Id { get; set; }
    }
}

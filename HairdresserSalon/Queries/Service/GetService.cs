using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Models;

namespace HairdresserSalon.Queries.Service
{
    public class GetService : IQuery<ServiceModel>
    {
        public Guid Id { get; set; }
    }
}

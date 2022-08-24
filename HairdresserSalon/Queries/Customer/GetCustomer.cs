using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Models;

namespace HairdresserSalon.Queries.Customer
{
    public class GetCustomer : IQuery<CustomerModel>
    {
        public Guid Id { get; set; }
    }
}

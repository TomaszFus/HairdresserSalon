﻿using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Customer
{
    public class GetAllCustomers : IQuery<IEnumerable<CustomerModel>>
    {
    }
}
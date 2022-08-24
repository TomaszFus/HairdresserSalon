using Convey.CQRS.Commands;
using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Customer
{
    public class CreateCustomer : ICommand
    {
        public CustomerModel Customer { get; set; }


        public CreateCustomer(CustomerModel customer)
        {
            Customer = customer;
        }
    }
}

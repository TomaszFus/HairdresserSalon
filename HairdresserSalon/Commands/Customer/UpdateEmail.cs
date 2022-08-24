using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Customer
{
    public class UpdateEmail : ICommand
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public UpdateEmail(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}

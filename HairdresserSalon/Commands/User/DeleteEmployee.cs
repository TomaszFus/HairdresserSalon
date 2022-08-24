using Convey.CQRS.Commands;
using HairdresserSalon.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.User
{
    public class DeleteEmployee : ICommand
    {
        public Guid Id { get; set; }
        public DeleteEmployee(Guid id)
        {
            Id = id;
        }
    }
}

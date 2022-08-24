using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Hour
{
    public class Delete : ICommand
    {
        public Guid Id { get; set; }
        public Delete(Guid id)
        {
            Id = id;
        }
    }
}

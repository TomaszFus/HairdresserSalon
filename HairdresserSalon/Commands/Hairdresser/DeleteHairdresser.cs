using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Hairdresser
{
    public class DeleteHairdresser : ICommand
    {
        public Guid Id { get; set; }
        public DeleteHairdresser(Guid id)
        {
            Id = id;
        }
    }
}

using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Service
{
    public class DeleteService : ICommand
    {
        public Guid Id { get; set; }
        public DeleteService(Guid id)
        {
            Id = id;
        }
    }
}

using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Hairdresser
{
    public class CreateHairdresser : ICommand
    {
        public string Name { get; }

        public CreateHairdresser(string name)
        {
            Name = name;
        }
    }
}

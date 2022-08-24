using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Service
{
    public class CreateService : ICommand
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Duration { get; set; }

        public CreateService(string name, float price, int duration)
        {
            Name = name;
            Price = price;
            Duration = duration;
        }
    }
}

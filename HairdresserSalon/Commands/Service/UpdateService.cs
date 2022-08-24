using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Service
{
    public class UpdateService : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Duration { get; set; }

        public UpdateService(Guid id, string name, float price, int duration)
        {
            Id = id;
            Name = name;
            Price = price;
            Duration = duration;
        }
    }
}

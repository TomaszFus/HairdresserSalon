using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.OpeningHour
{
    public class UpdateHour : ICommand
    {
        public int Id { get; set; }
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
        public bool IsOpen { get; set; }

        public UpdateHour(int id, DateTime open, DateTime close, bool isOpen)
        {
            Id = id;
            Open = open;
            Close = close;
            IsOpen = isOpen;
        }

    }
}

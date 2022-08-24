using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Hour
{
    public class AddHour : ICommand
    {
        public Guid DayId { get; set; }
        public DateTime Hour { get; set; }
        public AddHour(Guid dayId, DateTime hour)
        {
            DayId = dayId; ;
            Hour = hour;
        }
    }
}

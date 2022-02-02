using Convey.CQRS.Commands;
using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Day
{
    public class CreateDay : ICommand
    {
        public DateTime Date { get; set; }
        public Guid Id { get; set; }

        public CreateDay(DateTime date, Guid id)
        {
            Date = date;
            Id = id;

        }
    }
}

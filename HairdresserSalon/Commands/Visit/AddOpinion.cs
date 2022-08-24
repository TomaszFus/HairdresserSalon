using Convey.CQRS.Commands;
using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Visit
{
    public class AddOpinion : ICommand
    {
        //public HairdresserModel Hairdresser { get; set; }
        //public string Description { get; set; }
        //public int Rating { get; set; }
        public VisitModel Visit { get; set; }

        //public AddOpinion(HairdresserModel hairdresser, string description, int rating)
        //{
        //    Hairdresser = hairdresser;
        //    Description = description;
        //    Rating = rating;
        //}
        public AddOpinion(VisitModel visit)
        {
            Visit = visit;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairdresserSalon.Models;

namespace HairdresserSalon.Models
{
    public class VisitModel
    {
        public Guid Id { get; set; }
        public HairdresserModel hairdresser { get; set; }
        public ServiceModel service { get; set; }
        public Guid CustomerId { get; set; }
        public bool Ended { get; set; }
        public DateTime Date { get; set; }
        public bool Canceled { get; set; }
    }
}

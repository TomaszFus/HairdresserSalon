using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HairdresserSalon.Models;

namespace HairdresserSalon.Models
{
    public class VisitModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Fryzjer")]
        public HairdresserModel Hairdresser { get; set; }
        public ServiceModel Service { get; set; }
        public CustomerModel Customer { get; set; }
        public bool Ended { get; set; }
        public HourModel Date { get; set; }
        public bool Canceled { get; set; }
        [Display(Name = "Cena")]
        public float Price { get; set; }
        public OpinionModel Opinion { get; set; }

        public VisitModel()
        {
        }

        public VisitModel(Guid id, HairdresserModel hairdresser, bool ended, HourModel date, bool canceled)
        {
            Id = id;
            Hairdresser = hairdresser;
            
            
            Ended = ended;
            Date = date;
            Canceled = canceled;
           
        }

        public static VisitModel Create(Guid id, HairdresserModel hairdresser, bool ended, HourModel date, bool canceled)
        {
            VisitModel visit = new VisitModel(id, hairdresser, ended, date, canceled);
            return visit;
        }
    }
}

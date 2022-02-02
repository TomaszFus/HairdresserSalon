using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Models
{
    public class DayModel
    {
        public Guid Id { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }
        public HairdresserModel Hairdresser { get; set; }
        public ICollection<HourModel> Hours { get; set; }

        public DayModel()
        {

        }
        public DayModel(Guid id, DateTime date, HairdresserModel hairdresser)
        {
            Id = id;
            Date = date;
            Hairdresser = hairdresser;
        }

        public static DayModel Create(Guid id, DateTime date, HairdresserModel hairdresser)
        {
            DayModel day = new DayModel(id, date, hairdresser);
            return day;
        }
    }
}

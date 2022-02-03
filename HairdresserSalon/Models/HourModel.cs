using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Models
{
    public class HourModel
    {
        public Guid Id { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Hour { get; set; }
        public bool Available { get; set; }
        public DayModel Day { get; set; }

        public HourModel()
        {

        }

        public HourModel(Guid id, DateTime hour, bool available, DayModel day)
        {
            Id = id;
            Hour = hour;
            Available = available;
            Day = day;
        }

        public static HourModel Create(Guid id, DateTime hour, bool available, DayModel day)
        {
            HourModel hourModel = new HourModel(id, hour, available, day);
            return hourModel;
        }
    }
}

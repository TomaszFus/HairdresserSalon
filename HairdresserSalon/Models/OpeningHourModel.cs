using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Models
{
    public class OpeningHourModel
    {
        public int Id { get; set; }
        public string DayOfWeek { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Godzina otwarcia")]
        public DateTime Open { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Godzina zamknięcia")]
        public DateTime Close { get; set; }
        [Display(Name ="Otwarte")]
        public bool IsOpen { get; set; }
        public InformationModel Information { get; set; }

        public OpeningHourModel()
        {

        }
    }
}

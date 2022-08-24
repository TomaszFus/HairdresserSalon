using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Models
{
    public class OpinionModel
    {
        public Guid Id { get; set; }
        public HairdresserModel Hairdresser { get; set; }
        [Display(Name = "Opinia")]
        public string Description { get; set; }
        [Display(Name ="Ocena")]
        [Required(ErrorMessage ="Wybierz ocenę")]
        public int Rating { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }

    }
}

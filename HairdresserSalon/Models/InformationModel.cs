using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Models
{
    public class InformationModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Adres")]
        [Required(ErrorMessage ="Podaj ulicę")]
        public string Street { get; set; }
        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Podaj miasto")]
        public string City { get; set; }
        [Required(ErrorMessage = "Podaj telefon")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Numer telefonu musi się składać z 9 cyfr")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Podaj wyłącznie cyfry")]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }
        public ICollection<OpeningHourModel> OpeningHour { get; set; }
    }
}

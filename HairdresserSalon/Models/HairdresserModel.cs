using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Models
{
    public class HairdresserModel
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("Fryzjer")]
        [Required(ErrorMessage ="Podaj imię pracownika")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Proszę używać wyłącznie liter")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }


        public HairdresserModel(Guid id, string name, bool isDeleted)
        {
            Id = id;
            Name = name;
            IsDeleted = isDeleted;
        }

        public HairdresserModel()
        {
        }

        public static HairdresserModel Create(Guid id, string name, bool isDeleted)
        {
            HairdresserModel hairdresser = new HairdresserModel(id, name, isDeleted);
            return hairdresser;
        }
    }
}

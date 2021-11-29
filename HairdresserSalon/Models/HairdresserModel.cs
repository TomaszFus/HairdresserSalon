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
        public int Id { get; set; }
        [DisplayName("Imie")]
        public string Name { get; set; }
    }
}

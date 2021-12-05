using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Models
{
    public class ServiceModel
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Cena")]
        public float Price { get; set; }
        public int Duration { get; set; }
    }
}

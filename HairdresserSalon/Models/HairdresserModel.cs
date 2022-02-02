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
        [DisplayName("Imie")]
        public string Name { get; set; }


        public HairdresserModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public HairdresserModel()
        {
        }

        public static HairdresserModel Create(Guid id, string name)
        {
            HairdresserModel hairdresser = new HairdresserModel(id, name);
            return hairdresser;
        }
    }
}

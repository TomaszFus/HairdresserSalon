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
        [DisplayName("Usługa")]
        [Required(ErrorMessage ="Podaj nazwę usługi")]
        public string Name { get; set; }
        [DisplayName("Cena")]
        [Required(ErrorMessage = "Podaj cenę usługi")]
        [Range(1,float.MaxValue,ErrorMessage ="Podana wartość musi być większa od zera")]
        public float Price { get; set; }
        [DisplayName("Czas trwania (minuty)")]
        [Required(ErrorMessage = "Podaj czas trwania usługi")]
        [Range(1, int.MaxValue, ErrorMessage = "Podana wartość musi być większa od zera")]
        public int Duration { get; set; }
        public bool IsDeleted { get; set; }

        public ServiceModel(Guid id, string name, float price, int duration, bool isDeleted)
        {
            Id = id;
            Name = name;
            Price = price;
            Duration = duration;
            IsDeleted = isDeleted;
        }

        public ServiceModel()
        {                
        }

        public static ServiceModel Create(Guid id, string name, float price, int duration, bool isDeleted)
        {
            ServiceModel service = new ServiceModel(id, name, price, duration, isDeleted);
            return service;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Models
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Podaj imię")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Podaj nazwisko")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name ="Telefon")]
        [Required(ErrorMessage = "Podaj telefon")]
        public string PhoneNumber { get; set; }
        public int VisitsCounter { get; set; }

        public CustomerModel()
        {

        }
        public CustomerModel(Guid id, string firstName, string lastName, string email, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            VisitsCounter = 0;
        }

        public static CustomerModel Create(Guid id, string firstName, string lastName, string email, string phoneNumber)
        {
            CustomerModel customer = new CustomerModel(id, firstName, lastName, email, phoneNumber);
            return customer;
        }
    }
}

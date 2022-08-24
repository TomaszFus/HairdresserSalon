using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Information
{
    public class UpdateInformation : ICommand
    {
        
        public string Street { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        public UpdateInformation(string street, string city, string phoneNumber)
        {
            
            Street = street;
            City = city;
            PhoneNumber = phoneNumber;
        }
    }
}

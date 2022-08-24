using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Customer
{
    public class UpdatePhoneNumber : ICommand
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public UpdatePhoneNumber(Guid id, string phoneNumber)
        {
            Id = id;
            PhoneNumber = phoneNumber;
        }
    }
}

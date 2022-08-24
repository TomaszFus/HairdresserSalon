using Convey.CQRS.Commands;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Customer.Handlers
{
    public class UpdatePhoneNumberHandler : ICommandHandler<UpdatePhoneNumber>
    {
        private readonly ICustomerRepository _customerRepository;
        public UpdatePhoneNumberHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task HandleAsync(UpdatePhoneNumber command)
        {
            await _customerRepository.UpdatePhone(command.Id, command.PhoneNumber);
        }
    }
}

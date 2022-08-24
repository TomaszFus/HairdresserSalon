using Convey.CQRS.Commands;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Customer.Handlers
{
    public class UpdateEmailHandler : ICommandHandler<UpdateEmail>
    {
        private readonly ICustomerRepository _customerRepository;
        public UpdateEmailHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task HandleAsync(UpdateEmail command)
        {
            await _customerRepository.UpdateEmail(command.Id, command.Email);
        }
    }
}

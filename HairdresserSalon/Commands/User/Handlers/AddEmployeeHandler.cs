using Convey.CQRS.Commands;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.User.Handlers
{
    public class AddEmployeeHandler : ICommandHandler<AddEmployee>
    {
        private readonly IUserRepository _userRepository;
        public AddEmployeeHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task HandleAsync(AddEmployee command)
        {
            command.AppUser.Employee = true;
            await _userRepository.UpdateEmployee(command.AppUser);
        }
    }
}

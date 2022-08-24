using Convey.CQRS.Commands;
using HairdresserSalon.Areas.Identity.Data;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.User.Handlers
{
    public class ChangeAdminStatusHandler : ICommandHandler<ChangeAdminStatus>
    {
        private readonly IUserRepository _userRepository;
        public ChangeAdminStatusHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task HandleAsync(ChangeAdminStatus command)
        {
            AppUser appUser = GetUser(command.Id).Result;
            appUser.Admin = !appUser.Admin;
            await _userRepository.UpdateEmployee(appUser);
        }

        public async Task<AppUser> GetUser(Guid id)
        {
            return await _userRepository.GetUser(id);
        }
    }
}

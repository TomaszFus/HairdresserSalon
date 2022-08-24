using Convey.CQRS.Queries;
using HairdresserSalon.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.User.Handlers
{
    public class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<IdentityUser>>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<IdentityUser>> HandleAsync(GetUsers query)
        {
            return await _userRepository.GetUsers();
        }
    }
}

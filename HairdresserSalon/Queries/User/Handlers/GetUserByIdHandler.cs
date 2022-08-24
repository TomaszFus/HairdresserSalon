using Convey.CQRS.Queries;
using HairdresserSalon.Areas.Identity.Data;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.User.Handlers
{
    public class GetUserByIdHandler : IQueryHandler<GetUserById, AppUser>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AppUser> HandleAsync(GetUserById query)
        {
            return await _userRepository.GetUser(query.Id);
        }
    }
}

using HairdresserSalon.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetUsers();
        Task<IEnumerable<AppUser>> GetEmployees();
        Task UpdateEmployee(AppUser appUser);
        Task<AppUser> GetUser(Guid id);
        

    }
}

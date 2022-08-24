using HairdresserSalon.Areas.Identity.Data;
using HairdresserSalon.Data;
using HairdresserSalon.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _context;
        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<AppUser>> GetEmployees()
        {
            return await _context.Users.Where(x => x.Employee == true).ToListAsync();
        }

        public async Task UpdateEmployee(AppUser appUser)
        {
            _context.Users.Update(appUser);
            await _context.SaveChangesAsync();
            
        }

        public async Task<AppUser> GetUser(Guid id)
        {
            return await _context.Users.Where(x => x.Id == id.ToString()).SingleOrDefaultAsync();
        }
    }
}

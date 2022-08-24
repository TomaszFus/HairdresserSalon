using Convey.CQRS.Commands;
using HairdresserSalon.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.User
{
    public class AddEmployee : ICommand
    {
        public AppUser AppUser { get; set; }
        public AddEmployee(AppUser appUser)
        {
            AppUser = appUser;
        }
    }
}

using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.User
{
    public class ChangeAdminStatus : ICommand
    {
        public Guid Id { get; set; }
        public ChangeAdminStatus(Guid id)
        {
            Id = id;
        }
    }
}

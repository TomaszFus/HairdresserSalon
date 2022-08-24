using Convey.CQRS.Queries;
using HairdresserSalon.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.User
{
    public class GetUserById : IQuery<AppUser>
    {
        public Guid Id { get; set; }
    }
}

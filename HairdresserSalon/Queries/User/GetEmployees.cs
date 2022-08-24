using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HairdresserSalon.Queries.User
{
    public class GetEmployees : IQuery<IEnumerable<IdentityUser>>
    {
    }
}

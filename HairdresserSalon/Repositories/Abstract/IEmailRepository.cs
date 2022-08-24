using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Abstract
{
    public interface IEmailRepository
    {
        void SendEmail(string email, string subject, string htmlString);
    }
}

using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Abstract
{
    public interface IHairdresserRepository
    {
        void AddHairdresser(HairdresserModel hairdresser);

        IEnumerable<HairdresserModel> GetAllHairdressers();
    }
}

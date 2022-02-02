using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Abstract
{
    public interface IHairdresserRepository
    {
        Task AddHairdresser(HairdresserModel hairdresser);

        Task<IEnumerable<HairdresserModel>> GetAllHairdressers();
        Task<HairdresserModel> GetHairdresser(Guid id);
    }
}

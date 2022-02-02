using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Abstract
{
    public interface IDayRepository
    {
        Task<IEnumerable<DayModel>> GetAllDays();
        Task<IEnumerable<DayModel>> GetAllDaysForHairdresser(Guid id);
        Task AddDay(DayModel day);
        Task<DayModel> GetDay(Guid id);
        
    }
}

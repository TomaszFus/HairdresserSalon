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
        Task<DayModel> GetDayWithHairdresserAndHours(Guid id);
        Task<DayModel> GetDayWithAvailableHours(Guid id);
        Task<DayModel> GetDayWithHairdresser(Guid id);
        Task<IEnumerable<DayModel>> GetAvailableDates();
        Task<DayModel> GetDay(Guid id);


    }
}

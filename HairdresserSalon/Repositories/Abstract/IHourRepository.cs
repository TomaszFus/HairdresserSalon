using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Abstract
{
    public interface IHourRepository
    {
        Task AddHour(HourModel hour);
        Task<HourModel> GetHour(Guid id);
        Task Update(HourModel hour);
        Task<IEnumerable<HourModel>> GetHoursForDay(Guid dayId);
        Task Delete(Guid id);
    }
}

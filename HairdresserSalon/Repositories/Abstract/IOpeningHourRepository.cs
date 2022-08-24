using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Abstract
{
    public interface IOpeningHourRepository
    {
        Task<OpeningHourModel> GetHour(int id);
        Task Update(int id, OpeningHourModel openingHourModel);
    }
}

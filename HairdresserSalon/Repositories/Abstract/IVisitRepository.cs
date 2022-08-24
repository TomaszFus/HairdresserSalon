using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Abstract
{
    public interface IVisitRepository
    {
        Task AddVisit(VisitModel visit);
        Task<IEnumerable<VisitModel>> GetAllVisits();
        Task<VisitModel> GetVisitDetails(Guid id);
        Task<IEnumerable<VisitModel>> GetVisitsForCustomer(Guid id);
        Task<IEnumerable<VisitModel>> GetVisitsHistory(Guid id);
        Task CancelVisit(Guid id);
        Task EndVisit(Guid id);
        Task Discount(Guid id);
        Task AddOpinion(VisitModel visit);
        Task<IEnumerable<VisitModel>> VisitsArchive();
        Task<IEnumerable<VisitModel>> GetVisitsForHairdresser(Guid id);
    }
}

using Convey.CQRS.Commands;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Visit.Handlers
{
    public class CancelVisitHandler : ICommandHandler<CancelVisit>
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IHourRepository _hourRepository;
        private readonly IEmailRepository _emailRepository;
        private string subject;
        private string message;

        public CancelVisitHandler(IVisitRepository visitRepository, IHourRepository hourRepository, IEmailRepository emailRepository)
        {
            _visitRepository = visitRepository;
            _hourRepository = hourRepository;
            _emailRepository = emailRepository;
        }

        public async Task HandleAsync(CancelVisit command)
        {
            VisitModel visit = GetVisit(command.VisitId).Result;
            var hours = GetHours(visit.Date.Day.Id).Result;
            var hoursToUpdate = await HourToUpdate(hours.ToList(), visit.Date, visit.Service.Duration);
            await UpdateHours(hoursToUpdate);
            await _visitRepository.CancelVisit(command.VisitId);
            // 1 klient
            // 2 zakład
            if (command.Source == 2)
            {
                subject = "Wizyta odwołana";
                message = $"Przepraszamy, ale twoja wizyta <b>{visit.Date.Day.Date.ToString("d")}</b> o godzinie <b>{visit.Date.Hour.ToString("t")}</b> musiała zostać odwołana. Przepraszamy za utrudnienia.";
                if (visit.Customer.Email!=null)
                {
                    _emailRepository.SendEmail(visit.Customer.Email, subject, message);
                }
                
            }

        }


        public async Task<VisitModel> GetVisit(Guid id)
        {
            return await _visitRepository.GetVisitDetails(id);
        }

        public async Task<IEnumerable<HourModel>> GetHours(Guid id)
        {
            var hours = await _hourRepository.GetHoursForDay(id);
            hours = hours.OrderBy(x => x.Hour).ToList();
            return hours;
        }

        public async Task<IEnumerable<HourModel>> HourToUpdate(List<HourModel> hours, HourModel date, int duration)
        {
            List<HourModel> toUpdate = new List<HourModel>();

            int index = hours.IndexOf(date);
            for (int i = index; i < hours.Count; i++)
            {
                if (hours[i].Hour < date.Hour.AddMinutes(duration))
                {
                    toUpdate.Add(hours[i]);
                }

            }
            return toUpdate;
        }

        public async Task UpdateHours(IEnumerable<HourModel> hours)
        {
            foreach (var hour in hours)
            {
                hour.Available = !hour.Available;
                await _hourRepository.Update(hour);
            }
        }
    }
}

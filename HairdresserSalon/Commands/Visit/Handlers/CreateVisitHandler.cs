using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;

namespace HairdresserSalon.Commands.Visit.Handlers
{
    static class Test
    {
        public static bool a;
    }
    public class CreateVisitHandler : ICommandHandler<CreateVisit>
    {
        private readonly IVisitRepository _visitRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IHairdresserRepository _hairdresserRepository;
        private readonly IHourRepository _hourRepository;
        private readonly IEmailRepository _email;
        private string subject = "Potwierdzenie wizyty";
        private string message;
        

        public CreateVisitHandler(IVisitRepository visitRepository, ICustomerRepository customerRepository, IServiceRepository serviceRepository,
            IHairdresserRepository hairdresserRepository, IHourRepository hourRepository, IEmailRepository email)
        {
            _visitRepository = visitRepository;
            _customerRepository = customerRepository;
            _serviceRepository = serviceRepository;
            _hairdresserRepository = hairdresserRepository;
            _hourRepository = hourRepository;
            _email = email;
            
        }
        public async Task HandleAsync(CreateVisit command)
        {
            Test.a = false;
            VisitModel visit = command.Visit;
            ServiceModel service = GetService(command.ServiceId).Result;
            CustomerModel customer = GetCustomer(command.UserId).Result;
            visit.Service = service;
            visit.Price = service.Price;
            visit.Customer = customer;
            visit.Hairdresser = GetHairdresser(command.HairdresserId).Result;
            var date = GetDate(command.DateId).Result;
            var hours = GetHours(date.Day.Id).Result;
            visit.Date = date;
            var hoursToUpdate = await HourToUpdate(hours.ToList(), date, service.Duration);
            var check = hoursToUpdate.Where(x=>x.Available==false).ToList();
            message = $"Potwierdzenie Twojej wizyty. <b>Termin</b> {visit.Date.Day.Date.ToString("d")} {visit.Date.Hour.ToString("t")} \n<b>Wybrana usługa</b>: {visit.Service.Name} \n<b>Do zapłaty</b>: {visit.Service.Price}";
            if (check.Count==0)
            {
                Test.a = true;
                await UpdateHours(hoursToUpdate);
                await _visitRepository.AddVisit(visit);
                if (customer.Email!=null)
                {
                    _email.SendEmail(customer.Email, subject, message);
                }
                
            }
                     
            



        }

        public async Task<ServiceModel> GetService(Guid id)
        {
            return await _serviceRepository.Get(id);
        }

        public async Task<CustomerModel> GetCustomer(Guid id)
        {
            return await _customerRepository.GetCustomer(id);
        }

        public async Task<HairdresserModel> GetHairdresser(Guid id)
        {
            return await _hairdresserRepository.GetHairdresser(id);
        }
        public async Task<HourModel> GetDate(Guid id)
        {
            return await _hourRepository.GetHour(id);
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

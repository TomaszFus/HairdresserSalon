using Convey.CQRS.Commands;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Commands.Visit.Handlers
{
    public class EndVisitHandler : ICommandHandler<EndVisit>
    {
        private readonly IVisitRepository _visitRepository;
        private readonly ICustomerRepository _customerRepository;
        public EndVisitHandler(IVisitRepository visitRepository, ICustomerRepository customerRepository)
        {
            _visitRepository = visitRepository;
            _customerRepository = customerRepository;
        }
        public async Task HandleAsync(EndVisit command)
        {
            VisitModel visit = GetVisit(command.VisitId).Result;
            CustomerModel customer = GetCustomer(visit.Customer.Id).Result;
            await _visitRepository.EndVisit(command.VisitId);
            if (visit.Customer.VisitsCounter%10==0)
            {
                await _visitRepository.Discount(command.VisitId);
            }
            await _customerRepository.IncreaseVisitCounter(customer.Id);
        }

        public async Task<VisitModel> GetVisit(Guid id)
        {
            return await _visitRepository.GetVisitDetails(id);
        }

        public async Task<CustomerModel> GetCustomer(Guid id)
        {
            return await _customerRepository.GetCustomer(id);
        }

        
    }
}

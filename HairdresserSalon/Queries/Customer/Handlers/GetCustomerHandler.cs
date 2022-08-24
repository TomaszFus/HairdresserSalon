using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;

namespace HairdresserSalon.Queries.Customer.Handlers
{
    public class GetCustomerHandler : IQueryHandler<GetCustomer, CustomerModel>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<CustomerModel> HandleAsync(GetCustomer query)
        {
            return await _customerRepository.GetCustomer(query.Id);
        }
    }
}

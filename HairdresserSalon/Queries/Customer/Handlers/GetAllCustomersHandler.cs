using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Queries.Customer.Handlers
{
    public class GetAllCustomersHandler : IQueryHandler<GetAllCustomers, IEnumerable<CustomerModel>>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetAllCustomersHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IEnumerable<CustomerModel>> HandleAsync(GetAllCustomers query)
        {
            return await _customerRepository.GetAllCustomers();
        }
    }
}

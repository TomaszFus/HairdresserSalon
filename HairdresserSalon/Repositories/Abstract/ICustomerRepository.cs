using HairdresserSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Abstract
{
    public interface ICustomerRepository
    {
        Task AddCustomer(CustomerModel customer);
        Task<CustomerModel> GetCustomer(Guid id);
        Task<IEnumerable<CustomerModel>> GetAllCustomers();
        Task IncreaseVisitCounter(Guid id);
        Task UpdatePhone(Guid id, string number);
        Task UpdateEmail(Guid id, string email);
    }
}

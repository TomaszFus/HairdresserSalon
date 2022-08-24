using HairdresserSalon.Data;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HairdresserDbContext _context;
        public CustomerRepository(HairdresserDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomer(CustomerModel customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<CustomerModel> GetCustomer(Guid id)
        {
            return await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task IncreaseVisitCounter(Guid id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            customer.VisitsCounter += 1;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmail(Guid id, string email)
        {
            var customer = _context.Customers.SingleOrDefaultAsync(x => x.Id == id).Result;
            if (customer != null)
            {
                customer.Email = email;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePhone(Guid id, string number)
        {
            var customer = _context.Customers.SingleOrDefaultAsync(x => x.Id == id).Result;
            if (customer != null)
            {
                customer.PhoneNumber = number;
                await _context.SaveChangesAsync();
            }
            
        }
    }
}

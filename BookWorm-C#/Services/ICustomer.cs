using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookWorm_C_.Entities; // Update the namespace to match your entity's namespace

namespace BookWorm_C_.Services
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(Customer customer);

        Task<Customer> GetCustomerByIdAsync(long id);
    }

}
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookWorm_C_.Entities; // Update the namespace to match your entity's namespace
//using BookWorm_C_.Repositories; // Update the namespace to match your repository's namespace

namespace BookWorm_C_.Services
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly BookWormContext _context;

        public SQLCustomerRepository(BookWormContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(long id)
        {
            return await _context.Customers.FindAsync(id);
        }
    }
}

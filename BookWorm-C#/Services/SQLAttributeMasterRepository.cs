//using BookWorm_C_.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookWorm_C_.Entities; // Update the namespace to match your entity's namespace

namespace BookWorm_C_.Services
{
    public class SQLAttributeMasterRepository : IAttributeMasterRepository
    {
        private readonly BookWormContext _context;

        public SQLAttributeMasterRepository(BookWormContext context)
        {
            _context = context;
        }

        public async Task<List<AttributeMaster>> GetAllAttributeAsync()
        {
            return await _context.AttributeMasters.ToListAsync();
        }

        public async Task AddAttributeAsync(AttributeMaster a)
        {
            _context.AttributeMasters.Add(a);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var attribute = await _context.AttributeMasters.FindAsync(id);
            if (attribute != null)
            {
                _context.AttributeMasters.Remove(attribute);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(AttributeMaster a, long id)
        {
            var attributeToUpdate = await _context.AttributeMasters.FindAsync(id);
            if (attributeToUpdate != null)
            {
                attributeToUpdate.AttributeDesc = a.AttributeDesc;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }
    }

}
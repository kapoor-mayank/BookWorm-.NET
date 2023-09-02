using BookWorm_C_.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWorm_C_.Services
{
    public interface IAttributeMasterRepository
    {
        Task<List<AttributeMaster>> GetAllAttributeAsync();
        Task AddAttributeAsync(AttributeMaster a);
        Task DeleteAsync(long id);
        Task UpdateAsync(AttributeMaster a, long id);
    }
}


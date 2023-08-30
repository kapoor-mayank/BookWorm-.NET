using Microsoft.EntityFrameworkCore;
using ProductTypeMasterWorm.Models;

namespace BookWorm.Models
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        { 
        }
        

        
        public DbSet<ProductTypeMaster>ProductTypeMaster{ get; set; }
        public DbSet<PublisherMaster> PublisherMaster { get; set; }
        


    }
}

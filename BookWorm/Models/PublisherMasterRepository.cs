using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookWorm.Models
{
    public class PublisherMasterRepository:IPublisherMaster
    {
        private readonly AppDbContext context;

        public PublisherMasterRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<PublisherMaster>> Add(PublisherMaster publishermaster)
        {
            context.PublisherMaster.Add(publishermaster);
            await context.SaveChangesAsync();
            return publishermaster;


        }

        public async Task<PublisherMaster> Delete(long Id)
        {
            PublisherMaster publishermaster = context.PublisherMaster.Find(Id);
            if (publishermaster != null)
            {
                context.Remove(publishermaster);
                await context.SaveChangesAsync();
            }
            return publishermaster;
        }

        public async Task<ActionResult<IEnumerable<PublisherMaster>>> GetAllPublisherMaster()
        {
            if (context.PublisherMaster == null)
            {
                return null;

            }
            return await context.PublisherMaster.ToListAsync();

        }

        

        public async Task<ActionResult<PublisherMaster>?> GetPublisherMaster(long Id)
        {
            if (context.PublisherMaster == null)
            {
                return null;
            }
            var publishermaster = await context.PublisherMaster.FindAsync(Id);
            if (publishermaster == null)
            {
                return null;
            }
            return publishermaster;



        }

        public async Task<PublisherMaster> Update(long id, PublisherMaster publishermaster)
        {
            if (id != publishermaster.publisherId)
            {
                return null;
            }
            context.Entry(publishermaster).State = EntityState.Modified;

            try
            {
                context.Update(publishermaster);
                await context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherMasterExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }

            }
            return null;

        }
        private bool PublisherMasterExists(long id)
        {
            return (context.PublisherMaster?.Any(e => e.publisherId == id)).GetValueOrDefault();
        }
    }
}

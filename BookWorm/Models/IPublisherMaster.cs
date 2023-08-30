using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Models
{
    public interface IPublisherMaster
    {
       
        
            Task<ActionResult<PublisherMaster>?> GetPublisherMaster(long Id);
            Task<ActionResult<IEnumerable<PublisherMaster>>> GetAllPublisherMaster();
            Task<ActionResult<PublisherMaster>> Add(PublisherMaster publishermaster);
            Task<PublisherMaster> Update(long id, PublisherMaster publishermaster);
            Task<PublisherMaster> Delete(long Id);
           
        
    }
}

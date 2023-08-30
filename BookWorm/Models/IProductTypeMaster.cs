using Microsoft.AspNetCore.Mvc;

namespace ProductTypeMasterWorm.Models
{
    public interface IProductTypeMaster
    {
        Task<ActionResult<ProductTypeMaster>?> GetProductTypeMaster(long Id);
        Task<ActionResult<IEnumerable<ProductTypeMaster>>> GetAllProductTypeMaster();
        Task<ActionResult<ProductTypeMaster>> Add(ProductTypeMaster ProductTypeMaster);
        Task<ProductTypeMaster> Update(long id, ProductTypeMaster ProductTypeMaster);
        Task<ProductTypeMaster> Delete(long Id);
       // ActionResult<IEnumerable<dynamic>> GetByName(string name);
    }
}

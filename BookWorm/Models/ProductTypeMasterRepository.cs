using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductTypeMasterWorm.Models;

namespace BookWorm.Models
{
    public class ProductTypeMasterRepository : IProductTypeMaster
    {   
        private readonly AppDbContext context;

        public ProductTypeMasterRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<ProductTypeMaster>> Add(ProductTypeMaster producttypemaster)
        { 
            context.ProductTypeMaster.Add(producttypemaster);
            await context.SaveChangesAsync();
            return producttypemaster;


        }

        public async Task<ProductTypeMaster> Delete(long Id)
        { 
            ProductTypeMaster producttypemaster=context.ProductTypeMaster.Find(Id);
            if ( producttypemaster!=null)
            { 
                context.Remove(producttypemaster);
                await context.SaveChangesAsync();
            }
            return producttypemaster;
        }

        public async Task<ActionResult<IEnumerable<ProductTypeMaster>>> GetAllProductTypeMaster()
        {   
            if(context.ProductTypeMaster == null)
            {
                return null;

            }
            return await context.ProductTypeMaster.ToListAsync();

        }

       // public ActionResult<IEnumerable<dynamic>> GetName(string name)
       // {
       //     throw new NotImplementedException();
       // }

        public  async Task<ActionResult<ProductTypeMaster>?> GetProductTypeMaster(long Id)
        {   
            if(context.ProductTypeMaster == null)
            {
                return null;
            }
            var producttypemaster =  await context.ProductTypeMaster.FindAsync(Id);
            if(producttypemaster == null)
            {
                return null;
            }
            return producttypemaster;



        }

        public async Task<ProductTypeMaster> Update(long id, ProductTypeMaster producttypemaster)
        {
           if(id != producttypemaster.typeId)
            {
                return null;
            }
           context.Entry(producttypemaster).State = EntityState.Modified;

            try {
                context.Update(producttypemaster);
              await  context.SaveChangesAsync();
            }

            catch  (DbUpdateConcurrencyException) 
            { 
                 if( !ProductTypeMasterExists(id))
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
        private bool ProductTypeMasterExists(long id)
        {
            return (context.ProductTypeMaster?.Any(e => e.typeId == id)).GetValueOrDefault();
        }
    }
}

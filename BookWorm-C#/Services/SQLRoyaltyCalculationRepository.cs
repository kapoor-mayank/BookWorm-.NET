using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace BookWorm_C_.Services
{
    public class SQLRoyaltyCalculationRepository : IRoyaltyCalculation
    {
        private readonly BookWormContext context;

        public SQLRoyaltyCalculationRepository(BookWormContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<RoyaltyCalculation>> AddRoyalty(RoyaltyCalculation royalty)
        {
            context.RoyaltyCalculations.Add(royalty);
            context.SaveChangesAsync();
            return royalty;

        }

        public async Task<ActionResult<List<RoyaltyCalculation>>> GetByBeneficiary(long benId)
        {
            var royalties = context.RoyaltyCalculations
          .FromSqlRaw("SELECT * FROM RoyaltyCalculations WHERE ben_id = {0}", benId)
          .ToList();

            return royalties;
        }

        public async Task<ActionResult<List<RoyaltyCalculation>>> GetByInvoice(long invoiceId)
        {
            var royalties = context.RoyaltyCalculations
          .FromSqlRaw("SELECT * FROM RoyaltyCalculations WHERE RoyaltyId = {0}", invoiceId)
          .ToList();

            return royalties;
        }

        public async Task<ActionResult<List<RoyaltyCalculation>>> GetByProduct(long productId)
        {


            var royalties = context.RoyaltyCalculations
          .FromSqlRaw("SELECT * FROM RoyaltyCalculations WHERE ProductId = {0}", productId)
          .ToList();

            return royalties;
        }

        public async Task<ActionResult<List<RoyaltyCalculation>>> GetRoyalties()
        {
            if (context.RoyaltyCalculations == null)
            {
                return null;

            }
            return await context.RoyaltyCalculations.ToListAsync();
        }
    }
}

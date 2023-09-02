using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_C_.Services
{
    public interface IRoyaltyCalculation
    {
        Task<ActionResult<RoyaltyCalculation>> AddRoyalty(RoyaltyCalculation royalty);
        Task<ActionResult<List<RoyaltyCalculation>>> GetByBeneficiary(long benId);
        Task<ActionResult<List<RoyaltyCalculation>>> GetByProduct(long productId);
        Task<ActionResult<List<RoyaltyCalculation>>> GetByInvoice(long invoiceId);
        Task<ActionResult<List<RoyaltyCalculation>>> GetRoyalties();

    }
}
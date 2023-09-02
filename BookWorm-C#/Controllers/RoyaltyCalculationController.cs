using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWorm_C_.Services
{
    [ApiController]
    [Route("api/royalty")] // Change the route as needed
    [EnableCors("*")]

    public class RoyaltyCalculationController : ControllerBase
    {
        private readonly IRoyaltyCalculation _royaltyRepository;

        public RoyaltyCalculationController(IRoyaltyCalculation royaltyRepository)
        {
            _royaltyRepository = royaltyRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRoyalty([FromBody] RoyaltyCalculation royalty)
        {
            var addedRoyalty = await _royaltyRepository.AddRoyalty(royalty);
            return Ok(addedRoyalty);
        }

        [HttpGet("beneficiary/{benId}")]
        public async Task<IActionResult> GetByBeneficiary(long benId)
        {
            var royalties = await _royaltyRepository.GetByBeneficiary(benId);
            return Ok(royalties);
        }

        [HttpGet("invoice/{invoiceId}")]
        public async Task<IActionResult> GetByInvoice(long invoiceId)
        {
            var royalties = await _royaltyRepository.GetByInvoice(invoiceId);
            return Ok(royalties);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(long productId)
        {
            var royalties = await _royaltyRepository.GetByProduct(productId);
            return Ok(royalties);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetRoyalties()
        {
            var royalties = await _royaltyRepository.GetRoyalties();
            return Ok(royalties);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using BookWorm_C_.Entities;
using BookWorm_C_.Services;
using Microsoft.AspNetCore.Cors;

namespace BookWorm_C_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("*")]
    public class BeneficiaryController : ControllerBase
    {
        private readonly IBeneficiaryRepository _beneficiaryRepository;

        public BeneficiaryController(IBeneficiaryRepository beneficiaryRepository)
        {
            _beneficiaryRepository = beneficiaryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Beneficiary>> GetAllBeneficiaries()
        {
            var beneficiaries = _beneficiaryRepository.GetAllBeneficiaries();
            return Ok(beneficiaries);
        }

        [HttpGet("{id}")]
        public ActionResult<Beneficiary> GetBeneficiaryById(long id)
        {
            var beneficiary = _beneficiaryRepository.GetBeneficiaryById(id);
            if (beneficiary == null)
            {
                return NotFound();
            }
            return Ok(beneficiary);
        }

        [HttpPost]
        public ActionResult<Beneficiary> AddBeneficiary(Beneficiary beneficiary)
        {
            _beneficiaryRepository.AddBeneficiary(beneficiary);
            return CreatedAtAction(nameof(GetBeneficiaryById), new { id = beneficiary.BeneficiaryId }, beneficiary);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBeneficiary(long id, Beneficiary beneficiary)
        {
            if (id != beneficiary.BeneficiaryId)
            {
                return BadRequest();
            }

            _beneficiaryRepository.UpdateBeneficiary(beneficiary);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBeneficiary(long id)
        {
            var beneficiary = _beneficiaryRepository.GetBeneficiaryById(id);
            if (beneficiary == null)
            {
                return NotFound();
            }

            _beneficiaryRepository.DeleteBeneficiary(id);
            return NoContent();
        }
    }
}

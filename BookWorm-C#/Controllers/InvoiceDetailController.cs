using BookWorm_C_.Entities;
using BookWorm_C_.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_C_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("*")]
    public class InvoiceDetailController : Controller
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;

        public InvoiceDetailController(IInvoiceDetailRepository _invoiceDetailRepository)
        {
            _invoiceDetailRepository = _invoiceDetailRepository;
        }

        [HttpGet("{invDtlId}")]
        public ActionResult<InvoiceDetail> GetByInvDtlId(long invDtlId)
        {
            var result = _invoiceDetailRepository.GetByInvDtlId(invDtlId);

            if (!result.HasValue)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public ActionResult<IEnumerable<InvoiceDetail>> GetAllInvoiceDetails()
        {
            var invoiceDetails = _invoiceDetailRepository.GetAllInvoiceDetails();
            return Ok(invoiceDetails);
        }

        [HttpGet("basePrice/{basePrice}")]
        public ActionResult<IEnumerable<InvoiceDetail>> GetByBasePrice(double basePrice)
        {
            var invoiceDetails = _invoiceDetailRepository.GetByBasePrice(basePrice);
            return Ok(invoiceDetails);
        }

        [HttpGet("tranType/{tranType}")]
        public ActionResult<IEnumerable<InvoiceDetail>> GetByTranType(string tranType)
        {
            var invoiceDetails = _invoiceDetailRepository.GetByTranType(tranType);
            return Ok(invoiceDetails);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInvoiceDetails(long id)
        {
            var result = _invoiceDetailRepository.DeleteInvoiceDetailsById(id);

            if (!result.HasValue)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult AddInvoiceDetails(InvoiceDetail invoiceDetails)
        {
            _invoiceDetailRepository.SetInvoiceDetails(invoiceDetails);
            return CreatedAtAction(nameof(GetByInvDtlId), new { invDtlId = invoiceDetails.InvoiceDetailId }, invoiceDetails);
        }

        [HttpPut("{id}/updateQuantity")]
        public IActionResult UpdateQuantity(long id, InvoiceDetail invoiceDetails)
        {
            var result = _invoiceDetailRepository.UpdateQuantity(id, invoiceDetails);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id}/updateTranType")]
        public IActionResult UpdateTranType(long id, InvoiceDetail invoiceDetails)
        {
            var result = _invoiceDetailRepository.UpdateTranType(id, invoiceDetails);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

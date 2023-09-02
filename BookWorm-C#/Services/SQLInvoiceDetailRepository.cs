using BookWorm_C_.Entities;
using Microsoft.CodeAnalysis;

namespace BookWorm_C_.Services
{
    public class SQLInvoiceDetailRepository : IInvoiceDetailRepository
    {
        private List<InvoiceDetail> _invoiceDetailList = new List<InvoiceDetail>();
        public Optional<InvoiceDetail> DeleteInvoiceDetailsById(long id)
        {
            var invoiceDetail = _invoiceDetailList.FirstOrDefault(i => i.InvoiceDetailId == id);
            if (invoiceDetail != null)
            {
                _invoiceDetailList.Remove(invoiceDetail);
                return new Optional<InvoiceDetail>(invoiceDetail);
            }
            return new Optional<InvoiceDetail>(null);
        }

        public List<InvoiceDetail> GetAllInvoiceDetails()
        {
            return _invoiceDetailList;
        }

        public List<InvoiceDetail> GetByBasePrice(double basePrice)
        {
            return _invoiceDetailList.Where(i => i.BasePrice == basePrice).ToList();
        }

        public Optional<InvoiceDetail> GetByInvDtlId(long invDtlId)
        {
            var invoiceDetail = _invoiceDetailList.FirstOrDefault(i => i.InvoiceDetailId == invDtlId);
            return invoiceDetail != null ? new Optional<InvoiceDetail>(invoiceDetail) : new Optional<InvoiceDetail>(null);
        }

        public List<InvoiceDetail> GetByTranType(string tranType)
        {
            return _invoiceDetailList.Where(i => i.TranType == tranType).ToList();
        }

        public void SetInvoiceDetails(InvoiceDetail invDetails)
        {
            _invoiceDetailList.Add(invDetails);
        }

        public InvoiceDetail UpdateQuantity(long id, InvoiceDetail invDetails)
        {
            var invoiceDetail = _invoiceDetailList.FirstOrDefault(i => i.InvoiceDetailId == id);
            if (invoiceDetail != null)
            {
                invoiceDetail.Quantity = invDetails.Quantity;
            }
            return invoiceDetail;
        }

        public InvoiceDetail UpdateTranType(long id, InvoiceDetail invDetails)
        {
            var invoiceDetail = _invoiceDetailList.FirstOrDefault(i => i.InvoiceDetailId == id);
            if (invoiceDetail != null)
            {
                invoiceDetail.TranType = invDetails.TranType;
            }
            return invoiceDetail;
        }
    }
}

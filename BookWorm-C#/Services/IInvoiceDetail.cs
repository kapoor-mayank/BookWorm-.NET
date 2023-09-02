using BookWorm_C_.Entities;
using Microsoft.CodeAnalysis;

namespace BookWorm_C_.Services
{
    public interface IInvoiceDetailRepository
    {


        Optional<InvoiceDetail> GetByInvDtlId(long InvoiceDetailId);

        List<InvoiceDetail> GetAllInvoiceDetails();

        List<InvoiceDetail> GetByBasePrice(double basePrice);

        List<InvoiceDetail> GetByTranType(string tranType);

        Optional<InvoiceDetail> DeleteInvoiceDetailsById(long id);

        void SetInvoiceDetails(InvoiceDetail invDetails);

        InvoiceDetail UpdateQuantity(long id, InvoiceDetail invDetails);

        InvoiceDetail UpdateTranType(long id, InvoiceDetail invDetails);
    }
}

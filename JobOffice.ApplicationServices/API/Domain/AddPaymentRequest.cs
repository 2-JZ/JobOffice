using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
   
    public class AddPaymentRequest : IRequest<AddPaymentResponse>
    {
        // Amount to be paid (in your base currency)
        public decimal Amount { get; set; }

        // The PaymentMethodId from the client (e.g., Stripe's "pm_xxx" identifier)
        public string PaymentMethodId { get; set; }

        // Optional: Associate payment with an invoice or order (if applicable)
        public int? InvoiceId { get; set; }

        // Optional: Track the customer making the payment
        public string CustomerId { get; set; }
    }
}


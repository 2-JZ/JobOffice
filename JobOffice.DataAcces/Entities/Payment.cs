

namespace JobOffice.DataAcces.Entities
{
    public class Payment : EntityBase
    {

        // Stripe's PaymentIntent ID
        public string PaymentIntentId { get; set; }

        // Total amount paid (in your base currency, e.g., USD)
        public decimal Amount { get; set; }

        // The status of the payment (e.g., 'Succeeded', 'Failed', 'Pending', etc.)
        public string Status { get; set; }

        // Optional: Store the PaymentMethodId used to process the payment
        public string PaymentMethodId { get; set; }

        // DateTime the payment was created in your system
        public DateTime CreatedAt { get; set; }

        // Optional: You can associate the payment with an invoice or order (add a relationship)
        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; } // Navigation property (if you have an Invoice entity)

        // Optional: Add a reference to the user or customer who made the payment
        public string CustomerId { get; set; }
    }

}
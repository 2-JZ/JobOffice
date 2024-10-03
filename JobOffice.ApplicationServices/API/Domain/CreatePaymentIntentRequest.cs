using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class CreatePaymentIntentRequest : RequestBase, IRequest<CreatePaymentIntentResponse>
    {
        public string PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "usd"; // Domyślna waluta
    }
}

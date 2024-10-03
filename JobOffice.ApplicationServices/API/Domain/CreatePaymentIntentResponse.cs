using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class CreatePaymentIntentResponse : ResponseBase<PaymentIntentResult>
    {
    }
}

public class PaymentIntentResult
{
    public string ClientSecret { get; set; }
}

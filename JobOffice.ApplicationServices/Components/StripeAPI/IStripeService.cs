using Stripe;
using System.Threading.Tasks;

public interface IStripeService
{
    Task<PaymentIntent> CreatePaymentAsync(string paymentMethodId, decimal amount, string currency);
}

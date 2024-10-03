//using Stripe;
//using System;
//using System.Threading.Tasks;

//public class StripeService : IStripeService
//{
//    public StripeService()
//    {
//        // Retrieve Stripe API key from environment variables
//        var stripeApiKey = Environment.GetEnvironmentVariable("STRIPE_API_KEY");

//        // Throw exception if API key is not set
//        if (string.IsNullOrEmpty(stripeApiKey))
//        {
//            throw new InvalidOperationException("Stripe API key is not set in environment variables.");
//        }

//        // Set the Stripe API key globally for the SDK
//        StripeConfiguration.ApiKey = stripeApiKey;
//    }

//    // Method to create a payment
//    public async Task<Charge> CreatePaymentAsync(string token, decimal amount, string currency)
//    {
//        var options = new ChargeCreateOptions
//        {
//            Amount = (long)(amount * 100),  // Stripe expects amounts in cents
//            Currency = currency,
//            Description = "Invoice Payment",
//            Source = token,  // The token representing the card/payment method
//        };

//        var service = new ChargeService();
//        return await service.CreateAsync(options);
//    }
//}


using Stripe;
using System;
using System.Threading.Tasks;

public class StripeService : IStripeService
{
    public StripeService()
    {
        // Pobieranie Stripe API key ze zmiennych środowiskowych
        var stripeApiKey = Environment.GetEnvironmentVariable("STRIPE_API_KEY");

        if (string.IsNullOrEmpty(stripeApiKey))
        {
            throw new InvalidOperationException("Stripe API key is not set in environment variables.");
        }

        StripeConfiguration.ApiKey = stripeApiKey;
    }

    // Metoda tworzenia płatności przy użyciu Payment Intents API
    public async Task<PaymentIntent> CreatePaymentAsync(string paymentMethodId, decimal amount, string currency)
    {
        var options = new PaymentIntentCreateOptions
        {
            Amount = (long)(amount * 100), // Stripe oczekuje kwoty w centach
            Currency = currency,
            PaymentMethod = paymentMethodId, // Użyj PaymentMethod zamiast tokenu karty
            Confirm = true, // Automatycznie potwierdź transakcję
            // Opcjonalnie, możesz dodać ReturnUrl dla płatności wymagających dodatkowego uwierzytelnienia
            ReturnUrl = "https://localhost:7139/payment-complete"
        };

        var service = new PaymentIntentService();
        return await service.CreateAsync(options);
    }
}

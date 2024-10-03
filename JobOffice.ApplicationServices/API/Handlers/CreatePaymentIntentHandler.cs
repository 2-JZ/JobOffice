//using Microsoft.Extensions.Configuration;
//using Stripe;
//using System.Threading.Tasks;
//using MediatR;
//using JobOffice.ApplicationServices.API.Domain;

//public class CreatePaymentIntentHandler : IRequestHandler<CreatePaymentIntentRequest, CreatePaymentIntentResponse>
//{
//    private readonly IConfiguration configuration;

//    public CreatePaymentIntentHandler(IConfiguration configuration)
//    {
//        this.configuration = configuration;
//    }

//    public async Task<CreatePaymentIntentResponse> Handle(CreatePaymentIntentRequest request, CancellationToken cancellationToken)
//    {
//        // Pobieranie klucza tajnego ze Stripe z konfiguracji
//        var secretKey = configuration["Stripe:SecretKey"];
//        StripeConfiguration.ApiKey = secretKey; // Użycie klucza tajnego

//        var options = new PaymentIntentCreateOptions
//        {
//            Amount = (long)(request.Amount * 100), // Kwota w centach
//            Currency = request.Currency,
//            PaymentMethod = request.PaymentMethodId,
//            Confirm = true,
//            ReturnUrl = "https://localhost:7139/payment-complete", // Your local return URL

//        };

//        var service = new PaymentIntentService();
//        var paymentIntent = await service.CreateAsync(options);

//        var response = new CreatePaymentIntentResponse
//        {
//            Data = new PaymentIntentResult
//            {
//                ClientSecret = paymentIntent.ClientSecret
//            }
//        };

//        return response;
//    }
//}


using JobOffice.ApplicationServices.API.Domain;
using MediatR;

public class CreatePaymentIntentHandler : IRequestHandler<CreatePaymentIntentRequest, CreatePaymentIntentResponse>
{
    private readonly IStripeService stripeService;

    public CreatePaymentIntentHandler(IStripeService stripeService)
    {
        this.stripeService = stripeService;
    }

    public async Task<CreatePaymentIntentResponse> Handle(CreatePaymentIntentRequest request, CancellationToken cancellationToken)
    {
        // Użycie StripeService do utworzenia płatności
        var charge = await stripeService.CreatePaymentAsync(request.PaymentMethodId, request.Amount, request.Currency);

        var response = new CreatePaymentIntentResponse
        {
            Data = new PaymentIntentResult
            {
                ClientSecret = charge.Id // Zwróć ClientSecret lub inną wartość według potrzeb
            }
        };

        return response;
    }
}



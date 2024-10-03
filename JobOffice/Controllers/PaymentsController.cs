using Microsoft.AspNetCore.Mvc;
using Stripe;

//[ApiController]
//[Route("api/[controller]")]
//public class PaymentsController : ControllerBase
//{
//    private readonly IStripeService _stripeService;

//    public PaymentsController(IStripeService stripeService)
//    {
//        _stripeService = stripeService;
//    }

//    [HttpPost]
//    [Route("process-payment")]
//    public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest request)
//    {
//        try
//        {
//            // Call the Stripe service to process the payment
//            var charge = await _stripeService.CreatePaymentAsync(request.Token, request.Amount, request.Currency);

//            return Ok(new { success = true, chargeId = charge.Id });
//        }
//        catch (StripeException ex)
//        {
//            return BadRequest(new { success = false, error = ex.Message });
//        }
//    }
//}

//public class PaymentRequest
//{
//    public string Token { get; set; }  // Stripe token from the frontend (Stripe.js or Elements)
//    public decimal Amount { get; set; }
//    public string Currency { get; set; } = "usd";
//}
using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace JobOffice.Controllers;


[ApiController]
[Route("[controller]")]
public class PaymentsController : ApiControllerBase
{
    public PaymentsController(IMediator mediator, ILogger<PaymentsController> logger) : base(mediator)
    {
    }

    [HttpPost]
    [Route("create-payment-intent")]
    public Task<IActionResult> CreatePaymentIntent([FromBody] CreatePaymentIntentRequest request)
    {
        return this.HandleRequest<CreatePaymentIntentRequest, CreatePaymentIntentResponse>(request);
    }
}


using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stripe;

[ApiController]
[Route("webhooks/stripe")]
public class StripeWebhookController : ControllerBase
{
    private readonly IMediator mediator;

    public StripeWebhookController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Handle()
    {
        var json = await new StreamReader(Request.Body).ReadToEndAsync();

        var stripeEvent = EventUtility.ConstructEvent(
            json,
            Request.Headers["Stripe-Signature"],
            "STRIPE_WEBHOOK_SECRET"
        );

        if (stripeEvent.Type == Events.PaymentIntentSucceeded)
        {
            var paymentIntent = stripeEvent.Data.Object as PaymentIntent;

            //await mediator.Send(new CreateInvoiceFromStripeRequest
            //{
            //    PaymentIntentId = paymentIntent.Id,
            //    Amount = paymentIntent.AmountReceived / 100m,
            //    Currency = paymentIntent.Currency,
            //    Email = paymentIntent.ReceiptEmail
            //});
        }

        return Ok();
    }
}

using Microsoft.AspNetCore.Mvc;
using Stripe;

[ApiController]
[Route("api/webhooks")]
public class StripeWebhookController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Handle()
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

        try
        {
            var stripeEvent = EventUtility.ConstructEvent(
                json,
                Request.Headers["Stripe-Signature"],
                "your_stripe_webhook_secret"
            );

            // Handle the event (e.g., payment success or failure)
            if (stripeEvent.Type == Events.PaymentIntentSucceeded)
            {
                var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                // Handle successful payment (e.g., mark order as paid)
            }
            else if (stripeEvent.Type == Events.PaymentIntentPaymentFailed)
            {
                var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                // Handle payment failure
            }

            return Ok();
        }
        catch (StripeException e)
        {
            return BadRequest();
        }
    }
}

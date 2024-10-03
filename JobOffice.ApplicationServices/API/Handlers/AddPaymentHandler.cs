using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.Entities;
using MediatR;
using Stripe;

public class AddPaymentHandler : IRequestHandler<AddPaymentRequest, AddPaymentResponse>
{
    private readonly ICommandExecutor commandExecutor;
    private readonly IMapper mapper;

    public AddPaymentHandler(ICommandExecutor commandExecutor, IMapper mapper)
    {
        this.commandExecutor = commandExecutor;
        this.mapper = mapper;
    }

    public async Task<AddPaymentResponse> Handle(AddPaymentRequest request, CancellationToken cancellationToken)
    {
        // Initialize Stripe API
        StripeConfiguration.ApiKey = "your_stripe_secret_key";

        // Create a payment intent using Stripe's API
        var options = new PaymentIntentCreateOptions
        {
            Amount = (long)(request.Amount * 100), // Stripe uses amounts in cents
            Currency = "usd",
            PaymentMethod = request.PaymentMethodId,
            Confirm = true
        };

        var service = new PaymentIntentService();
        var paymentIntent = await service.CreateAsync(options);

        // Create a new payment entity
        var payment = new Payment
        {
            PaymentIntentId = paymentIntent.Id,
            Amount = request.Amount,
            Status = paymentIntent.Status,
            PaymentMethodId = request.PaymentMethodId,
            CreatedAt = DateTime.UtcNow
        };

        // Store the payment in the database using CQRS
        var command = new AddPaymentCommand() { Parameter = payment };
        var paymentFromDb = await this.commandExecutor.Execute(command);

        return new AddPaymentResponse
        {
            Data = this.mapper.Map<JobOffice.ApplicationServices.API.Domain.Models.Payment>(paymentFromDb)
        };
    }
}

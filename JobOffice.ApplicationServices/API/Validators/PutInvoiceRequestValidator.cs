using FluentValidation;
using JobOffice.ApplicationServices.API.Domain;

namespace JobOffice.ApplicationServices.API.Validators
{
    public class PutInvoiceRequestValidator : AbstractValidator<PutInvoiceRequest>
    {
        public PutInvoiceRequestValidator()
        {
            this.RuleFor(x => x.InvoiceIssue).NotEmpty();
            this.RuleFor(x => x.PaymentMethod).Length(20);
            this.RuleFor(x => x.Number).InclusiveBetween(1, 10000);
            this.RuleFor(x => x.PaymentDeadline).NotNull();
        }
    }
}

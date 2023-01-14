using FluentValidation;
using JobOffice.ApplicationServices.API.Domain;

namespace JobOffice.ApplicationServices.API.Validators
{
    public class PutInvoiceItemRequestValidator : AbstractValidator<PutInvoiceItemRequest>
    {
        public PutInvoiceItemRequestValidator()
        {
            this.RuleFor(x => x.InvoiceId).NotNull();
            this.RuleFor(x => x.InvoiceId).InclusiveBetween(1, 10000);
            this.RuleFor(x => x.ProductId).NotNull();
            this.RuleFor(x => x.ProductId).InclusiveBetween(1, 10000);
            this.RuleFor(x => x.Description).Length(1, 2000);
            this.RuleFor(x => x.Discount).LessThan(1);
            this.RuleFor(x => x.Quantity).LessThan(200);
        }
    }
}

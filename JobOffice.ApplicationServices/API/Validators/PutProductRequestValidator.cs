using FluentValidation;
using JobOffice.ApplicationServices.API.Domain;

namespace JobOffice.ApplicationServices.API.Validators
{
    public class PutProductRequestValidator : AbstractValidator<PutProductRequest>
    {
        public PutProductRequestValidator()
        {
            this.RuleFor(x => x.ProductName).NotEmpty();
            this.RuleFor(x => x.ProductName).Length(1, 20);
            this.RuleFor(x => x.Discount).LessThan(1);
            this.RuleFor(x => x.UnitPriceNetto).LessThan(1000);
            this.RuleFor(x => x.UnitPriceBrutto).LessThan(10000);
        }
    }
}

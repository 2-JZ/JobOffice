using FluentValidation;
using JobOffice.ApplicationServices.API.Domain;

namespace JobOffice.ApplicationServices.API.Validators
{
    public class AddContractorRequestValidator : AbstractValidator<AddContractorRequest>
    {
        public AddContractorRequestValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty();
            this.RuleFor(x=>x.NIP).Length(20);
            this.RuleFor(x=>x.country).Length(100);
            this.RuleFor(x=>x.Code).Length(10);
        }
    }
}

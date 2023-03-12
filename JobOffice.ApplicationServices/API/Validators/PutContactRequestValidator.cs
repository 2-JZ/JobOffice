using FluentValidation;
using JobOffice.ApplicationServices.API.Domain;

namespace JobOffice.ApplicationServices.API.Validators
{
    public class PutContactRequestValidator : AbstractValidator<PutContactRequest>
    {
        public PutContactRequestValidator()
        {
            this.RuleFor(x => x.Telephone).NotEmpty();
            this.RuleFor(x => x.Email).EmailAddress();
            this.RuleFor(x => x.WhatsApp).Length(1, 20);
            this.RuleFor(x => x.Skype).Length(1, 20);
        }
    }
}

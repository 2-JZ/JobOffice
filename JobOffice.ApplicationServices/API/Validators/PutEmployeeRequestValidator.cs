using FluentValidation;
using JobOffice.ApplicationServices.API.Domain;

namespace JobOffice.ApplicationServices.API.Validators
{
    public class PutEmployeeRequestValidator : AbstractValidator<AddEmployeeRequest>
    {
        public PutEmployeeRequestValidator()
        {
            this.RuleFor(x => x.FirstName).NotEmpty();
            this.RuleFor(x => x.LastName).NotEmpty();
            this.RuleFor(x => x.Salary).InclusiveBetween(1, 50000);
            this.RuleFor(x => x.Adress).Length(1, 100);
            this.RuleFor(x => x.City).Length(1, 100);
            this.RuleFor(x => x.ZipCode).Length(1, 10);
        }
    }
}

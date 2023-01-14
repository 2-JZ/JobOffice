using FluentValidation;
using JobOffice.ApplicationServices.API.Domain;

namespace JobOffice.ApplicationServices.API.Validators
{
    public class AddProjectRequestValidator : AbstractValidator<AddProjectRequest>
    {
        public AddProjectRequestValidator()
        {
            this.RuleFor(x => x.ProjectName).NotEmpty();
            this.RuleFor(x => x.ProjectDescription).Length(1,100);
            this.RuleFor(x => x.Adress).Length(1,100);
        }
    }
}

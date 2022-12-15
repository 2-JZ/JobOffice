using FluentValidation;
using JobOffice.ApplicationServices.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Validators
{
    public class AddContractorRequestValidator : AbstractValidator<AddContractorRequest>
    {
        public AddContractorRequestValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty();
            this.RuleFor(x=>x.ContactId).InclusiveBetween(1, 5);

        }
    }
}

﻿using FluentValidation;
using JobOffice.ApplicationServices.API.Domain;

namespace JobOffice.ApplicationServices.API.Validators
{
    public class PutContractorRequestValidator : AbstractValidator<PutContractorRequest>
    {
        public PutContractorRequestValidator()
        {
            //this.RuleFor(x => x.Name).NotEmpty();
            //this.RuleFor(x => x.NIP).Length(1, 20);
            //this.RuleFor(x => x.country).Length(100);
            //this.RuleFor(x => x.Code).Length(10);
        }
    }
}

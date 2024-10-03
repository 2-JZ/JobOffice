using JobOffice.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class AddPaymentCommand : CommandBase<Payment, Payment>
    {
        public override async Task<Payment> Execute(JobOfficeContext context)
        {
            await context.Payments.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }

}

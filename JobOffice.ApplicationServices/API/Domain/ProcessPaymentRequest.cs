using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class ProcessPaymentRequest :RequestBase, IRequest<ProcessPaymentResponse>
    {
        public string Token { get; set; } // Stripe token generated from frontend
        public decimal Amount { get; set; } // The payment amount
        public string Currency { get; set; } = "usd"; // Currency for the payment, default USD
    }
}

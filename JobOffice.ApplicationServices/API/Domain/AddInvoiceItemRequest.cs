﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class AddInvoiceItemRequest : IRequest<AddInvoiceItemResponse>
    {
        //public int Id { get; set; }
        public int InvoiceId { get; set; }
        public Decimal UnitPrice { get; set; }
        public float Quantity { get; set; }
        public Decimal TotalPrice { get; set; }
        public float? Discount { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
    }
}

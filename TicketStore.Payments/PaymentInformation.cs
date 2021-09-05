using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Payments
{
    public class PaymentInformation
    {
        public Guid CardNumber { get; set; }

        public string Name { get; set; }

        public string Cvv { get; set; }

        public DateTime ValidThru { get; set; }

        public Guid CartId { get; set; }
    }
}

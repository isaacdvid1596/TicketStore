using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Gateway.Models
{
    public class CreditCardDto
    {
        public Guid CardNumber { get; set; }

        public string Name { get; set; }

        public string Cvv { get; set; }

        public DateTime ValidThru { get; set; }

        public Guid CartId { get; set; }
    }
}

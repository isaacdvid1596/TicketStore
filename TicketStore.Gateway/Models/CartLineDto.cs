using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Gateway.Models
{
    public class CartLineDto
    {
        public Guid CartLineId { get; set; }

        public Guid CartId { get; set; }

        public Guid EventId { get; set; }

        public decimal Price { get; set; }

        public int TicketQuantity { get; set; }

        public EventDto Event { get; set; }
    }
}

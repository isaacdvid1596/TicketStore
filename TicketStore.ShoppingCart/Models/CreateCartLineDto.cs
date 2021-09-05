using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.ShoppingCart.Models
{
    public class CreateCartLineDto
    {

        public Guid CartId { get; set; }

        public Guid EventId { get; set; }

        public int TicketQuantity { get; set; }

        public decimal Price { get; set; }

        public EventDto Event { get; set; }
    }
}

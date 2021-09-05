using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Gateway.Models
{
    public class CartDto
    {
        public Guid CartId { get; set; }

        public Guid UserId { get; set; }

        public int NumberOfItems { get; set; }

        public IEnumerable<CartLineDto> CartLines { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.Gateway.Models;

namespace TicketStore.Gateway.Models
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public IEnumerable<EventDto> Events { get; set; }
    }
}

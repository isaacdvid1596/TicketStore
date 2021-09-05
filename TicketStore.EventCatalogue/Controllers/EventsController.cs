using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketStore.EventCatalogue.Models;

namespace TicketStore.EventCatalogue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private static readonly List<EventDto> Events = new List<EventDto>
        {
            new EventDto()
            {
                EventId = new Guid("81d77da1-52a1-4167-8cf0-1a13b3ec20d3"),
                CategoryId = new Guid("d474e09c-5cbd-4a61-bf19-2049988d9b77"),
                Artist = "Foo Fighters",
                CategoryName = "Conciertos",
                Date = DateTime.Now,
                Price = 200,
                Name = "Concierto 1"
            },
            new EventDto()
            {
                EventId = new Guid("fb816f93-45bc-42bf-8842-2b24661f9bd9"),
                CategoryId = new Guid("d474e09c-5cbd-4a61-bf19-2049988d9b77"),
                Artist = "Radiohead",
                CategoryName = "Conciertos",
                Date = DateTime.Now,
                Price = 400,
                Name = "Concierto 2"
            },
            new EventDto()
            {
                EventId = new Guid("727dfd16-8c07-4739-82fe-2c0c33795dc2"),
                CategoryId = new Guid("d474e09c-5cbd-4a61-bf19-2049988d9b77"),
                Artist = "Guns n Roses",
                CategoryName = "Conciertos",
                Date = DateTime.Now,
                Price = 500,
                Name = "Concierto 3"
            }
        };

        /*Get events by categoryId*/

        [HttpGet("{eventId}")]
        public ActionResult<EventDto> GetById(Guid eventId)
        {
            return Ok(Events.FirstOrDefault(c => c.EventId == eventId));
        }


        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> Get([FromQuery]Guid categoryId)
        {
            return Ok(Events.Where(c => c.CategoryId == categoryId));
        }
    }
}

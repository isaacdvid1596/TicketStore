using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicketStore.ShoppingCart.Models;

namespace TicketStore.ShoppingCart.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CartLinesController : ControllerBase
    {

        [HttpGet("/ShoppingCart/{cartId}/Cartlines")]
        public ActionResult<IEnumerable<CartLineDto>> Get(Guid cartId)
        {
            var cart = Database.Carts.FirstOrDefault(c => c.CartId == cartId);

            if (cart == null)
            {
                return NotFound("cartline not found");
            }

            var cartLines = Database.CartLines.Where(x => x.CartId == cartId);

            return Ok(cartLines);
        }


        [HttpPost("/ShoppingCart/{cartId}/Cartlines")]
        public async Task<ActionResult<CartLineDto>> Post(Guid cartId, [FromBody] CreateCartLineDto cartLineCreated)
        {
            var cart = Database.Carts.FirstOrDefault(c => c.CartId == cartId);

            if (cart == null)
            {
                return NotFound("cartline not found");
            }

            /*if event exists on localdb*/

            EventDto eventdata = null;

            if (Database.Events.All(e => e.EventId != cartLineCreated.EventId))
            {
                /*request to other service to EventCatalogue*/
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetStringAsync($"http://localhost:39864/events/{cartLineCreated.EventId}");
                    eventdata = JsonConvert.DeserializeObject<EventDto>(response);
                    Database.Events.Add(eventdata);
                }
            }

            if (eventdata == null)
            {
                return Ok("event does not exist");
            }

            var cartLine = new CartLineDto()
            {
                EventId = cartLineCreated.EventId,
                Price = eventdata.Price,
                CartId =  cartLineCreated.CartId,
                TicketQuantity = cartLineCreated.TicketQuantity,
                CartLineId = Guid.NewGuid(),
                Event = cartLineCreated.Event
            };

            Database.CartLines.Add(cartLine);

            return Ok();
        }
    }
}

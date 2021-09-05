using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.ShoppingCart.Models;

namespace TicketStore.ShoppingCart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        

        [HttpGet("{cartId}")]
        public ActionResult<CartDto> Get(Guid cartId)
        {
            var cart = Database.Carts.FirstOrDefault(c => c.CartId == cartId);

            if (cart == null)
            {
                return NotFound($"cart with id {cartId} not found");
            }

            return Ok(cart);
        }


        /*se reciben de parametros de un json para crear un basket*/
        [HttpPost]
        public ActionResult<CartDto> Post([FromBody] CartCreationDto createdCart)
        {
            var cart = new CartDto
            {
                UserId = createdCart.UserId,
                CartId = Guid.NewGuid()
            };

            Database.Carts.Add(cart);
            return Ok(cart);
        }
    }
}

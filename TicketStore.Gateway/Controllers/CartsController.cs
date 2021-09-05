using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using TicketStore.Gateway.Models;
using TicketStore.Gateway.Services;

namespace TicketStore.Gateway.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public CartsController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("{cartId}")]
        public async Task<ActionResult<CartDto>> GetCartById(Guid cartId)
        {
            var result = await _shoppingCartService.GetCartByIdAsync(cartId);
            return Ok(result);
        }

        [HttpPost("{cartId}/Cartlines")]
        public async Task<ActionResult<CartLineDto>> Post(Guid cartId, [FromBody] CreateCartLineDto cartLineCreated)
        {
            return await _shoppingCartService.AddEventToCartAsync(cartId, cartLineCreated);
        }

        [HttpPost("payments/{cartId}")]
        public async Task<ActionResult> PostPayment(Guid cartId,[FromBody] CreditCardDto creditCard)
        {
            try
            {
                creditCard.CartId = cartId;
                var json = JsonConvert.SerializeObject(creditCard);

                var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    Port = 5672
                };

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare("payment-queue", false, false, false, null);
                        var body = Encoding.UTF8.GetBytes(json);
                        channel.BasicPublish(string.Empty,"payment-queue",null,body);
                    }
                }
                return Ok(Guid.NewGuid());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

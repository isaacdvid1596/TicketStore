using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TicketStore.Gateway.Models;

namespace TicketStore.Gateway.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly HttpClient _httpClient;

        public ShoppingCartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<CartDto> GetCartByIdAsync(Guid cartId)
        {
            var cartResponse = await _httpClient.GetStringAsync($"shoppingcart/{cartId}");
            var cartLinesResponse = await _httpClient.GetStringAsync($"shoppingcart/{cartId}/cartlines");
            var cart = JsonConvert.DeserializeObject<CartDto>(cartResponse);
            var cartLines = JsonConvert.DeserializeObject<IEnumerable<CartLineDto>>(cartLinesResponse);
            cart.CartLines = cartLines;
            return cart;
        }

        public async Task<CartLineDto> AddEventToCartAsync(Guid cartId, CreateCartLineDto lineToAdd)
        {
            var requestBodyJson = JsonConvert.SerializeObject(lineToAdd);

            var cartLinesResponse = await _httpClient.PostAsync($"shoppingcart/{cartId}/cartlines", 
                new StringContent(requestBodyJson,Encoding.UTF8,"application/json"));

            cartLinesResponse.EnsureSuccessStatusCode();

            var responseBody = await cartLinesResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CartLineDto>(responseBody);
        }
    }
}

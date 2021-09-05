using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.Gateway.Models;

namespace TicketStore.Gateway.Services
{
    public interface IShoppingCartService
    {
        Task<CartDto> GetCartByIdAsync(Guid cartId);

        Task<CartLineDto> AddEventToCartAsync(Guid cartId, CreateCartLineDto lineToAdd);
    }
}

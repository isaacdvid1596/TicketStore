using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.ShoppingCart.Models;

namespace TicketStore.ShoppingCart
{
    public static class Database
    {
        public static readonly List<CartDto> Carts = new List<CartDto>
        {
            new CartDto()
            {
                CartId = new Guid("c24bfa40-7f47-44eb-be7c-9600718d1cab"),
                NumberOfItems = 0,
                UserId = new Guid("b97f9f1e-e1a4-420b-8145-766008aa4c5d")
            }
        };

        public static readonly List<EventDto> Events = new List<EventDto>();
        public static readonly List<CartLineDto> CartLines = new List<CartLineDto>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.Gateway.Models;

namespace TicketStore.Gateway.Services
{
    public interface IEventCatalogService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();

        Task<EventDto> GetEventByIdAsync(Guid eventId);

        Task<IEnumerable<EventDto>> GetEventsByCategoryAsync(Guid categoryId);
    }
}

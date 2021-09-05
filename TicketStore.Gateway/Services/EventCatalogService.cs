using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TicketStore.Gateway.Models;

namespace TicketStore.Gateway.Services
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly HttpClient _httpClient;

        public EventCatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _httpClient.GetStringAsync("categories");
            return JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<EventDto> GetEventByIdAsync(Guid eventId)
        {
            var @event = await _httpClient.GetStringAsync($"events/{eventId}");
            return JsonConvert.DeserializeObject<EventDto>(@event);
        }

        public async Task<IEnumerable<EventDto>> GetEventsByCategoryAsync(Guid categoryId)
        {
            var @event = await _httpClient.GetStringAsync($"events?categoryId={categoryId}");
            return JsonConvert.DeserializeObject<IEnumerable<EventDto>>(@event);
        }
    }
}

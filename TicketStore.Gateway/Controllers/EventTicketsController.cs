using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.Gateway.Models;
using TicketStore.Gateway.Services;

namespace TicketStore.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventTicketsController : ControllerBase
    {
        private readonly IEventCatalogService _eventCatalogService;

        public EventTicketsController(IEventCatalogService eventCatalogService)
        {
            _eventCatalogService = eventCatalogService;
        }

        [HttpGet("categories")]
        public async Task<ActionResult<CategoryDto>> GetCategories()
        {
            var result = await _eventCatalogService.GetCategoriesAsync();
            return Ok(result);
        }
        
        [HttpGet("events/{eventId}")]
        public async Task<ActionResult<CategoryDto>> GetEvents(Guid eventId)
        {
            var result = await _eventCatalogService.GetEventByIdAsync(eventId);
            return Ok(result);
        }
        
        [HttpGet("events")]
        public async Task<ActionResult<CategoryDto>> GetEventsByCategory([FromQuery] Guid categoryId)
        {
            var result = await _eventCatalogService.GetEventsByCategoryAsync(categoryId);
            return Ok(result);
        }
    }
}

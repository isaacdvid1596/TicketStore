using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.EventCatalogue.Models;

namespace TicketStore.EventCatalogue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private static readonly List<CategoryDto> Categories = new List<CategoryDto>
        {
            new CategoryDto()
            {
                CategoryId = new Guid("d474e09c-5cbd-4a61-bf19-2049988d9b77"),
                Name = "Conciertos"
            },
            new CategoryDto()
            {
                CategoryId = new Guid("320b324e-03c5-4196-bb52-03e58bedaea0"),
                Name = "Obras"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> Get()
        {
            return Ok(Categories);
        }
        
        [HttpGet("{categoryId}")]
        public ActionResult<IEnumerable<CategoryDto>> Get(Guid categoryId)
        {
            return Ok(Categories.FirstOrDefault(c => c.CategoryId == categoryId));
        }
    }
}

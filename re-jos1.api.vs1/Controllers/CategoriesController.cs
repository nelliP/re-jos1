using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using re_jos1.api.vs1.Models;

namespace re_jos1.api.vs1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext context;

        public CategoriesController(ApiContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await context.Categories.OrderBy(x => x.Id).ToListAsync();
        }
    }
}

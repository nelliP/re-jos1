using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using re_jos1.api.vs1.Models;

namespace re_jos1.api.vs1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly ApiContext context;

        public PagesController(ApiContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IEnumerable<Page>>> Get()
        {
            return await context.Pages.OrderBy(x => x.Id).ToListAsync();
        }
    }
}

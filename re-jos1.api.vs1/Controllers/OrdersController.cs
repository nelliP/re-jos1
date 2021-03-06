﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using re_jos1.api.vs1.Models;

namespace re_jos1.api.vs1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApiContext context;

        public OrdersController(ApiContext context)
        {
            this.context = context;
        }

        // GET /api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return await context.Orders.OrderBy(x => x.Id).ToListAsync();
        }
    }
}

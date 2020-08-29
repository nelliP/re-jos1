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
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext context;

        public ProductsController(ApiContext context)
        {
            this.context = context;
        }

        // GET /api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get(int page = 1)
        {
            int pageSize = 1;
            var products = context.Products
                .OrderBy(x => x.Id)
                .Include(x => x.Category)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return await products.ToListAsync();
        }

        // GET /api/products/category
        [HttpGet("{slug}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCategory(string slug, int page = 1)
        {
            Category category = await context.Categories.Where(x => x.Slug == slug).FirstOrDefaultAsync();
            if (category == null)
            {
                //404
                return NotFound();
            }

            int pageSize = 1;
            var products = context.Products
                .OrderBy(x => x.Id)
                .Where(x => x.Category.Id == category.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return await products.ToListAsync();
        }

        // GET /api/products/count/category
        [HttpGet("count/{slug}")]
        public async Task<ActionResult<int>> GetCount(string slug)
        {
           if (slug == "all")
            {
                return await context.Products.CountAsync();
            }

            Category category = await context.Categories.Where(x => x.Slug == slug).FirstOrDefaultAsync();
            if (category == null)
            {
                //404
                return NotFound();
            }

            return await context.Products.Where(x => x.CategoryId == category.Id).CountAsync();
        }

    }
}

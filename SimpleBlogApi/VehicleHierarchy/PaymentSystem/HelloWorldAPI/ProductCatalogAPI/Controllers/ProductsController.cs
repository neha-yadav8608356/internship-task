using Microsoft.AspNetCore.Mvc;
using ProductCatalogAPI.Models;

namespace ProductCatalogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> Products = new List<Product>();
        private static int nextId = 1;

        // GET: api/products
        [HttpGet]
        public IActionResult GetAll(
            string? search = null, 
            int page = 1, 
            int pageSize = 5,
            string? sortBy = null,
            string? sortDir = "asc")
        {
            IEnumerable<Product> result = Products;

            // Search
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            // Sorting
            if (!string.IsNullOrEmpty(sortBy))
            {
                result = (sortBy.ToLower(), sortDir.ToLower()) switch
                {
                    ("name","asc") => result.OrderBy(p => p.Name),
                    ("name","desc") => result.OrderByDescending(p => p.Name),
                    ("price","asc") => result.OrderBy(p => p.Price),
                    ("price","desc") => result.OrderByDescending(p => p.Price),
                    _ => result
                };
            }

            // Pagination
            result = result.Skip((page - 1) * pageSize).Take(pageSize);

            return Ok(result);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            product.Id = nextId++;
            Products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product updated)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            product.Name = updated.Name;
            product.Description = updated.Description;
            product.Price = updated.Price;
            product.Category = updated.Category;

            return NoContent();
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            Products.Remove(product);
            return NoContent();
        }
    }
}

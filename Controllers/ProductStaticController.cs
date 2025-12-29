using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi25Dec.Models;

namespace WebApi25Dec.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductStaticController : ControllerBase
    {
        // In-memory product store (replace with DB later)
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200 },
            new Product { Id = 2, Name = "Phone", Price = 800 }
        };

        // ✅ READ: Get all products
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_products);
        }

        // ✅ READ: Get product by Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // ✅ CREATE: Add new product
        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1; // auto-increment
            _products.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // ✅ UPDATE: Modify existing product
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return NoContent(); // 204
        }

        // ✅ DELETE: Remove product
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            _products.Remove(product);
            return NoContent();
        }
    }

    // Simple Product model
    //public class Product
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public decimal Price { get; set; }
    //}
}



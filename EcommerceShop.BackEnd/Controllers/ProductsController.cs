using EcommerceShop.BackEnd.Data;
using EcommerceShop.BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceShop.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            var items = _context.Products.ToList();
            return Ok(items);
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(z => z.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm]Product product)
        {
            if (ModelState.IsValid)
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProduct", new { product.Id }, product);
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromForm]int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
   
        private bool ProductExists(int id)
        {
           return _context.Products.Any(e => e.Id == id);
        }
    }
}

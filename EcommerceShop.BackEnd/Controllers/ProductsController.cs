using AutoMapper;
using EcommerceShop.BackEnd.Data;
using EcommerceShop.BackEnd.Models;
using EcommerceShop.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
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
        private IMapper _mapper;

        public ProductsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ProductDto>> GetProduct()
        {
            //return await _context.Products
            //    .Select(x => new ProductDto
            //    {
            //        ProductId = x.ProductId,
            //        Name = x.Name,
            //        Description = x.Description,
            //        Price = x.Price,
            //        Images = x.Images
            //    })
            //    .ToListAsync();
            var product = await _context.Products.ToListAsync();

            var productdto = _mapper.Map<IEnumerable<ProductDto>>(product);

            return productdto;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDto>> GetProduct(string id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            //var productdto = new ProductDto
            //{
            //    ProductId = product.ProductId,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Price = product.Price,
            //    Images = product.Images
            //};
            var productdto = _mapper.Map<ProductDto>(product);
            return productdto;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductCreateRequest>> PutProduct(string id, [FromForm] ProductUpdateRequest productUpdateRequest)
        {
            var product = await _context.Products.FindAsync(id);    

            if (product == null)
            {
                return NotFound();
            }

            //product.Name = productCreateRequest.Name;
            //product.Price = productCreateRequest.Price;
            //product.Description = productCreateRequest.Description;
            //product.Images = productCreateRequest.Images;
            //product.UpdatedDate = DateTime.Now.Date;
            _context.Entry<Product>(product).CurrentValues.SetValues(productUpdateRequest);
            product.UpdatedDate = DateTime.Now.Date;

            await _context.SaveChangesAsync();
            var productdto = _mapper.Map<ProductCreateRequest>(product);

            return productdto;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct([FromForm] ProductCreateRequest productCreateRequest)
        {
            //var product = new Product
            //{
            //    Name = productCreateRequest.Name,
            //    Description = productCreateRequest.Description,
            //    Price = productCreateRequest.Price,
            //    Images = productCreateRequest.Images,
            //    CreatedDate = DateTime.Now.Date,
            //    UpdatedDate = DateTime.Now.Date,
            //    CategoryId = productCreateRequest.CategoryId
            //};
            var product = _mapper.Map<Product>(productCreateRequest);
            product.ProductId = Guid.NewGuid().ToString();
            product.CreatedDate = DateTime.Now.Date;
            product.UpdatedDate = DateTime.Now.Date;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProduct", new { id = product.ProductId }, new ProductDto
            //{
            //    ProductId = product.ProductId,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Price = product.Price,
            //    Images = product.Images
            //});
            var productdto = _mapper.Map<ProductDto>(product);
            return productdto;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
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
    }
}

using AutoMapper;
using EcommerceShop.BackEnd.Data;
using EcommerceShop.BackEnd.Models;
using EcommerceShop.BackEnd.Storage;
using EcommerceShop.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EcommerceShop.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public ProductsController(ApplicationDbContext context, IMapper mapper, IStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _storageService = storageService;
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
            var products = await _context.Products
                .Include(product=>product.Category)
                .AsNoTracking()
                .ToListAsync();

            foreach (var item in products)
            {
                item.Images = _storageService.GetFileUrl(item.Images);
            }
            var productdto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productdto;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDto>> GetProduct(string id)
        {
            var product = await _context.Products
                .Include(products => products.Category)
                .Where(product => product.ProductId.Equals(id))
                .AsNoTracking()
                .SingleAsync();

            if (product == null)
            {
                return NotFound();
            }
            product.Images = _storageService.GetFileUrl(product.Images);
            //var productdto = new ProductDto
            //{
            //    ProductId = product.ProductId,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Price = product.Price,
            //    Images = product.Images
            //};
            var productdto = _mapper.Map<ProductDto>(product);
            productdto.NameCategory = product.Category.NameCategory;
            return productdto;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> PutProduct(string id, [FromForm] ProductUpdateRequest productUpdateRequest)
        {
            var product = await _context.Products.FindAsync(id);    

            if (product == null)
            {
                return NotFound();
            }
            if (productUpdateRequest.ThumbnailImages != null)
            {
                product.Images = await SaveFile(productUpdateRequest.ThumbnailImages);
            }

            product.Name = productUpdateRequest.Name;
            product.Description = productUpdateRequest.Description;
            product.Price = productUpdateRequest.Price;
            product.CategoryId = productUpdateRequest.CategoryId;
            product.UpdatedDate = DateTime.Now.Date;

            await _context.SaveChangesAsync();

            var productdto = _mapper.Map<ProductDto>(product);

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

            if (productCreateRequest.Images != null)
            {
                product.Images = await SaveFile(productCreateRequest.Images);
            }
            else
            {
                product.Images = "noimage.png";
            }

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

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }    
}

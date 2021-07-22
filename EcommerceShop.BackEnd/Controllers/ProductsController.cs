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
using static IdentityServer4.IdentityServerConstants;

namespace EcommerceShop.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(LocalApi.PolicyName)]
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
                .Include(product => product.Category)
                .AsNoTracking()
                .ToListAsync();

            foreach (var item in products)
            {
                item.Images = _storageService.GetFileUrl(item.Images);
            }
            var productdto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productdto;
        }

        [HttpGet("GetProductById/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDto>> GetProductById(string id)
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

        [HttpGet("GetProductSameCategory/{productId}")]
        [AllowAnonymous]
        public async Task<IEnumerable<ProductDto>> GetProductSameCategory(string productId)
        {
            var product = await _context.Products.FindAsync(productId);

            var productsSame = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId.Equals(product.CategoryId) && p.ProductId != product.ProductId)
                .AsNoTracking()
                .ToListAsync();

            foreach (var item in productsSame)
            {
                item.Images = _storageService.GetFileUrl(item.Images);
            }

            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productsSame);

            return productDto;
        }

        [HttpGet("GetProductByCategory/{categoryId}")]
        [AllowAnonymous]
        public async Task<IEnumerable<ProductDto>> GetProductByCategory(string categoryId)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId.Equals(categoryId))
                .AsNoTracking()
                .ToListAsync();

            foreach (var item in products)
            {
                item.Images = _storageService.GetFileUrl(item.Images);
            }

            var productdto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productdto;
        }

        [HttpPut("{id}")]
        //[Authorize("ADMIN_ROLE_POLICY")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDto>> PutProduct([FromForm]string id, ProductUpdateRequest productUpdateRequest)
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

            _context.Entry(product).CurrentValues.SetValues(productUpdateRequest);
            product.UpdatedDate = DateTime.Now.Date;
            await _context.SaveChangesAsync();


            var productdto = _mapper.Map<ProductDto>(product);

            return productdto;
        }

        [HttpPost]
        [AllowAnonymous]
        //[Authorize("ADMIN_ROLE_POLICY")]
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
            product.Rating = 0;

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
        //[Authorize("ADMIN_ROLE_POLICY")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDto>> DeleteProduct(string id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var productdto = _mapper.Map<ProductDto>(product);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return productdto;
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

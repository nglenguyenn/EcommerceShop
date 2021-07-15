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
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EcommerceShop.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        private readonly IStorageService _storageService;

        public CategoriesController(ApplicationDbContext context, IMapper mapper, IStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _storageService = storageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<CategoryDto>> GetCategory()
        {
            //return await _context.Categories
            //    .Select(x => new CategoryDto
            //    {
            //        CategoryId = x.CategoryId,
            //        NameCategory = x.NameCategory,
            //        Description = x.Description
            //    })
            //    .ToListAsync();
            var category = await _context.Categories.ToListAsync();
            foreach (var item in category)
            {
                item.Images = _storageService.GetFileUrl(item.Images);
            }
            var categoryRes = _mapper.Map<IEnumerable<CategoryDto>>(category);

            return categoryRes;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryDto>> GetCategory(string id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }
            category.Images = _storageService.GetFileUrl(category.Images);
            //var categorydto = new CategoryDto
            //{
            //    CategoryId = category.CategoryId,
            //    NameCategory = category.NameCategory,
            //    Description = category.Description
            //};
            var categorydto = _mapper.Map<CategoryDto>(category);
            return categorydto;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> PutCategory(string id,[FromForm]CategoryCreateRequest categoryCreateRequest)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            if (categoryCreateRequest.ThumbnailImages != null)
            {
                category.Images = await SaveFile(categoryCreateRequest.ThumbnailImages);
            }

            //category.NameCategory = categoryCreateRequest.NameCategory;
            //category.Description = categoryCreateRequest.Description;
            _context.Entry<Category>(category).CurrentValues.SetValues(categoryCreateRequest);

            await _context.SaveChangesAsync();

            //return NoContent();
            var categoryRes = _mapper.Map<CategoryDto>(category);

            return categoryRes;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory([FromForm]CategoryCreateRequest categoryCreateRequest)
        {
            //var category = new Category
            //{
            //    NameCategory = categoryCreateRequest.NameCategory,
            //    Description = categoryCreateRequest.Description
            //};
            var category = _mapper.Map<Category>(categoryCreateRequest);
            category.CategoryId = Guid.NewGuid().ToString();

            if (categoryCreateRequest.ThumbnailImages != null)
            {
                category.Images = await SaveFile(categoryCreateRequest.ThumbnailImages);
            }
            else
            {
                category.Images = "noimage.png";
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCategory", new { id = category.CategoryId }, new CategoryDto
            //{
            //    NameCategory = category.NameCategory,
            //    Description = category.Description
            //});
            var categorydto = _mapper.Map<CategoryDto>(category);
            return categorydto;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
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


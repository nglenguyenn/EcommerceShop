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
using static IdentityServer4.IdentityServerConstants;

namespace EcommerceShop.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(LocalApi.PolicyName)]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
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
            var categorydto = _mapper.Map<IEnumerable<CategoryDto>>(category);

            return categorydto;
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
        [AllowAnonymous]
        //[Authorize("ADMIN_ROLE_POLICY")]
        public async Task<ActionResult<CategoryDto>> PutCategory(string id, [FromForm] CategoryCreateRequest categoryCreateRequest)
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
            var categorydto = _mapper.Map<CategoryDto>(category);

            return categorydto;
        }

        [HttpPost]
        [AllowAnonymous]
        //[Authorize("ADMIN_ROLE_POLICY")]
        public async Task<ActionResult<CategoryDto>> PostCategory([FromForm] CategoryCreateRequest categoryCreateRequest)
        {
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

            var categorydto = _mapper.Map<CategoryDto>(category);
            return categorydto;
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        //[Authorize("ADMIN_ROLE_POLICY")]
        public async Task<ActionResult<CategoryDto>> DeleteCategory(string id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDto = _mapper.Map<CategoryDto>(category);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return categoryDto;
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


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
using System.Security.Claims;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace EcommerceShop.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(LocalApi.PolicyName)]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ReviewsController(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetReviews/{id}")]
        [AllowAnonymous]
        public async Task<IEnumerable<ReviewDto>> GetReviews(string id)
        {
            var reviews = await _context.Reviews
                .Include(review => review.Product)
                .Where(review => review.ProductId.Equals(id))
                .AsNoTracking()
                .ToListAsync();

            var reviewdto = _mapper.Map<IEnumerable<ReviewDto>>(reviews);
            return reviewdto;
        }
        [HttpPost("PostReview")]
        public async Task<ActionResult<ReviewDto>> PostReview(ReviewCreateRequest reviewcreateRequest)
        {
            var review = _mapper.Map<Review>(reviewcreateRequest);
            review.ReviewId = Guid.NewGuid().ToString();
            review.DateReview = DateTime.Now.Date;

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            review.UserId = userId;

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            var sumRating = _context.Reviews.Where(x => x.ProductId.Equals(review.ProductId)).Average(p => p.Rating);

            var product = await _context.Products.FindAsync(review.ProductId);
            product.Rating = Convert.ToInt32(sumRating);
            await _context.SaveChangesAsync();

            var reviewdto = _mapper.Map<ReviewDto>(review);
            return reviewdto;
        }
    }
}
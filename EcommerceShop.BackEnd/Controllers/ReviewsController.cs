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

namespace EcommerceShop.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ReviewsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task<ActionResult<ReviewDto>> PostReview(ReviewCreateRequest reviewFormRequest)
        {
            var review = _mapper.Map<Review>(reviewFormRequest);
            review.ReviewId = Guid.NewGuid().ToString();
            review.DateReview = DateTime.Now.Date;

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
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
using EcommerceShop.BackEnd.Controllers;
using EcommerceShop.BackEnd.Models;
using EcommerceShop.Shared.DTO;
using EcommerceShop.Test.Mappings;
using EcommerceShop.Test.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace EcommerceShop.Test.ControllerTests
{
    public class ReviewsControllerTests : IClassFixture<SqliteInMemoryFixture>
    {

        private readonly SqliteInMemoryFixture _fixture;

        public ReviewsControllerTests(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task GetReview_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = ReviewMapper.Get();

            var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            mockHttpContextAccessor.Setup(o => o.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());

            var product = new Product { ProductId = "ProductId" };
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var user = new User { Id = "UserId" };
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var review = new Review
            {
                ReviewId = "ReviewId",
                Content = "Comment Test",
                Rating = 5,
                ProductId = "ProductId",
                UserId = "UserId",
                UserName = "Le Nguyen",
                DateReview = DateTime.Now.Date
            };
            await dbContext.AddAsync(review);
            await dbContext.SaveChangesAsync();

            var reviewController = new ReviewsController(dbContext, mapper, mockHttpContextAccessor.Object);

            // Act
            var result = await reviewController.GetReviews(review.ProductId);

            // Assert
            var postReviewResult = Assert.IsAssignableFrom<IEnumerable<ReviewDto>>(result);
            Assert.NotEmpty(postReviewResult);
        }

        [Fact]
        public async Task PostReview_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = ReviewMapper.Get();

            var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            mockHttpContextAccessor.Setup(x => x.HttpContext.User.FindFirst(It.IsAny<string>()))
            .Returns(new Claim("id", "UserId"));

            var product = new Product { ProductId = "ProductId" };
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var reviewFormRequest = new ReviewCreateRequest
            {
                Content = "Comment Test",
                Rating = 5,
                ProductId = "ProductId",
                UserName = "Le Nguyen",
            };

            var reviewController = new ReviewsController(dbContext, mapper, mockHttpContextAccessor.Object);

            // Act
            var result = await reviewController.PostReview(reviewFormRequest);

            // Assert
            var postReviewResult = Assert.IsType<ActionResult<ReviewDto>>(result);
            var resultValue = Assert.IsType<ReviewDto>(postReviewResult.Value);

            Assert.Equal("Comment Test", resultValue.Content);
            Assert.Equal(5, resultValue.Rating);
            Assert.Equal("UserId", resultValue.UserId);
            Assert.Equal("ProductId", resultValue.ProductId);
            Assert.Equal("Le Nguyen", resultValue.UserName);
        }
    }
}


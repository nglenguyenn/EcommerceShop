﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Shared.DTO
{
    public class ReviewDto
    {
        public string ReviewId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime DateReview { get; set; }
    }
}

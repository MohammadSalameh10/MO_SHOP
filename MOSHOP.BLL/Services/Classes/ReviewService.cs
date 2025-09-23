using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MOSHOP.BLL.Services.Interfaces;
using MOSHOP.DAL.DTO;
using MOSHOP.DAL.Models;
using MOSHOP.DAL.Repositories.Interfaces;

namespace MOSHOP.BLL.Services.Classes
{
    public class ReviewService : IReviewService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IOrderRepository orderRepository,IReviewRepository reviewRepository)
        {
            _orderRepository = orderRepository;
            _reviewRepository = reviewRepository;
        }
        public async Task<bool> AddReviewAsync(ReviewRequest reviewRequest, string userId)
        {
            var hasOrder = await _orderRepository.UserHasApprovedOrderForProductAsync(userId, reviewRequest.ProductId);

            if (!hasOrder) return false;

            var alreadyReviews = await _reviewRepository.UserHasReviewedProductAsync(userId, reviewRequest.ProductId);
            if (alreadyReviews) return false;

            var review = reviewRequest.Adapt<Review>();

            await _reviewRepository.AddReviewAsync(review,userId);
            return true;
        }
    }
}

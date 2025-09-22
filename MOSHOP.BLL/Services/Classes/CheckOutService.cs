using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MOSHOP.BLL.Services.Interfaces;
using MOSHOP.DAL.DTO.Requests;
using MOSHOP.DAL.DTO.Responses;
using MOSHOP.DAL.Repositories.Interfaces;
using Stripe.Checkout;

namespace MOSHOP.BLL.Services.Classes
{
    public class CheckOutService : ICheckOutService
    {
        private readonly ICartRepository _cartRepository;
        public CheckOutService(ICartRepository cartRepository)
        {
            cartRepository = _cartRepository;
        }
        public async Task<CheckOutResponse> ProcsessPaymentAsync(CheckOutRequest request, string UserId, HttpRequest httpRequest)
        {
            var cartItems = _cartRepository.GetUserCart(UserId);

            if (!cartItems.Any())
            {
                return new CheckOutResponse
                {
                    Success = false,
                    Message = "Cart is empty."
                };
            }

            if (request.PaymentMethod == "Cash")
            {
                return new CheckOutResponse
                {
                    Success = true,
                    Message = "Cash."
                };
            }

            if (request.PaymentMethod == "Visa")
            {

                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card" },
                    LineItems = new List<SessionLineItemOptions>
                    {

                    },


                    Mode = "payment",
                    SuccessUrl = $"{httpRequest.Scheme}://{httpRequest.Host}/api/Customer/CheckOuts/Success",
                    CancelUrl = $"{httpRequest.Scheme}://{httpRequest.Host}/checkout/cancel",
                };
                foreach (var item in cartItems)
                {
                    options.LineItems.Add(new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "USD",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Product.Name,
                                Description = item.Product.Description,
                            },
                            UnitAmount = (long)item.Product.Price,
                        },
                        Quantity = item.Count,
                    });
                }
                var service = new SessionService();
                var session = service.Create(options);

                return new CheckOutResponse
                {
                    Success = true,
                    Message = "Payment processed successfully.",
                    //  SessionId = session.Id
                    Url = session.Url
                };
            }

           return new CheckOutResponse
            {
                Success = false,
                Message = "Invalid payment method."
            };
        }
    }
}

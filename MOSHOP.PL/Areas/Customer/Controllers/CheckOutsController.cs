﻿using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOSHOP.BLL.Services.Interfaces;
using MOSHOP.DAL.DTO.Requests;

namespace MOSHOP.PL.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class CheckOutsController : ControllerBase
    {
        private readonly ICheckOutService _checkOutService;
        public CheckOutsController(ICheckOutService checkOutService)
        {
            _checkOutService = checkOutService;
        }

        [HttpPost("payment")]

        public async Task<IActionResult> Payment([FromBody] CheckOutRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = await _checkOutService.ProcsessPaymentAsync(request, userId, Request);

            return Ok(response);
        }

        [HttpGet("Success/{orderId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Success([FromRoute] int orderId)
        {
            var result = await _checkOutService.HandlePaymentSuccessAsync(orderId);
            return Ok(result);
        }
    }
}
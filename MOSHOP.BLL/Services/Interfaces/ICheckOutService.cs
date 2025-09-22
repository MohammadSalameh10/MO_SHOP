using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MOSHOP.DAL.DTO.Requests;
using MOSHOP.DAL.DTO.Responses;

namespace MOSHOP.BLL.Services.Interfaces
{
    public interface ICheckOutService
    {
        Task<CheckOutResponse> ProcsessPaymentAsync(CheckOutRequest request, string UserId, HttpRequest httpRequest);

        Task<bool> HandlePaymentSuccessAsync(int orderId);
    }
}

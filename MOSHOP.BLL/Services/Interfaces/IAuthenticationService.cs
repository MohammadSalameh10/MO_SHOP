using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOSHOP.DAL.DTO.Requests;
using MOSHOP.DAL.DTO.Responses;

namespace MOSHOP.BLL.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserResponse> LoginAsync(LoginRequest loginRequest);
        Task<UserResponse> RegisterAsync(RegisterRequest registerRequest);
        Task<string> ConfirmEmailAsync(string token, string userId);
        Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request);
        Task<bool> ResetPasswordAsync(ResetPasswordRequest request);

    }
}

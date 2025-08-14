using ECommerce.Model.AuthModel;
using Microsoft.AspNetCore.Identity.Data;

namespace ECommerce.Service.API.AuthService
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}

using System.Security.Claims;
using LinkDev.Talabat.Core.Application.Abstraction;

namespace LinkDev.Talabat.APIs.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor? _httpContextAccessor;

        public string? UserId { get; }
        public LoggedInUserService(IHttpContextAccessor? httpContextAccessor)
        {            _httpContextAccessor = httpContextAccessor;
            UserId = _httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.PrimarySid);
        }
    }
}

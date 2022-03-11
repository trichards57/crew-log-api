using CrewLogApi.Data;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace CrewLogApi.Helpers
{
    public class ClaimsTransformation : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal.Identity is not User identity)
                Task.FromResult(principal);

            return Task.FromResult(principal);
        }
    }
}

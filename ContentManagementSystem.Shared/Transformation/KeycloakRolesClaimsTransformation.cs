using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ContentManagementSystem.Shared.Transformation
{
    public class KeycloakRolesClaimsTransformation : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = (ClaimsIdentity)principal.Identity!;

            if (identity.Claims.Any(c => c.Type == ClaimTypes.Role))
                return Task.FromResult(principal);

            var roles = identity.FindFirst("realm_access")?.Value;
            if (roles != null && roles.Contains("admin"))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            }

            return Task.FromResult(principal);
        }
    }

}

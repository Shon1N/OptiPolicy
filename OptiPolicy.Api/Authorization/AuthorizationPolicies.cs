using System.Security.Claims;

namespace OptiPolicy.Api.Authorization
{
    public static class AuthorizationPolicies
    {
        public static void AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(SysRole.Create, policy =>
                    policy.RequireClaim(ClaimTypes.Role, SysRole.Create));

                options.AddPolicy(SysRole.Read, policy =>
                    policy.RequireClaim(ClaimTypes.Role, SysRole.Read));

                options.AddPolicy(SysRole.Update, policy =>
                    policy.RequireClaim(ClaimTypes.Role, SysRole.Update));

                options.AddPolicy(SysRole.Delete, policy =>
                    policy.RequireClaim(ClaimTypes.Role, SysRole.Delete));
            });
        }
    }
}
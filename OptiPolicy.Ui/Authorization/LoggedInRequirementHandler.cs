using Microsoft.AspNetCore.Authorization;
using OptiPolicy.Ui.Services.Interfaces;

namespace OptiPolicy.Ui.Authorization
{
    public class LoggedInRequirementHandler : AuthorizationHandler<LoggedInRequirement>
    {
        private readonly IStateService _stateService;
        public LoggedInRequirementHandler(IStateService stateService)
        {
            _stateService = stateService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LoggedInRequirement requirement)
        {
            var date = DateTime.UtcNow;
            if (_stateService.User?.UserId > 0 && _stateService.User?.JwtExpiryDate > date)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
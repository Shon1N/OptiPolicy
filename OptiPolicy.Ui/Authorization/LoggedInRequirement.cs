using Microsoft.AspNetCore.Authorization;

namespace OptiPolicy.Ui.Authorization
{
    public class LoggedInRequirement : IAuthorizationRequirement
    {
        public LoggedInRequirement()
        {
            
        }
    }
}
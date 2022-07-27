using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProjApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string GetUserAuthId()
        {
            var userNameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var defaultAuthUserId = "defaultUserAuthUserId123456789";

            if (userNameClaim != null)
            {
                return userNameClaim.Value;
            }
            return defaultAuthUserId;
        }
    }
}

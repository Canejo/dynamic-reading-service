using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DynamicReadingService.Business.Entity.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DynamicReadingService.WebAPI.Controllers.Base
{
    public class BaseController : Controller
    {
        public UserEntity IdentityUser { get; private set; }

        public virtual IActionResult CatchError(Exception ex)
        {
            string erro = ex.Message;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                if (ex != null)
                    erro += Environment.NewLine + ex.Message;
            }

            return BadRequest(new { Message = erro, Exception = ex });
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (User.Identity.IsAuthenticated)
            {
                this.IdentityUser = new UserEntity()
                {
                    Id = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
            }
            base.OnActionExecuting(context);
        }
    }
}
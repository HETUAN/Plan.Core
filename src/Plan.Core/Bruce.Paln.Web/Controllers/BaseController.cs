using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Bruce.Paln.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 获取登录Id
        /// </summary>
        /// <returns></returns>
        protected int GetUserId()
        {
            //var userId = User.FindFirst(ClaimTypes.Sid).Value;
            //var userName = User.Identity.Name;
            var userId = User.FindFirst(ClaimTypes.Sid).Value;
            if (string.IsNullOrEmpty(userId))
            {
                return 0;
            }
            else
            {
                return int.Parse(userId);
            }
        }

        /// <summary>
        /// 检查Id是否相同
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        protected bool CheckSameUserId(int userId)
        {
            if (User.FindFirst(ClaimTypes.Sid).Value.Equals(userId.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

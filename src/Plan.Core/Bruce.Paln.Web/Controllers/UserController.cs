using Bruce.Paln.Entity.ViewModel;
using Bruce.Paln.Service;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bruce.Paln.Web.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (GetUserId() > 0)
                return RedirectToAction("Index", "Home");
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model">登录业务实体</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            //
            UserService service = new UserService();
            string pwd = Core.MD5Helper.GetMD5(model.PassWord);
            var result = service.GetViewModel(model.UserName, pwd);
            if (result != null)
            {
                WriteUser(result.UserID, result.UserName);
                return RedirectToAction("Home", "Home");
            }
            return View(model);
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("UserAuth");   // Startup.cs中配置的验证方案名
            return RedirectToAction("User", "Index");
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetModel()
        {
            int userId = GetUserId();
            if (userId == 0)
            {
                return Json(new { });
            }
            else
            {
                //int UserID = Account.UserId;
                UserService uService = new UserService();
                return Json(uService.GetViewModel(userId));
            }
        }


        public IActionResult Login(int userId, string userName)
        {
            WriteUser(userId, userName);
            return Content("Write");
        }

        private async void WriteUser(int userId, string userName)
        {
            var identity = new ClaimsIdentity("Forms");     // 指定身份认证类型

            identity.AddClaim(new Claim(ClaimTypes.Sid, userId.ToString()));　　// 用户Id

            identity.AddClaim(new Claim(ClaimTypes.Name, userName));　　　　　　 // 用户名称

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.Authentication.SignInAsync("UserAuth", principal, new AuthenticationProperties { IsPersistent = true });
        }

        private int GetUserId()
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

    }
}
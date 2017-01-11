using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bruce.Paln.Web.Filter;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Bruce.Paln.Web.Controllers
{
    public class TestController : Controller
    {

        // GET: /<controller>/
        [AuthorizeUser]
        public IActionResult Index()
        {
            return Content("Index");
        }
        public IActionResult Home()
        {
            return Content("Home");
        }
    }
}

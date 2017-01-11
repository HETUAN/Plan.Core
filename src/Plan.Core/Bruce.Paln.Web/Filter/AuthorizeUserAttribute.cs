using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bruce.Paln.Web.Filter
{

    public class AuthorizeUserAttribute : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine(context.HttpContext.Request.Path.Value);
            if (context.HttpContext.User.Identity.Name == "111")
            {
                Console.WriteLine("SUCCESS!");
            }
            else {
                Console.WriteLine("FILE!");
                context.HttpContext.Response.Redirect("../Error") ;
            }

            /*
            var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            if (controllerActionDescriptor.MethodInfo ==
                typeof(ProductsController).GetMethod(nameof(ProductsController.GetPrice)))
            {
                context.HttpContext.Response.Headers.Append("filters",
                    "Authorize Filter On Action - OnAuthorization");
            }

            context.HttpContext.User = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new Claim[] {
                        new Claim("Permission", "CanViewPage"),
                        new Claim(ClaimTypes.Role, "Administrator"),
                        new Claim(ClaimTypes.NameIdentifier, "John")},
                        "Basic"));
            */
        }
    }
}

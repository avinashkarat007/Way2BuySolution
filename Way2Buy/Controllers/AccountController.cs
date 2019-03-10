using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Way2Buy.BusinessObjects.Helpers;
using Way2Buy.Models;

namespace Way2Buy.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IAuthProvider _IAuthProvider;

        public AccountController()
        {
            
        }

        public AccountController(IAuthProvider authProvider)
        {
            _IAuthProvider = authProvider;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUpdated(LoginViewModelUpdated model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_IAuthProvider.Authenticate(model.UserName, model.Password))
                {
                    return (Redirect(returnUrl ?? Url.Action("Index", "Product")));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect Username or Password");
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }
    }
}
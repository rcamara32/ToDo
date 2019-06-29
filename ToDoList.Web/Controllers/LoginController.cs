using System.Web.Mvc;
using System.Web.Security;
using ToDoList.Facade.Contracts;
using ToDoList.Facade.Dto.User;
using ToDoList.Web.Models;

namespace ToDoList.Web.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILoginApp loginApp;        

        public LoginController(ILoginApp _loginApp)
        {
            loginApp = _loginApp;
        }

        // GET: Login
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        // GET: Login/Register
        [AllowAnonymous]
        public ActionResult Register()
        {            
            return View(new RegisterViewModel());
        }

        // POST: /Login/SignIn
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(LoginViewModel model, string returnUrl)
        {

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            if (ModelState.IsValid)
            {
                var userExists = loginApp.ValidLogin(model.UserName, model.Password, out int userId);
                if (userExists)
                {
                    Session["userId"] = userId;
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    return RedirectToAction("Index", "Todo");
                }                
            }
            
            ModelState.AddModelError(string.Empty, "The username or password is incorrect");
            return View("Index", model);
        }

        // POST: /Login/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }

            if (ModelState.IsValid)
            {

                var registerDto = new RegisterDto
                {
                    Name = model.Name,
                    UserName = model.UserName,
                    Password = model.Password
                };

                var register = loginApp.Register(registerDto, out int userId);

                if (register)
                {
                    Session["userId"] = userId;
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Todo");
                }          
            }
            
            return View(model);
        }

        // GET: /Account/LogOff
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Login");
        }      

    }
}
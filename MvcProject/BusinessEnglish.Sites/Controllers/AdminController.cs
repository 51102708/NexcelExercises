namespace BusinessEnglish.Sites.Controllers
{
    using Models;
    using Services;
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    public class AdminController : Controller
    {
        private UserService userService = new UserService();

        public AdminController()
        {
            userService = new UserService();
        }

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Topics");
            }
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public ActionResult ExecuteLogin(AdminViewModel user)
        {
            if (ModelState.IsValid && ValidateUser(user))
            {
                return RedirectToAction("Index", "Topics");
            }

            ModelState.AddModelError("invalid_msg", "Invalid Username or Password");

            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            Response.Cookies.Clear();
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            authCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(authCookie);

            return RedirectToAction("Login");
        }

        private bool ValidateUser(AdminViewModel user)
        {
            var currentUser = userService.Get(user.UserName);

            if (currentUser != null)
            {
                if (currentUser.UserName.ToLower().Equals(user.UserName.ToLower()) && currentUser.Password.ToLower().Equals(user.Password.ToLower()))
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,
                    currentUser.UserName,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(60),
                    true,
                    currentUser.UserRoleId.ToString(),
                    FormsAuthentication.FormsCookiePath);

                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket));

                    return true;
                }
            }

            return false;
        }
    }
}
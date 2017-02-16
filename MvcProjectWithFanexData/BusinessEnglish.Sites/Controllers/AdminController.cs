namespace BusinessEnglish.Sites.Controllers
{
    using Resources;
    using Services;
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using ViewModels.Admin;

    public class AdminController : Controller
    {
        private UserService userService;

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
                HttpCookie httpCookie = HttpContext.Request?.Cookies[FormsAuthentication.FormsCookieName];

                if (IsAdminUser(httpCookie))
                {
                    return RedirectToAction("Index", "Topics");
                }

                return RedirectToAction("Unauthorized");
            }

            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public ActionResult ExecuteLogin(LoginViewModel user)
        {
            if (ModelState.IsValid && ValidateUser(user))
            {
                return RedirectToAction("Index", "Topics");
            }

            ModelState.AddModelError(string.Empty, StringResources.InvalidUsernamePassword);

            return View("Login");
        }

        public ActionResult Logout()
        {
            Response.Cookies.Clear();
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            authCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(authCookie);

            return RedirectToAction("Login");
        }

        public ActionResult Unauthorized()
        {
            return View();
        }

        private bool ValidateUser(LoginViewModel user)
        {
            var currentUser = userService.Get(user.UserName);

            if (currentUser != null)
            {
                if (currentUser.UserName.ToLower().Equals(user.UserName.ToLower()) && currentUser.Password.ToLower().Equals(user.Password.ToLower()))
                {
                    var ticket = new FormsAuthenticationTicket(
                    1,
                    currentUser.UserName,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(60),
                    true,
                    currentUser.UserRoleId.ToString(),
                    FormsAuthentication.FormsCookiePath);

                    var encryptedTicket = FormsAuthentication.Encrypt(ticket);

                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket));

                    return true;
                }
            }

            return false;
        }

        [NonAction]
        private bool IsAdminUser(HttpCookie httpCookie)
        {
            if (httpCookie != null)
            {
                var ticket = FormsAuthentication.Decrypt(httpCookie?.Value);

                if (ticket.UserData.Equals("1"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
namespace BusinessEnglish.Sites.Filters
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class BasicAuthenticationAttribute : AuthorizeAttribute
    {
        public new string Roles { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.HttpContext == null)
            {
                RedirectToLoginPage(filterContext);

                return;
            }

            HttpCookie httpCookie = filterContext.HttpContext.Request?.Cookies[FormsAuthentication.FormsCookieName];

            if (IsValidAuthentication(httpCookie))
            {
                return;
            }

            RedirectToLoginPage(filterContext);
        }

        private bool IsValidAuthentication(HttpCookie httpCookie)
        {
            if (httpCookie != null)
            {
                var ticket = FormsAuthentication.Decrypt(httpCookie?.Value);

                if (ticket == null || ticket.Expired || string.IsNullOrEmpty(ticket.UserData))
                {
                    return false;
                }

                if (Roles.Equals(ticket.UserData))
                {
                    return true;
                }
            }

            return false;
        }

        private void RedirectToLoginPage(AuthorizationContext filterContext)
        {
            var loginUrl = !string.IsNullOrWhiteSpace(FormsAuthentication.LoginUrl) ? FormsAuthentication.LoginUrl : "~/Admin/Login";

            filterContext.Result = new RedirectResult(loginUrl);
        }
    }
}
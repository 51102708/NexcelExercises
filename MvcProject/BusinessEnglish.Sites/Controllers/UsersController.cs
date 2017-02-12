namespace BusinessEnglish.Sites.Controllers
{
    using BusinessEnglish.Models;
    using Filters;
    using Services;
    using System.Net;
    using System.Web.Mvc;

    [BasicAuthentication(Roles = "1")]
    public class UsersController : Controller
    {
        private UserService userService = new UserService();

        public UsersController()
        {
            userService = new UserService();
        }

        public ActionResult Index()
        {
            ViewBag.UserRoleId = new SelectList(userService.GetAllRoles(), "Id", "RoleName");

            return View(userService.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password,UserRoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                userService.Create(user);

                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = userService.Get((int)id);

            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.UserRoleId = new SelectList(userService.GetAllRoles(), "Id", "RoleName", user.UserRoleId);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,UserRoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                userService.Update(user);

                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            userService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
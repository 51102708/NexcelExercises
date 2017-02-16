namespace DemoFanexData.Controllers
{
    using Core.Services;
    using System.Web.Mvc;

    public class NorthwindController : Controller
    {
        private ProductService productService;

        public NorthwindController()
        {
            productService = new ProductService();
        }

        public ActionResult GetTenMostExpansiveProducts()
        {
            return View(productService.GetTenMostExpensiveProducts());
        }

        // GET: Northwind
        public ActionResult Index()
        {
            return View();
        }

        // GET: Northwind/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Northwind/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Northwind/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Northwind/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Northwind/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Northwind/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Northwind/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
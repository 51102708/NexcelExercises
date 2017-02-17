namespace DemoFanexData.Controllers
{
    using Core.Services;
    using System.Web.Mvc;

    public class DemoController : Controller
    {
        private ProductService productService;

        public DemoController()
        {
            productService = new ProductService();
        }

        //Normal query
        public ActionResult NormalQuery()
        {
            return View(productService.GetTenMostExpensiveProducts());
        }

        //Multimapping
        public ActionResult Multimapping()
        {
            return View(productService.GetProductWithCategory(1));
        }

        //Repository - Normal
        public ActionResult Repository()
        {
            return View(productService.GetAll());
        }

        //Repository - Multiple
        public ActionResult RepositoryMulti()
        {
            return View(productService.GetAllProductsAndCategories());
        }
    }
}
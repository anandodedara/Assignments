using NLog;
using PMS.BLL;
using PMS.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsManagementSystem.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly List<PMS.Models.Category> categories;

        public readonly Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ProductsController(IProductManager productManager)
        {
            
            _productManager = productManager;
            categories = (List<PMS.Models.Category>)_productManager.GetCategories();
            
        }



        // GET: Products
        public ActionResult Index()
        {
            
            IEnumerable<PMS.Models.Product> productsList = _productManager.GetAllProducts();
            return View(productsList);

        }


        //Create new product view
        public ActionResult AddProduct()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(PMS.Models.Product product) {
            
            if (ModelState.IsValid)
            {
                _productManager.CreateProduct(product);

                return RedirectToAction("Index");
                
            }
            else {
                //Categories list for dropdown menu
                
                #region
                ViewBag.categoriesList = categories;
                #endregion
                return View(product);
            }
        }

        public ActionResult EditProduct(int id) {

            PMS.Models.Product product = _productManager.GetProductByID(id);
            return View(product);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProduct(PMS.Models.Product product) {
            
            if (ModelState.IsValid)
            {
                _productManager.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            else 
            {
                #region
                ViewBag.categoriesList = categories;
                #endregion
                return View(product);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id, string name) {
            
            _productManager.DeleteProduct(id);
            TempData["message"] = name + " deleted successfully.";
            TempData["messageType"] = "";
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMultiple(int[] list) {
            _productManager.DeleteMultipleProduct(list);
            TempData["message"] = list.Length + "Products deleted successfully.";
            TempData["messageType"] = "";
            return RedirectToAction("Index");
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            logger.Error(filterContext.Exception);
        }
    }
}
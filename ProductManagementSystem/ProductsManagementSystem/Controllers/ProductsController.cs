using PMS.BLL;
using PMS.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace ProductsManagementSystem.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly List<PMS.Models.Category> categories;

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
            #region
                ViewBag.categoriesList = categories;
            #endregion
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
            
            #region
            ViewBag.categoriesList = categories;
            #endregion
            string date = product.CreateDate.ToString();
                        
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
        public ActionResult DeleteProduct(int id) {

            _productManager.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMultiple(int[] list) {
            _productManager.DeleteMultipleProduct(list);
            TempData["message"] = list.Length + "Products deleted successfully.";
            return RedirectToAction("Index");
        }

    }
}
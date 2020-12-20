using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Controllers
{
    public class ProductsController : Controller
    {
        private ProductDbContext db = new ProductDbContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }



    


    // POST: Products/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (product.SmallImageFile != null) {
                
                String filename = product.Name + "_Small_" + DateTime.Now.ToString("yyyy-mm-dd-HH-mm-ss") + Path.GetExtension(product.SmallImageFile.FileName);
                string path = Server.MapPath("/Assets/Upload/Image/Small/");
                string fullpath = Path.Combine(path, filename);
                product.SmallImageUrl = "/Assets/Upload/Image/Small/" + filename;
                product.SmallImageFile.SaveAs(fullpath);

            }


            if (product.LargeImageFile != null) {

                string path = Server.MapPath("/Assets/Upload/Image/Large/");
                String filename = product.Name + "_Large_" + DateTime.Now.ToString("yyyy-mm-dd-HH-mm-ss") + Path.GetExtension(product.LargeImageFile.FileName);
                string fullpath = Path.Combine(path, filename);
                product.LargeImageUrl = "/Assets/Upload/Image/Large/" + filename;
                product.LargeImageFile.SaveAs(fullpath);
            }

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Products/Edit/5
        
        [HttpPost]
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View("Edit",product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Product product)
        {

            if (product.SmallImageFile != null)
            {

                String filename = product.Name + "_Small_" + DateTime.Now.ToString("yyyy-mm-dd-HH-mm-ss") + Path.GetExtension(product.SmallImageFile.FileName);
                string path = Server.MapPath("/Assets/Upload/Image/Small/");
                string fullpath = Path.Combine(path, filename);
                product.SmallImageUrl = "/Assets/Upload/Image/Small/" + filename;
                product.SmallImageFile.SaveAs(fullpath);

            }


            if (product.LargeImageFile != null)
            {

                string path = Server.MapPath("/Assets/Upload/Image/Large/");
                String filename = product.Name + "_Large_" + DateTime.Now.ToString("yyyy-mm-dd-HH-mm-ss") + Path.GetExtension(product.LargeImageFile.FileName);
                string fullpath = Path.Combine(path, filename);
                product.LargeImageUrl = "/Assets/Upload/Image/Large/" + filename;
                product.LargeImageFile.SaveAs(fullpath);
            }

            var local = db.Set<Product>().Local.FirstOrDefault(c => c.Id == product.Id);
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            

            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public void DeleteMultiple(int[] data) {

            for (int i = 0; i < data.Length; i++) {
                DeleteConfirmed(data[i]);
            }

        }


        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

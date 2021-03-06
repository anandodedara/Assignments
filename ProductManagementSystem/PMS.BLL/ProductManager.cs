﻿using NLog;
using PMS.BLL.Interface;
using PMS.DAL.Repository.Interface;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace PMS.BLL
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;
        public readonly Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ProductManager(IProductRepository productRepository)
        {
            
            _productRepository = productRepository;
            
        }

        public int CreateProduct(Product product)
        {
            try
            {
                string smallImagePath = "/App_Data/Upload/Images/Small/";
                string largeImagePath = "../App_Data/Upload/Images/Large/";

                if (product.SmallImageFile != null)
                {
                    String filename = product.Name + "_Small_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + Path.GetExtension(product.SmallImageFile.FileName);
                    string path = System.Web.HttpContext.Current.Server.MapPath(smallImagePath);
                    string fullpath = Path.Combine(path, filename);
                    product.SmallImageURL = smallImagePath + filename;
                    product.SmallImageFile.SaveAs(fullpath);


                }
                else
                    return 1;

                if (product.LargeImageFile != null)
                {
                    String filename = product.Name + "_Large_" + DateTime.Now.ToString("yyyy-mm-dd-HH-mm-ss") + Path.GetExtension(product.LargeImageFile.FileName);
                    string path = System.Web.HttpContext.Current.Server.MapPath(largeImagePath);
                    string fullpath = Path.Combine(path, filename);
                    product.LargeImageURL = largeImagePath + filename;
                    product.LargeImageFile.SaveAs(fullpath);

                }

                product.CreateDate = DateTime.Now;
                product.UpdateDate = DateTime.Now;
                //TODO: Set Created by and Updated by after login
                product.UpdatedBy = ((Models.User)HttpContext.Current.Session["UserDetails"]).Id;
                product.CreatedBy = ((Models.User)HttpContext.Current.Session["UserDetails"]).Id;

                return _productRepository.CreateProduct(product);
            }
            catch (Exception exception)
            {
                logger.Error(exception);
                return 1;
            }
        }

        public int DeleteMultipleProduct(int[] productIDList)
        {
            return _productRepository.DeleteMultipleProduct(productIDList);
        }

        public int DeleteProduct(int productID)
        {
            return _productRepository.DeleteProduct(productID);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public IEnumerable<Models.Category> GetCategories()
        {
             return _productRepository.GetCategories();
        }

        public Product GetProductByID(int productID)
        {
            PMS.DAL.Database.Product product = _productRepository.GetProductByID(productID);
            return new Product() {
                Id = product.Id,
                CategoryName = product.Category.Name,
                CreateDate = product.CreateDate,
                LargeImageURL = product.LargeImageURL,
                LongDescription = product.LongDescription,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                ShortDescription = product.ShortDescription,
                SmallImageURL = product.SmallImageURL,
            }; 
        }


        public int UpdateProduct(Models.Product product)
        {
            try
            {
                //TODO: Delete old product image after successfully update
                string smallImagePath = "/App_Data/Upload/Images/Small/";
                string largeImagePath = "../App_Data/Upload/Images/Large/";

                if (product.SmallImageFile != null)
                {
                    String filename = product.Name + "_Small_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + Path.GetExtension(product.SmallImageFile.FileName);
                    string path = System.Web.HttpContext.Current.Server.MapPath(smallImagePath);
                    string fullpath = Path.Combine(path, filename);
                    product.SmallImageURL = smallImagePath + filename;
                    product.SmallImageFile.SaveAs(fullpath);

                }
                else
                    return 1;

                if (product.LargeImageFile != null)
                {
                    String filename = product.Name + "_Large_" + DateTime.Now.ToString("yyyy-mm-dd-HH-mm-ss") + Path.GetExtension(product.LargeImageFile.FileName);
                    string path = System.Web.HttpContext.Current.Server.MapPath(largeImagePath);
                    string fullpath = Path.Combine(path, filename);
                    product.LargeImageURL = largeImagePath + filename;
                    product.LargeImageFile.SaveAs(fullpath);

                }



                product.UpdateDate = DateTime.Now;
                product.UpdatedBy = ((Models.User)HttpContext.Current.Session["UserDetails"]).Id;

                return _productRepository.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return 1;
            }
        }

        
       
    }


}

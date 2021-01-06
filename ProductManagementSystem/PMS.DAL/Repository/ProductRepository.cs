﻿using PMS.DAL.Database;
using PMS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PMS.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PMSDatabaseEntities _dbContext;

        public ProductRepository()
        {
            _dbContext = new PMSDatabaseEntities();
            
        }

        public int CreateProduct(Models.Product product)
        {
            if (product != null)
            {
                Database.Product entry = MapProductModelToProductContext(product);
                _dbContext.Products.Add(entry);
                _dbContext.SaveChanges();
                return 1;
            }
            return 0;
        }


        public int DeleteMultipleProduct(int[] productIDList)
        {
            foreach (var id in productIDList)
            {
                if (DeleteProduct(id)!=0)
                {
                    return 1;
                }
            }
            return 0;
        }

        public int DeleteProduct(int productID)
        {

            Database.Product product = GetProductByID(productID);
                if (product != null)
                    _dbContext.Products.Remove(product);
                else
                    return 1;
                _dbContext.SaveChanges();
            
            return 0;
        }

        public IEnumerable<Models.Product> GetAllProducts()
        {


            List<Product> products = _dbContext.Products.ToList();


            List<PMS.Models.Product> list = new List<Models.Product>();

            foreach (var item in products)
            {
                list.Add(new Models.Product
                { 
                    Id = item.Id,
                    CategoryName = _dbContext.Categories.Find(item.CategoryId).Name,
                    LargeImageURL = item.LargeImageURL,
                    LongDescription = item.LongDescription,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ShortDescription = item.ShortDescription,
                    SmallImageURL = item.SmallImageURL,
                    
                });
            }

            return list;
        }

        public List<Models.Category> GetCategories()
        {
            List<Models.Category> categoriesList = new List<Models.Category>();
            List<Category> categories = _dbContext.Categories.ToList();
            foreach (var item in categories)
            {
                categoriesList.Add(new Models.Category() {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return categoriesList;
        }

        public Database.Product GetProductByID(int productID)
        {
            if (productID != null) 
            {
                Product Product;
                Product = _dbContext.Products.Find(productID);
                return Product;
            }
            return null;
        }


        public Database.Product MapProductModelToProductContext(Models.Product productModel)
        {
            return new Database.Product() 
            {
                Id = productModel.Id,
                CategoryId = productModel.CategoryId,
                LargeImageURL = productModel.LargeImageURL,
                LongDescription = productModel.LongDescription,
                Name = productModel.Name,
                Price = productModel.Price,
                Quantity = productModel.Quantity,
                ShortDescription = productModel.ShortDescription,
                SmallImageURL = productModel.SmallImageURL,
                CreateDate = DateTime.Now,
                CreatedBy = productModel.CreatedBy,
                UpdateDate = productModel.UpdateDate,
                UpdatedBy = productModel.UpdatedBy
            };
        }


        public int UpdateProduct(Models.Product product)
        {
            //TODO: exception handling

            Database.Product updateItem = new Database.Product() { 
                Id = product.Id,
                CategoryId = product.CategoryId,
                CreatedBy = product.CreatedBy,
                CreateDate = GetProductByID(product.Id).CreateDate,
                LargeImageURL = product.LargeImageURL,
                LongDescription = product.LongDescription,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                ShortDescription = product.ShortDescription,
                SmallImageURL = product.SmallImageURL,
                UpdateDate = product.UpdateDate,
                UpdatedBy = product.UpdatedBy,
                
            };
            
            using (var context = new PMSDatabaseEntities())
            {
                context.Entry(updateItem).State = EntityState.Modified;
                context.SaveChanges(); 
            }
            return 0;
            
        }
    }
}
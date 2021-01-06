using PMS.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.Repository.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Models.Product> GetAllProducts();

        Database.Product GetProductByID(int productID);
        int CreateProduct(Models.Product product);
        int DeleteProduct(int productID);
        int UpdateProduct(Models.Product product);
        int DeleteMultipleProduct(int[] productIDList);
        List<Models.Category> GetCategories();
        DAL.Database.Product MapProductModelToProductContext(Models.Product productsModel);

        int getUserIdByEmail(string email);
    }
}

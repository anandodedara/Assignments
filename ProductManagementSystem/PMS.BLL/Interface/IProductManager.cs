using PMS.DAL.Database;
using System.Collections.Generic;

namespace PMS.BLL.Interface
{
    public interface IProductManager
    {
        IEnumerable<Models.Product> GetAllProducts();
        Models.Product GetProductByID(int productID);
        int CreateProduct(Models.Product product);
        int DeleteProduct(int productID);
        int UpdateProduct(Models.Product product);
        int DeleteMultipleProduct(int[] productIDList);

        IEnumerable<Models.Category> GetCategories();
        
    }
}

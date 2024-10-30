using BusinessObjects;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.DataAccessLayer;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProducts();
        public int GetMaxProductID() => ProductDAO.Instance.GetMaxProductID();
        public void SaveProduct(Product p) => ProductDAO.Instance.SaveProduct(p);

        public void UpdateProduct(Product p) => ProductDAO.Instance.UpdateProduct(p);

        public void DeleteProduct(Product p) => ProductDAO.Instance.DeleteProduct(p);

        public Product? GetProductById(int id) => ProductDAO.Instance.GetProductById(id);

    }
}
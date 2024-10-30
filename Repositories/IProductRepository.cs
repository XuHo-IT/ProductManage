using System.Collections;
using System.Collections.Generic;
using BusinessObjects;

namespace Repositories
{
    public interface IProductRepository
    {
      
            IEnumerable<Product> GetProducts();
            int GetMaxProductID();

            void SaveProduct(Product p);

            void UpdateProduct(Product p);

            void DeleteProduct(Product p);

            Product? GetProductById(int id);

        }
    }
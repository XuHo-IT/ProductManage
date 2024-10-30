using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    namespace DataAccessLayer
    {
        public class ProductDAO
        {
            private static ProductDAO instance = null;
            private static readonly object instanceLock = new object();

            public MyStoreContext _context;

            public static ProductDAO Instance
            {
                get
                {
                    lock (instanceLock)
                    {
                        if (instance == null)
                        {
                            instance = new ProductDAO();
                        }
                        return instance;
                    }
                }
            }

            public void SaveProduct(Product p)
            {
                _context = new();
                _context.Products.Add(p);
                _context.SaveChanges();
            }

            public void UpdateProduct(Product p)
            {
                _context = new();
                _context.Products.Update(p);
                _context.SaveChanges();
            }

            public void DeleteProduct(Product p)
            {
                _context = new();
                _context.Products.Remove(p);
                _context.SaveChanges();
            }
            public IEnumerable<Product> GetProducts()
            {
                _context = new();
                return _context.Products.ToList();
            }
            public Product? GetProductById(int productId)
            {
                return _context.Products.FirstOrDefault(p => p.ProductId == productId);
            }


            public int GetMaxProductID()
            {
                try
                {
                    using (var db = new MyStoreContext())
                    {
                        int maxId = db.Products.DefaultIfEmpty().Max(p => p.ProductId);
                        return maxId + 1;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}

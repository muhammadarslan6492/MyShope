using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShope.Core.Models;

namespace MyShope.DataAccess.InMemory
{
   public class ProductRepositroy
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepositroy()
        {
            products = cache["products"] as List<Product>;

            if (products == null)
            {
                products = new List<Product>();
            }
        }

        public void commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product p)
        {
            products.Add(p);
        }

        public void Update(Product product)
        {
            Product UpdateProducts = products.Find(p => p.Id == product.Id);

            if (UpdateProducts != null)
            {
                UpdateProducts = product;
            }
            else
            {
                throw new Exception("product Not Found");
            }
           
        }

        public Product Find(string Id)
        {
            Product product = products.Find(p => p.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("product Not Found");
            }
        }
         public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string Id)
        {
            Product ProductDelete = products.Find(P => P.Id == Id);

            if (ProductDelete != null)
            {

                products.Remove(ProductDelete);
            }
            else
            {
                throw new Exception("Product NOT found");
            }
        }
   
    }
}

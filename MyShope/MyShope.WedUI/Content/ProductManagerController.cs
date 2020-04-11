using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShope.Core.Models;
using MyShope.DataAccess.InMemory;

namespace MyShope.WedUI.Content
{
    public class ProductManagerController : Controller
    {
        ProductRepositroy context;

        public ProductManagerController()
        {
            context = new ProductRepositroy();
        }


        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            Product product = new Product();

            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(product);
            }

        }

        [HttpPost]
        public ActionResult EditDetail(Product product , string Id)
        {

            Product EditProduct = context.Find(Id);

            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {

                if (!ModelState.IsValid)
                {
                    return View(product);

                }
                EditProduct.Category = product.Category;
                EditProduct.Name = product.Name;
                EditProduct.Image = product.Image;
                EditProduct.Price = product.Price;

                context.commit();

                return RedirectToAction("Index");
            }
        }

       public  ActionResult Delete(string Id)
        {
            Product productDelete = context.Find(Id);

            if (productDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product ConformtDelete = context.Find(Id);

            if (ConformtDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.commit();
                return RedirectToAction("Index");
            }
        }

    }



}
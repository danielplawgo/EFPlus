using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace EFPlus
{
    public class FutureDemo
    {
        public void Run()
        {
            //WithoutFuture();
            WithFuture();
        }

        private void WithoutFuture()
        {
            using (var db = new DataContext())
            {
                var categoryQuery = db.Categories.Where(c => c.Id == 1);

                var productQuery = db.Products.Where(c => c.Id == 1);

                var category = categoryQuery.FirstOrDefault();

                var product = productQuery.FirstOrDefault();

                Console.WriteLine($"Category: {category.Name}, Product: {product.Name}");
            }
        }

        private void WithFuture()
        {
            using (var db = new DataContext())
            {
                var categoryQuery = db.Categories.Where(c => c.Id == 1).Future();

                var productQuery = db.Products.Where(c => c.Id == 1).Future();

                var category = categoryQuery.FirstOrDefault();

                var product = productQuery.FirstOrDefault();

                Console.WriteLine($"Category: {category.Name}, Product: {product.Name}");
            }
        }
    }
}

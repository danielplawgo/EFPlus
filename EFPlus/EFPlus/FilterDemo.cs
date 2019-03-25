using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace EFPlus
{
    public class FilterDemo
    {
        public void Run()
        {
            LocalFilter();
            //GlobalFilter();
            //NoFilter();
            //IncludeWithoutFilter();
            //IncludeWithFilter();
        }

        private void LocalFilter()
        {
            using (var db = new DataContext())
            {
                db.Filter<Product>(q => q.Where(p => p.IsActive));

                var count = db.Products.Count();

                Console.WriteLine($"Products count: {count}");

                var category = db.Categories.FirstOrDefault();

                count = category.Products.Count;

                Console.WriteLine($"Products count in category {category.Name}: {count}");
            }
        }

        private void GlobalFilter()
        {
            QueryFilterManager.Filter<Product>(q => q.Where(p => p.IsActive));

            using (var db = new DataContext())
            {
                var count = db.Products.Count();

                Console.WriteLine($"Products count: {count}");
            }

            using (var db = new DataContext())
            {
                var category = db.Categories.FirstOrDefault();

                var count = category.Products.Count;

                Console.WriteLine($"Products count in category {category.Name}: {count}");
            }
        }

        private void NoFilter()
        {
            QueryFilterManager.Filter<Product>(q => q.Where(p => p.IsActive));

            using (var db = new DataContext())
            {
                var count = db.Products.AsNoFilter().Count();

                Console.WriteLine($"Products count: {count}");
            }
        }

        private void IncludeWithoutFilter()
        {
            using (var db = new DataContext())
            {
                var categories = db.Categories.Include(c => c.Products).ToList();

                Console.WriteLine($"Products count: {categories.Count}");
            }
        }

        private void IncludeWithFilter()
        {
            using (var db = new DataContext())
            {
                db.Filter<Product>(q => q.Where(p => p.IsActive));

                var categories = db.Categories.Include(c => c.Products).ToList();

                Console.WriteLine($"Products count: {categories.Count}");
            }
        }
    }
}

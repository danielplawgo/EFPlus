using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace EFPlus
{
    public class CacheDemo
    {
        public void Run()
        {
            //WithoutCache();
            WithCache();
        }

        private void WithoutCache()
        {
            using (var db = new DataContext())
            {
                var categories = db.Categories.Where(c => c.IsActive).ToList();

                Console.WriteLine($"Categories count: {categories.Count}");

                categories = db.Categories.Where(c => c.IsActive).ToList();

                Console.WriteLine($"Categories count: {categories.Count}");
            }
        }

        private void WithCache()
        {
            using (var db = new DataContext())
            {
                var categories = db.Categories.Where(c => c.IsActive).FromCache().ToList();

                Console.WriteLine($"Categories count: {categories.Count}");

                categories = db.Categories.Where(c => c.IsActive).FromCache().ToList();

                Console.WriteLine($"Categories count: {categories.Count}");
            }
        }
    }
}

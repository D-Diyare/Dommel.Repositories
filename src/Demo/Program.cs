using System;
using System.Linq;
using Dommel.Repositories.Demo.Connection;
using Dommel.Repositories.Demo.Entities;
using Dommel.Repositories.Demo.UnitOfWork;

namespace Dommel.Repositories.Demo
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            #region Insert Category

            // var product = new Category {Name = "Foods"};
            // InsertCategory(product);

            #endregion

            #region Read Category

            // ReadCategories();

            ReadCategoryById(1);

            #endregion

            #region Insert Product

            // var product = new Product
            // {
            // 	CategoryId = 1,
            // 	Name = "Egg",
            // 	Quantity = 13
            // };
            //
            // InsertProduct(product);

            #endregion

            #region Read Products

            // ReadProducts();

            #endregion
        }

        private static void InsertCategory(Category category)
        {
            using var context = new AppDbContext(new DbConnection(), new ConnectionHelper());

            var result = (long) context.Categories.Insert(category) > 0;

            result &= context.SaveChanges();

            if (result)
                Console.WriteLine($"{category.Name} Successfully Inserted.");
        }

        private static void ReadCategories()
        {
            using var context = new AppDbContext(new DbConnection(), new ConnectionHelper());
            var categories = context.Categories.GetAll();
            foreach (var category in categories)
            {
                Console.WriteLine($" Category Id : {category.Id} \n Category Name : {category.Name}");
            }
        }

        private static void ReadCategoryById(int id)
        {
            using var context = new AppDbContext(new DbConnection(), new ConnectionHelper());

            var category = context.Categories.GetById<Product>(id);
            Console.WriteLine(
                $" Category Id : {category.Id} \n Category Name : {category.Name} \n Product : {category.Products.FirstOrDefault()?.Name}");
        }

        private static void UpdateCategory(Category category)
        {
            using var context = new AppDbContext(new DbConnection(), new ConnectionHelper());

            var result = context.Categories.Update(category);

            result &= context.SaveChanges();

            if (result)
                Console.WriteLine($"Successfully Updated.");
        }

        private static void DeleteCategory(Category category)
        {
            using var context = new AppDbContext(new DbConnection(), new ConnectionHelper());

            var result = context.Categories.Delete(category);

            result &= context.SaveChanges();

            if (result)
                Console.WriteLine($"Successfully Deleted.");
        }

        private static void InsertProduct(Product product)
        {
            using var context = new AppDbContext(new DbConnection(), new ConnectionHelper());

            var result = (long) context.Products.Insert(product) > 0;

            result &= context.SaveChanges();

            if (result)
                Console.WriteLine($"{product.Name} Successfully Inserted.");
        }

        private static void ReadProducts()
        {
            using var context = new AppDbContext(new DbConnection(), new ConnectionHelper());

            // Get Product with its category.
            var products = context.Products.GetAll<Category>();

            foreach (var product in products)
            {
                Console.WriteLine(
                    $" Product Id : {product.Id} \n Product Name : {product.Name} \n CategoryName : {product.Category?.Name}");
            }
        }

        private static void ReadProductById(int id)
        {
            using var context = new AppDbContext(new DbConnection(), new ConnectionHelper());

            var product = context.Products.GetById(id);

            Console.WriteLine(
                $" Product Id : {product.Id} \n Product Name : {product.Name} \n CategoryName : {product.Category?.Name}");
        }

        private static void UpdateProduct(Product product)
        {
            using var context = new AppDbContext(new DbConnection(), new ConnectionHelper());

            var result = context.Products.Update(product);

            result &= context.SaveChanges();

            if (result)
                Console.WriteLine($"Successfully Updated.");
        }

        private static void DeleteProduct(Product product)
        {
            using var context = new AppDbContext(new DbConnection(), new ConnectionHelper());

            var result = context.Products.Delete(product);

            result &= context.SaveChanges();

            if (result)
                Console.WriteLine($"Successfully Deleted.");
        }
    }
}
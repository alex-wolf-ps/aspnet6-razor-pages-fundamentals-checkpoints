using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using WiredBrainCoffeeAdmin.Data;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint13
    {
        [Fact]
        public void CH13_VerifyGetItemsList()
        {
            var options = new DbContextOptionsBuilder<WiredContext>()
           .UseInMemoryDatabase(databaseName: "WiredBrain")
           .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new WiredContext(options))
            {
                context.Products.Add(new Product
                {
                    Id = 1,
                    Name = "AAA",
                    Category = "Food",
                    Description = "blah",
                    Price = 5,
                    ShortDescription = "blah"
                });
                context.Products.Add(new Product
                {
                    Id = 2,
                    Name = "BBB",
                    Category = "Food",
                    Description = "blah",
                    Price = 5,
                    ShortDescription = "blah"
                });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new WiredContext(options))
            {
                ProductRepository movieRepository = new ProductRepository(context);
                List<Product> products = movieRepository.GetAll();

                Assert.Equal(2, products.Count);
            }
        }

        [Fact]
        public void CH13_VerifyGetItemById()
        {
            var options = new DbContextOptionsBuilder<WiredContext>()
           .UseInMemoryDatabase(databaseName: "WiredBrain")
           .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new WiredContext(options))
            {
                context.Products.Add(new Product
                {
                    Id = 1,
                    Name = "AAA",
                    Category = "Food",
                    Description = "blah",
                    Price = 5,
                    ShortDescription = "blah"
                });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new WiredContext(options))
            {
                ProductRepository productRepository = new ProductRepository(context);
                var product = productRepository.GetById(1);

                Assert.Equal("AAA", product.Name);
            }
        }
    }
}
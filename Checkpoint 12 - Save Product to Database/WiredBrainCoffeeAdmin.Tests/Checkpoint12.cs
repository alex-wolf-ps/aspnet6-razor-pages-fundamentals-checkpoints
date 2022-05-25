using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using WiredBrainCoffeeAdmin.Data;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint12
    {
        [Fact]
        public void CH12_VerifyAddProduct()
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

                var products = context.Products.ToList();

                Assert.Equal(1, products.Count);
            }

            // Use a clean instance of the context to run the test
            using (var context = new WiredContext(options))
            {
                ProductRepository productRepository = new ProductRepository(context);
                productRepository.Add(new Product
                {
                    Id = 2,
                    Name = "BBB",
                    Category = "Food",
                    Description = "blah",
                    Price = 5,
                    ShortDescription = "blah"
                });

                var products = context.Products.ToList();

                Assert.Equal(2, products.Count);
            }
        }
    }
}
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using WiredBrainCoffeeAdmin.Data;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint14
    {
        [Fact]
        public void CH14_VerifyDeleteItem()
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
                    Description = "Test",
                    Price = 5,
                    ShortDescription = "Test"
                });
                context.Products.Add(new Product
                {
                    Id = 2,
                    Name = "BBB",
                    Category = "Food",
                    Description = "Test",
                    Price = 5,
                    ShortDescription = "Test"
                });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new WiredContext(options))
            {
                ProductRepository productRepository = new ProductRepository(context);
                productRepository.Delete(1);

                var products = productRepository.GetAll();

                Assert.Equal(1, products.Count);
            }
        }
    }
}
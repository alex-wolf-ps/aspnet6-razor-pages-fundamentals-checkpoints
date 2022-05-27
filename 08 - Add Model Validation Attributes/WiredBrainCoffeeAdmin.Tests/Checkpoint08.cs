using HtmlAgilityPack;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using WiredBrainCoffeeAdmin.Data;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint08
    {
        [Fact]
        public void CH08_AddValidationAttributes()
        {
            var productModel = typeof(Product);

            Assert.True(productModel != null, "`Task` class was not found, ensure `Task.cs` contains a `public` class `Task`.");

            var nameAttrs = productModel.GetProperty("Name").GetCustomAttributesData();
            var requiredAttr = nameAttrs.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));

            Assert.True(requiredAttr != null,
                "The `Name` property of the `Product` class should be marked with the `[Required]` attribute.");

            var descAttrs = productModel.GetProperty("Description").GetCustomAttributesData();
            var requiredAttr2 = descAttrs.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));

            Assert.True(requiredAttr2 != null,
                "The `Description` property of the `Product` class should be marked with the `[Required]` attribute.");

            var shortDescAttrs = productModel.GetProperty("ShortDescription").GetCustomAttributesData();
            var requiredAttr3 = shortDescAttrs.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));

            Assert.True(requiredAttr3 != null,
                "The `ShortDescription` property of the `Product` class should be marked with the `[Required]` attribute.");

            var priceAttrs = productModel.GetProperty("Price").GetCustomAttributesData();
            var requiredAttr4 = priceAttrs.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));

            Assert.True(requiredAttr4 != null,
                "The `Price` property of the `Product` class should be marked with the `[Required]` attribute.");

            var catAttrs = productModel.GetProperty("Category").GetCustomAttributesData();
            var requiredAttr5 = catAttrs.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));

            Assert.True(requiredAttr5 != null,
                "The `Category` property of the `Product` class should be marked with the `[Required]` attribute.");

        }
    }
}
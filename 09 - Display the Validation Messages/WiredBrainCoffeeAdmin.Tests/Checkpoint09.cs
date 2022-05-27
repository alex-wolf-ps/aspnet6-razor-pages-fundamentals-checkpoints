using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint09
    {
        [Fact]
        public void CH09_VerifyValidationMessages()
        {
            var filePath = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "ProductForm.cshtml";

            Assert.True(File.Exists(filePath), "`ProductForm.cshtml` should exist in the `Pages` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var divTags = doc.DocumentNode.Descendants("div").Where(x => x.Attributes["asp-validation-summary"] != null);

            Assert.True(divTags.Count() > 0, "The product form should contain a div with the `asp-validation-summary` attribute.");
        }
    }
}
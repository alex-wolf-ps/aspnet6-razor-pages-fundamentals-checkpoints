using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint10
    {

        [Fact]
        public void CH10_VerifyRedirect()
        {
            var filePath = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "Products"
                + Path.DirectorySeparatorChar + "AddProduct.cshtml.cs";

            Assert.True(File.Exists(filePath), "`ProductForm.cshtml` should exist in the `Pages/Products` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var divTags = doc.DocumentNode.Descendants("div").Where(x => x.Attributes["asp-validation-summary"] != null);

            Assert.True(doc.Text.Contains("RedirectToPage(\"ViewAllProducts\")"), "The `AddProduct` page should use an action result to redirect to the `ViewAllProducts` page on submit.");
        }
    }
}
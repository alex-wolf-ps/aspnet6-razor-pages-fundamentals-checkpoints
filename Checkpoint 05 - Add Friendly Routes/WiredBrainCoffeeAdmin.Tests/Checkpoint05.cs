using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint05
    {
        [Fact]
        public void CH05_VerifyFriendlyRoutes()
        {
            var filePath = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "Products"
                + Path.DirectorySeparatorChar + "AddProduct.cshtml";

            Assert.True(File.Exists(filePath), "`AddProduct.cshtml` should exist in the `Pages/Products` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.True(doc.Text.Contains("@page \"/products/add\""));


            var filePath2 = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "Products"
                + Path.DirectorySeparatorChar + "ViewAllProducts.cshtml";

            Assert.True(File.Exists(filePath2), "`ViewAllProducts.cshtml` should exist in the `Pages/Products` folder.");

            var doc2 = new HtmlDocument();
            doc2.Load(filePath2);

            Assert.True(doc2.Text.Contains("@page \"/products/all\""));
        }
    }
}
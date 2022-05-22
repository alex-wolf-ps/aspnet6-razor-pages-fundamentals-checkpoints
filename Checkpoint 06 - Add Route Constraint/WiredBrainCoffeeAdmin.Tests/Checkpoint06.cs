using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint06
    {
        [Fact]
        public void CH06_VerifyRouteParam()
        {
            var filePath2 = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "Products"
                + Path.DirectorySeparatorChar + "EditProduct.cshtml";

            Assert.True(File.Exists(filePath2), "`EditProduct.cshtml` should exist in the `Pages/Products` folder.");

            var doc2 = new HtmlDocument();
            doc2.Load(filePath2);

            Assert.True(doc2.Text.Contains("@page \"/products/edit/{id:int}\""));
        }
    }
}
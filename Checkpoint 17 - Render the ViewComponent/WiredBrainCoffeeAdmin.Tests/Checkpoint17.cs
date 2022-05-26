using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint17
    {
        [Fact]
        public void CH17_VerifyViewComponentDisplay()
        {
            var filePath = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "Index.cshtml";

            Assert.True(File.Exists(filePath), "`Index.cshtml` should exist in the Pages folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.True(doc.Text.Contains("@await Component.InvokeAsync(\"ProductList\")")
                || doc.Text.Contains("@await  Component.InvokeAsync(\"ProductList\")")
                || doc.Text.Contains("@await Component.InvokeAsync(\"ProductList\")")
                || doc.Text.Contains("@await Component.InvokeAsync( \"ProductList\")")
                || doc.Text.Contains("@await Component.InvokeAsync(\"ProductList\")" ),
                "The index page does not include code to display a view component.");
        }
    }
}
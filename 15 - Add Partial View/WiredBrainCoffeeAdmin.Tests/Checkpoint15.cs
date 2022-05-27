using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint15
    {
        [Fact]
        public void CH15_VerifyPartialInclude()
        {
            var filePath = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "Index.cshtml";

            Assert.True(File.Exists(filePath), "`Index.cshtml` should exist in the `Pages/Products` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.True(doc.Text.Contains("<partial name=\"HelpWidget\" />") || doc.Text.Contains("<partial name=\"HelpWidget\"/>")
                 || doc.Text.Contains("<partial name=\"HelpWidget\"></partial>"));
        }
    }
}
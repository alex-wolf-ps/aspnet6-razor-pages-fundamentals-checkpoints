using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint04
    {
        [Fact]
        public void M04_VerifyLayoutSection()
        {
            var filePath = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "Shared"
                + Path.DirectorySeparatorChar + "_Layout.cshtml";

            Assert.True(File.Exists(filePath), "`_Layout.cshtml` should exist in the `Pages/Shared` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.True(doc.Text.Contains("IsSectionDefined(\"RightFooter\")"));
            Assert.True(doc.Text.Contains("@RenderSection(\"RightFooter\")"));
        }
    }
}
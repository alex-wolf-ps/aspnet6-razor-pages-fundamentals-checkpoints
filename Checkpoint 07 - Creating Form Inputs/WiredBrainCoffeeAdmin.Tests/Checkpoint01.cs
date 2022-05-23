using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint07
    {
        [Fact]
        public void CH07_VerifyFormInputs()
        {
            var filePath = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "ProductForm.cshtml";

            Assert.True(File.Exists(filePath), "`ProductForm.cshtml` should exist in the `Pages` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var inputTags = doc.DocumentNode.Descendants("input");

            foreach (var input in inputTags)
            {
                Assert.True(input.Attributes["asp-for"] != null && input.Attributes["asp-for"].Value.Contains("@Model"),
                    "Every form input should include the `asp-for` attribute with the corresponding model property assigned.");
            }

            var selectTags = doc.DocumentNode.Descendants("select");

            foreach (var select in selectTags)
            {
                Assert.True(select.Attributes["asp-for"] != null && select.Attributes["asp-for"].Value.Contains("@Model"),
                    "Every form select element should include the `asp-for` attribute with the corresponding model property assigned.");
            }
        }
    }
}
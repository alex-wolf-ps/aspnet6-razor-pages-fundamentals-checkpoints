using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint02
    {

        [Fact]
        public void M03_VerifyNavLinks()
        {
            var filePath = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "Shared"
                + Path.DirectorySeparatorChar + "_Layout.cshtml";

            Assert.True(File.Exists(filePath), "`_Layout.cshtml` should exist in the Shared folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var ulTag = doc.DocumentNode.Descendants("ul")?.FirstOrDefault();

            Assert.True(ulTag != null && ulTag.Descendants("li") != null,
                "`LeftNav.razor` should contain a `ul` element with child `li` elements.");

            var firstLinkAttributes = ulTag.Descendants("li").ElementAt(0)
                .Descendants("a").FirstOrDefault().Attributes;
            Assert.True(firstLinkAttributes["asp-page"]?.Value.ToLower() == "/index",
                "The first navigation link should contain an `asp-page` attribute pointing to the `/Index` page.");
            
            var secondLinkAttributes = ulTag.Descendants("li").ElementAt(1)
                .Descendants("ul").FirstOrDefault()
                .Descendants("li").FirstOrDefault()
                .Descendants("a").FirstOrDefault().Attributes;
            Assert.True(secondLinkAttributes["asp-page"]?.Value.ToLower() == "/products/viewallproducts",
                "The second navigation link should contain an `asp-page` attribute pointing to the `/Products/ViewAllProducts` page.");

            var thirdLinkAttributes = ulTag.Descendants("li").ElementAt(1)
                .Descendants("ul").FirstOrDefault()
                .Descendants("li").ElementAt(1)
                .Descendants("a").FirstOrDefault().Attributes;
            Assert.True(thirdLinkAttributes["asp-page"]?.Value.ToLower() == "/products/addproduct",
                "The third navigation link should contain an `asp-page` attribute pointing to the `/Products/AddProduct` page.");

            var fourthLinkAttributes = ulTag.Descendants("li").ElementAt(4)
                .Descendants("a").FirstOrDefault().Attributes;
            Assert.True(fourthLinkAttributes["asp-page"]?.Value.ToLower() == "/help",
                "The fourth navigation link should contain an `asp-page` attribute pointing to the `/Help` page.");
        }
    }
}
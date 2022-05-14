using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint03
    {
        [Fact]
        public void M03_VerifyTagHelper()
        {
            var filePath = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "Shared"
                + Path.DirectorySeparatorChar + "_Layout.cshtml";

            Assert.True(File.Exists(filePath), "`_Layout.cshtml` should exist in the Shared folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var envTags = doc.DocumentNode.Descendants("environment");

            Assert.True(envTags != null,
                "`_Layout.razor` should contain two `environment` element.");

            var firstEnvLink = envTags.FirstOrDefault().Descendants("link").FirstOrDefault();
            Assert.True(firstEnvLink != null,
                "The first `environment` element should contain a `link` element that includes `~/lib/bootstrap/dist/css/bootstrap.css`.");

            var secEnvLink = envTags.ElementAt(1).Descendants("link").FirstOrDefault();
            Assert.True(secEnvLink != null,
                "The first `environment` element should contain a `link` element that includes `~/lib/bootstrap/dist/css/bootstrap.css`.");
        }
    }
}
using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint18
    {
        [Fact]
        public void CH18_VerifyHttpClientRegistration()
        {
            var filePath = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Program.cs";

            Assert.True(File.Exists(filePath), "`Program.cs` should exist in the project root.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.True(doc.Text.Contains("builder.Services.AddHttpClient()"), "`Program.cs` should include code to register the HttpClient.");
        }
    }
}
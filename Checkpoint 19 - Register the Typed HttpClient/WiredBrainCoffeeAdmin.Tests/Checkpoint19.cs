using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint19
    {
        [Fact]
        public void CH19_VerifyTypedHttpClientRegistration()
        {
            var filePath = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Program.cs";

            Assert.True(File.Exists(filePath), "`Program.cs` should exist in the project root.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.True(doc.Text.Replace(" ", "").Contains("builder.Services.AddHttpClient<ITicketService,TicketService>()"),
                "`Program.cs` should include code to register a typed HttpClient for the ticket service.");
        }
    }
}
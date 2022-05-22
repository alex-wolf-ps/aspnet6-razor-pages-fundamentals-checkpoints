using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint01
    {
        [Fact]
        public void M03_VerifyRazorConditional()
        {
            var filePath = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "Index.cshtml";

            Assert.True(File.Exists(filePath), "`Index.cshtml` should exist in the Pages folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            //var pattern = @"<\s*?table\s*?>[\s\S]*?@foreach\s*?[(]\s*?(var|SurveyItem)\s*item\s*in\s*Model.SurveyResults\s*?[)]\s*?{\s*?<\s*?[tT][rR]\s*?>\s*?<[tT][dD]>\s*?@item.Question\s*?<\s*?\/\s*?[tT][dD]\s*?>\s*?\s*?<[tT][dD]>\s*?@item.Answer\s*?<\s*?\/\s*?[tT][dD]\s*?>\s*?<\/\s*?[tT][rR]\s*?>\s*?}\s*?<\s*?\/table\s*?>";
            var pattern = @"@foreach\s*?[(]\s*?(var|SurveyItem)\s*item\s*in\s*Model.SurveyResults\s*?[)]\s*?{\s*?<\s*?[tT][rR]\s*?>\s*?<[tT][dD]>\s*?@item.Question\s*?<\s*?\/\s*?[tT][dD]\s*?>\s*?\s*?<[tT][dD]>\s*?@item.Answer\s*?<\s*?\/\s*?[tT][dD]\s*?>\s*?<\/\s*?[tT][rR]\s*?>\s*?}";
            var rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`Index.cshtml does not appear to contain a `table` with a `foreach` loop that creates rows and columns for the `SurveyResults`.");
        }
    }
}
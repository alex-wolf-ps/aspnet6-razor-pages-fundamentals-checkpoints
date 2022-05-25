using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using WiredBrainCoffeeAdmin.Data;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint11
    {
        [Fact]
        public void CH11_VerifyDbSet()
        {
            var filePath = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
                + Path.DirectorySeparatorChar + "Data"
                + Path.DirectorySeparatorChar + "WiredBrainContext.cs";

            Assert.True(File.Exists(filePath), "`WiredBrainContext.cs` should exist in the `Data` folder.");

            var props = typeof(WiredBrainContext).GetProperties();

            var dbset = props.FirstOrDefault(x => x.Name == "Products");
            var accessor = dbset.GetAccessors().FirstOrDefault(x => x.IsPublic);
            Assert.True(dbset.PropertyType.Name.Contains("DbSet") && accessor.IsPublic);
        }
    }
}
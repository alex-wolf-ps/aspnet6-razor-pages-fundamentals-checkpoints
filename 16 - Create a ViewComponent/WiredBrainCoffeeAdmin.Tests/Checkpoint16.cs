using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using WiredBrainCoffeeAdmin.Components;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint16
    {
        [Fact]
        public void M03_VerifyViewComponent()
        {
            var filePath = TestHelpers.GetRootString() + "WiredBrainCoffeeAdmin"
            + Path.DirectorySeparatorChar + "Components"
            + Path.DirectorySeparatorChar + "ProductListViewComponent.cs";

            Assert.True(File.Exists(filePath), "`ProductListViewComponent.cs` should exist in the `Components` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var methods = typeof(ProductListViewComponent).GetMethods();

            var invoke = methods.FirstOrDefault(x => x.Name == "Invoke");
            var invokeAsync = methods.FirstOrDefault(x => x.Name == "InvokeAsync");
            var baseName = typeof(ProductListViewComponent).BaseType.Name;

            Assert.True(
                doc.Text.Contains("productRepo.GetAll") && 
                (invoke != null || invokeAsync != null)
                && invoke.ReturnType == typeof(IViewComponentResult) || invokeAsync.ReturnType == typeof(IViewComponentResult)
                && baseName.Contains("ViewComponent"));
        }
    }
}
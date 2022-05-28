using Microsoft.AspNetCore.Mvc;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Components
{
    public class ProductListViewComponent : ViewComponent
    {
        private IProductRepository productRepo;

        public ProductListViewComponent(IProductRepository productRepository)
        {
            this.productRepo = productRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View(this.productRepo.GetAll());
        }
    }
}

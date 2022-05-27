using Microsoft.AspNetCore.Mvc;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Components
{
    public class ProductListViewComponent
    {
        private IProductRepository productRepo;

        public ProductListViewComponent(IProductRepository productRepository)
        {
            this.productRepo = productRepository;
        }
    }
}

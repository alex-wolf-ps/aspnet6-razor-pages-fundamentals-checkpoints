using Microsoft.EntityFrameworkCore;

namespace WiredBrainCoffeeAdmin.Data
{
    public class ProductRepository : IProductRepository
    {
        private WiredContext wiredContext;

        public ProductRepository(WiredContext context)
        {
            this.wiredContext = context;
        }

        public void Add(Product product)
        {
            // Ignore for now
        }

        public void Delete(int id)
        {
            var productToDelete = this.wiredContext.Products.FirstOrDefault(p => p.Id == id);
            wiredContext.Products.Remove(productToDelete);
            wiredContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            // Ignore for now
            return null;
        }

        public Product GetById(int id)
        {
            // Ignore for now
            return null;
        }

        public void Update(Product product)
        {
            // Ignore for now
        }
    }
}

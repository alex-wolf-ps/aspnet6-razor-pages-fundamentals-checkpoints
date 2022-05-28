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
            wiredContext.Products.Add(product);
            wiredContext.SaveChanges();
        }

        public void Delete(int id)
        {
            // TODO: Implement this later
        }

        public List<Product> GetAll()
        {
            // TODO: Implement this later

            return null;
        }

        public Product GetById(int id)
        {
            // TODO: Implement this later

            return null;
        }

        public void Update(Product product)
        {
            // TODO: Implement this later
        }
    }
}

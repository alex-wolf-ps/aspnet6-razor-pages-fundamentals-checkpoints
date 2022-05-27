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
            // Add code to delete an item from the database using the id
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

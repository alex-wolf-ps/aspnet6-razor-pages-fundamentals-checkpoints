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
            // Ignore this for now
        }

        public void Delete(int id)
        {
            // Ignore this for now
        }

        public List<Product> GetAll()
        {
            // Add logic to get all the products
            return null;
        }

        public Product GetById(int id)
        {
            // Add logic to get one product by its id
            return null;
        }

        public void Update(Product product)
        {
            // Ignore this for now
        }
    }
}

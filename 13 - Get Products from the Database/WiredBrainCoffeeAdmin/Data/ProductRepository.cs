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
            // TODO: Implement this later
        }

        public void Delete(int id)
        {
            // TODO: Implement this later
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
            // TODO: Implement this later
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace WiredBrainCoffeeAdmin.Data
{
    // This is hidden here so the project compiles, use the other DbContext for the checkpoint
    public class WiredContext : DbContext
    {
        public WiredContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 27,
                    Name = "Designer Espresso",
                    ShortDescription = "Caffine has never looked so stunning.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFileName = "design.png",
                    Price = 6.5M,
                    Category = "Coffee",
                },
                new Product()
                {
                    Id = 28,
                    Name = "Cappucino",
                    ShortDescription = "Rich and foamy comfort coffee.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFileName = "cup.png",
                    Price = 4.5M,
                    Category = "Coffee",
                },
                new Product()
                {
                    Id = 10,
                    Name = "Charcuterie",
                    ShortDescription = "For indecisive food afficianados.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFileName = "charcuterie.png",
                    Price = 4,
                    Category = "Food",
                },
                new Product()
                {
                    Id = 12,
                    Name = "Waffles",
                    ShortDescription = "They need no introduction.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFileName = "waffles.png",
                    Price = 4,
                    Category = "Food",
                }
                );
        }
    }

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
            var deleteItem = wiredContext.Products.FirstOrDefault(x => x.Id == id);
            wiredContext.Products.Remove(deleteItem);
            wiredContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return wiredContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return wiredContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Product product)
        {
            wiredContext.Entry(product).State = EntityState.Modified;
            wiredContext.SaveChanges();
        }
    }
}

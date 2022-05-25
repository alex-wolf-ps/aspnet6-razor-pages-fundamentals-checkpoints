using Microsoft.EntityFrameworkCore;

namespace WiredBrainCoffeeAdmin.Data
{
    public class WiredBrainContext : DbContext
    {
        public WiredBrainContext(DbContextOptions options) : base(options) { }
    }
}

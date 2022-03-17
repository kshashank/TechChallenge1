using Microsoft.EntityFrameworkCore;

namespace TechChallenge1
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options): base(options)
        {
        }

        public DbSet<Server> Servers { get; set; }

    }
}

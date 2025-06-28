using Microsoft.EntityFrameworkCore;
using URLshortener.Models;

namespace URLshortener.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Urllist> Urls { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
        :base(options)
        {
        
        }
    }
}

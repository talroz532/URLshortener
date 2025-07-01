using Microsoft.EntityFrameworkCore;
using URLshortener.Models;

namespace URLshortener.Data
{
    // Database context for the application
    public class ApiContext : DbContext
    {
        // Table for storing URL records
        public DbSet<Urllist> Urls { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
    }
}

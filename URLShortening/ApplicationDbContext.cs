using Microsoft.EntityFrameworkCore;

namespace URLShortening;

public class ApplicationDbContext : DbContext
{
    public DbSet<ShortenedUrlItem> ShortenedUrls { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.Migrate();
    } 
}
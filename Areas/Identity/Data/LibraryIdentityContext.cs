using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zaha_Maria_Lab2.Models;

namespace Zaha_Maria_Lab2.Data;

public class LibraryIdentityContext : IdentityDbContext<IdentityUser>
{
    public LibraryIdentityContext(DbContextOptions<LibraryIdentityContext> options)
        : base(options)
    {
    }
    public DbSet<Member> Member { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

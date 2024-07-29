using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Library_MVC.Models;

namespace Library_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Library_MVC.Models.Book> Book { get; set; } = default!;
        public DbSet<Library_MVC.Models.Member> Member { get; set; } = default!;
        public DbSet<Library_MVC.Models.BorrowRecord> BorrowRecord { get; set; } = default!;
    }
}

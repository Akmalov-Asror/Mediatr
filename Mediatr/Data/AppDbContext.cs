using Mediatr3.Domains;
using Microsoft.EntityFrameworkCore;

namespace Mediatr3.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    public DbSet<StudentDetails> Students { get; set; }
}
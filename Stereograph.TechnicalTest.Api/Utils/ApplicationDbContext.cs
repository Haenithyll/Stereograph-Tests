using Microsoft.EntityFrameworkCore;
using Stereograph.TechnicalTest.Api.Entities;

namespace Stereograph.TechnicalTest.Api.Utils;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<EPerson> People { get; set; }
}

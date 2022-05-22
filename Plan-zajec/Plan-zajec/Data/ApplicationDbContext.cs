using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Plan_zajec.Models;

namespace Plan_zajec.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Plan_zajec.Models.Lesson>? Lesson { get; set; }
    public DbSet<Plan_zajec.Models.Group>? Group { get; set; }
    public DbSet<Plan_zajec.Models.Lecturer>? Lecturer { get; set; }
}
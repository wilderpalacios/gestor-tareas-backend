using Microsoft.EntityFrameworkCore;
using APIGestorTareas.Models;

namespace APIGestorTareas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}

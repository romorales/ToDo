namespace backend_todo.Context
{
    using backend_todo.Models;
    using Microsoft.EntityFrameworkCore;

    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }

        public DbSet<Tarea> Tareas { get; set; }
    }
}

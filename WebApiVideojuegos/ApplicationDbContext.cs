using WebApiVideojuegos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace WebApiVideojuegos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Compania> Companias { get; set; }
        public DbSet<Videojuego> Videojuegos { get; set; }
    }
}

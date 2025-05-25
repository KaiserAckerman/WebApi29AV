using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebAPI29AV.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Insertar en tabla Roles
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PKRol = 1,
                    Name = "Alumno"
                },
                new Rol
                {
                    PKRol = 2,
                    Name = "Maestro"
                });

            // Insertar en tabla Usuario
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    PKUser = 1,
                    Name = "Josafat",
                    Username = "Joss",
                    Password = "1910",
                    FKRol = 2 // Asegúrate de que esta clave foránea corresponde a un Rol existente
                },
                new User
                {
                    PKUser = 2,
                    Name = "Roberto",
                    Username = "Kaiser",
                    Password = "1910",
                    FKRol = 1
                },
                new User
                {
                    PKUser = 3,
                    Name = "Kaiser",
                    Username = "Ackerman",
                    Password = "1910",
                    FKRol = 1
                });
        }
    }
}

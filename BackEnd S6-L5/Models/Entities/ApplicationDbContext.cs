
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_S6_L5.Models.Entities
{
    public class ApplicationDbContext :
        IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }



        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Camera> Camere { get; set; }
        public DbSet<Prenotazione> Prenotazioni { get; set; }


        public DbSet<ApplicationUser> AspNetUser { get; set; }

    }
}


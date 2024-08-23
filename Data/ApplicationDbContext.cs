using ETickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ETickets.Models.ViewModel;

namespace ETickets.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base (options) 
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<ActorMovies> ActorMovies { get; set; }


        //public DbSet<ApplicationUserVM> ApplicationUserVM { get; set; } = default!;
        //public DbSet<ETickets.Models.ViewModel.LoginVM> LoginVM { get; set; } = default!;
        //public DbSet<ETickets.Models.ViewModel.RoleVM> RoleVM { get; set; } = default!;
    }
}

using Microsoft.EntityFrameworkCore;
using MyBlazorHybridApp.Shared;
using MyBlazorHybridApp.Shared.Models;

namespace MyBlazorHybridApp.Web.Data
{
    public class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options)
            : base(options)
        {
        }

        public DbSet<PizzaSpecial> Specials { get; set; } = default!;
        public DbSet<Topping> Toppings { get; set; } = default!;
        public DbSet<Pizza> Pizzas { get; set; } = default!;
    }
}

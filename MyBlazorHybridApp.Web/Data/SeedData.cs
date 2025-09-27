using MyBlazorHybridApp.Shared;
using MyBlazorHybridApp.Shared.Models;

namespace MyBlazorHybridApp.Web.Data
{
    public static class SeedData
    {
        public static void Initialize(PizzaStoreContext db)
        {
            // Kalau sudah ada data, jangan seed lagi
            if (db.Specials.Any())
                return;

            db.Specials.AddRange(
                new PizzaSpecial
                {
                    Name = "Basic Cheese Pizza",
                    Description = "It's cheesy and delicious. Why wouldn't you want one?",
                    BasePrice = 9.99m,
                    ImageUrl = "img/pizzas/cheese.jpg"
                },
                new PizzaSpecial
                {
                    Name = "The Baconatorizor",
                    Description = "It has EVERY kind of bacon.",
                    BasePrice = 11.99m,
                    ImageUrl = "img/pizzas/bacon.jpg"
                },
                new PizzaSpecial
                {
                    Name = "Classic pepperoni",
                    Description = "It's the pizza you grew up with, but Blazor-ized.",
                    BasePrice = 10.50m,
                    ImageUrl = "img/pizzas/pepperoni.jpg"
                }
            );

            db.Toppings.AddRange(
                new Topping { Name = "Extra cheese", Price = 1.25m },
                new Topping { Name = "Mushrooms", Price = 1.00m },
                new Topping { Name = "Onions", Price = 0.75m },
                new Topping { Name = "Green peppers", Price = 0.75m },
                new Topping { Name = "Pepperoni", Price = 1.50m },
                new Topping { Name = "Sausage", Price = 1.75m }
            );

            db.SaveChanges();
        }
    }
}

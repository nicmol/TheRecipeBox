using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRecipeBox.Models
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {

            if (!context.Recipes.Any())
            {
                Recipe salad = new Recipe
                {
                    Name = "salad",
                    Servings = 2,
                    Instructions = "Toss ingredients.",
                    Date = DateTime.Now,
                    Rating = 5,
                    ImgUrl = "/images/lettuce-tomato-salad.jpg"
                };

                salad.AddIngredient("lettuce", 1, "head");
                salad.AddIngredient("tomatoes", .5, "cups");

                Recipe pizza = new Recipe
                {
                    Name = "pizza",
                    Servings = 4,
                    Instructions = "1.Put crust on pan 2.spread out sauce on crust 3.cover with mozzarella 4.spread out pepperoni on top",
                    Date = DateTime.Now,
                    Rating = 5,
                    ImgUrl = "/images/pepperoni-pizza-ck-x.jpg"
                };

                pizza.AddIngredient("premade pizza crust", 1, "each");
                pizza.AddIngredient("red sauce", 1, "cup");
                pizza.AddIngredient("mozzarella", 2, "cups");
                pizza.AddIngredient("pepperoni", .25, "lb.");

                context.AddRange
                (
                    salad, pizza
                );
                context.SaveChanges();
            }
        }
        
    }
}

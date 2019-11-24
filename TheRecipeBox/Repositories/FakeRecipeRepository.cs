using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRecipeBox.Models;

namespace TheRecipeBox.Repositories
{
    public class FakeRecipeRepository : IRecipeRepository
    {
        public FakeRecipeRepository()
        {
            Unit cup = new Unit
            {
                Name = "cup"
            };

            Ingredient lettuce = new Ingredient
            {
                IngredientName = "lettuce",
                Quantity = 1,
                Measure = cup
            };
            Ingredient tomatoes = new Ingredient
            {
                IngredientName = "tomatoes",
                Quantity = .5,
                Measure = cup
            };

            Recipe salad = new Recipe
            {
                RecipeID = 1,
                Name = "salad",
                Servings = 2,
                Instructions = "Toss ingredients.",
                Date = DateTime.Now,
                Rating = 5
               
            };

            salad.AddIngredient(lettuce);
            salad.AddIngredient(tomatoes);
            AddRecipe(salad);
        }

        private static List<Recipe> recipes = new List<Recipe>();
        public List<Recipe> Recipes { get { return recipes; } }
        public void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
        }

        public Recipe GetRecipeById(int recipeId)
        {
            return recipes.FirstOrDefault(r => r.RecipeID == recipeId);
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return recipes;
        }
    }
}

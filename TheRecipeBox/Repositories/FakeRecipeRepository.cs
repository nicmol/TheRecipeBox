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
            if (recipes == null)
            {
                recipes = new List<Recipe>();
          
                Ingredient lettuce = new Ingredient
                {
                    IngredientName = "lettuce",
                    Quantity = 1,
                    Measure = "cup"
                };
                Ingredient tomatoes = new Ingredient
                {
                    IngredientName = "tomatoes",
                    Quantity = .5,
                    Measure = "cup"
                };

                Recipe salad = new Recipe
                {
                    Name = "salad",
                    Servings = 2,
                    Instructions = "Toss ingredients.",
                    Date = DateTime.Now,
                    Rating = 5,
                    ImgUrl = "/images/lettuce-tomato-salad.jpg"
                };

                salad.AddIngredient(lettuce);
                salad.AddIngredient(tomatoes);
                AddRecipe(salad);
            }
    
        }

        private static List<Recipe> recipes;
        public List<Recipe> Recipes { get { return recipes; } }
        public void AddRecipe(Recipe recipe)
        {
            recipe.RecipeID = GetMaxId() + 1;
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

        public int GetMaxId()
        {
            if(recipes.Count == 0)
            {
                return 0;
            }
            int maxId = int.MinValue;
            foreach(Recipe r in recipes)
            {
                if(r.RecipeID > maxId)
                {
                    maxId = r.RecipeID;
                }
            }
            return maxId;
        }
    }
}

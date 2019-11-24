using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRecipeBox.Models;

namespace TheRecipeBox.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
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

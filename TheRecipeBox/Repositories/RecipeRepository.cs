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
            if (recipes.Count == 0)
            {
                throw new InvalidOperationException("Empty List");
            }
            int maxId = int.MinValue;
            foreach (Recipe r in recipes)
            {
                if (r.RecipeID > maxId)
                {
                    maxId = r.RecipeID;
                }
            }
            return maxId;
        }
    }

}

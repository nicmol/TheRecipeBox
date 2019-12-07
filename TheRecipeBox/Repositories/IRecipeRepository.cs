using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRecipeBox.Models;

namespace TheRecipeBox.Repositories
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetRecipes();
        void AddRecipe(Recipe recipe);
        Recipe GetRecipeById(int recipeId);
        int GetMaxId();
        IEnumerable<Recipe> GetRecipesSearch(string search);
    }
}
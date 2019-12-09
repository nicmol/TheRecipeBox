using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRecipeBox.Models;

namespace TheRecipeBox.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        public RecipeRepository(AppDbContext context)
        {
            _context = context;
        }
        private readonly AppDbContext _context;

        public List<Recipe> Recipes
        {
            get
            {
                return _context.Recipes.Include("Ingredients").ToList();
            }
        }

        
        public void AddRecipe(Recipe recipe)
        {
           
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

      
        public Recipe GetRecipeById(int recipeId)
        {
            Recipe recipe = Recipes.Find(r => r.RecipeID == recipeId);
            return recipe;
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return Recipes;
        }

        public int GetMaxId()
        {
            if (Recipes.Count == 0)
            {
                throw new InvalidOperationException("Empty List");
            }
            int maxId = int.MinValue;
            foreach (Recipe r in Recipes)
            {
                if (r.RecipeID > maxId)
                {
                    maxId = r.RecipeID;
                }
            }
            return maxId;
        }
        //Searches for recipe
        public IEnumerable<Recipe> GetRecipesSearch(string search)
        {
            if(search == null)
            {
                return Recipes;
            }
            return _context.Recipes.Where(r => EF.Functions.Like(r.Name, "%" + search + "%")).Include("Ingredients");
        }
    }

}

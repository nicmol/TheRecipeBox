using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRecipeBox.Models;
using TheRecipeBox.Repositories;

namespace TheRecipeBox.Controllers
{
    public class RecipeController : Controller
    {
        IRecipeRepository repo; //= new FakeRecipeRepository();
        public RecipeController(IRecipeRepository r)
        {
            repo = r;
        }

        public IActionResult Index(string search)
        {
            return View(repo.GetRecipesSearch(search));
        }

        public IActionResult RecipeDetail(int id, int servings)
        {
            var recipe = repo.GetRecipeById(id);
            if (recipe == null)
            {
                return NotFound();
            }
                
            if(servings == 0)
            {
                return View(recipe);
            }

            
            double multiplier = (double)servings / recipe.Servings;
            foreach (Ingredient i in recipe.Ingredients)
            {

                i.Quantity = i.Quantity * multiplier;
            }
            recipe.Servings = servings;
            return View(recipe);
        }

        public IActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult AddRecipe(string name, string servings, string instructions, List<Ingredient> ingredients)
        {
            Recipe recipe = new Recipe();
            recipe.Name = name;
            recipe.Servings = Convert.ToInt32(servings);
            recipe.Instructions = instructions;
            recipe.Date = DateTime.Now;
            foreach(Ingredient i in ingredients)
            {
                recipe.AddIngredient(i);
            }
            repo.AddRecipe(recipe);


            return RedirectToAction("RecipeDetail", new { id = recipe.RecipeID});

        }
    }
}
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

        public IActionResult Index()
        {
            return View(repo);
        }

        public IActionResult RecipeDetail(int id)
        {
            var recipe = repo.GetRecipeById(id);
            if (recipe == null)
                return NotFound();
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
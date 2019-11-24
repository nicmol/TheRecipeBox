﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRecipeBox.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public int Servings { get; set; }
        public string Instructions { get; set; }
        public DateTime Date { get; set; }
        public double Rating { get; set; }

        private List<Ingredient> ingredients = new List<Ingredient>();
        public List<Ingredient> Ingredients { get { return ingredients; } }

        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

        public string ImgUrl { get; set; }


    }
}

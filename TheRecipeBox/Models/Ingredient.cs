using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRecipeBox.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public double Quantity { get; set; }
        public string Measure { get; set; }
        public int RecipeID { get; set; }
    }
}

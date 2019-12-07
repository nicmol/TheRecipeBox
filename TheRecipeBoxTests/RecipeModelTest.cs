using System;
using System.Collections.Generic;
using TheRecipeBox.Controllers;
using TheRecipeBox.Models;
using TheRecipeBox.Repositories;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace TheRecipeBoxTests
{
    public class RecipeModelTest
    {
        [Fact]

        public void AddIngredientTest()
        {
            //Arrange
            var repo = new FakeRecipeRepository();
            var recipe = repo.Recipes[0];
            var beforeCount = recipe.Ingredients.Count;

            //Act
            recipe.AddIngredient("Salt", 2, "teaspoons");

            //Assert
            Assert.Equal(beforeCount + 1, recipe.Ingredients.Count);

        }

    }
}

          
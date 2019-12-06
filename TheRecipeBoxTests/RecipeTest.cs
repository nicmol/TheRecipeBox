using System;
using System.Collections.Generic;
using TheRecipeBox.Controllers;
using TheRecipeBox.Models;
using TheRecipeBox.Repositories;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace TheRecipeBox.Tests
{
    public class RecipeTest

    {
        [Fact]

        public void AddRecipeTest()
        {
            // Arrange
            var repo = new FakeRecipeRepository();
            var recipeController = new RecipeController(repo);
            var ingredients = new List<Ingredient>();

            // Act
            recipeController.AddRecipe("Smoothie",

              "2", "Put all ingredients in blender then blend on high", ingredients);

            // Assert
            Assert.Equal("Smoothie",

                repo.Recipes[repo.Recipes.Count - 1].Name);
        }

        [Fact]
        public void RecipeDetailTest()
        {
            //Arrange
            var repo = new FakeRecipeRepository();
            var recipeController = new RecipeController(repo);


            //Act
            //RecipeController.RecipeDetail

            //Assert
        }

    }
}
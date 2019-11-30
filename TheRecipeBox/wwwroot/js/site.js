function addFields() {
    var container = document.getElementById("ingredientInputList");
    var countOfChildren = container.childElementCount;
    var html = `<div class="form-group">
                <input class="form-control col-2" name="ingredients[${countOfChildren}].Quantity" asp-for="Ingredients[${countOfChildren}].Quantity" placeholder="Quantity" />
                <input class="form-control col-2" name="ingredients[${countOfChildren}].Measure" asp-for="Ingredients[${countOfChildren}].Measure" placeholder="Measure" />
                <input class="form-control col-2" name="ingredients[${countOfChildren}].IngredientName" asp-for="Ingredients[${countOfChildren}].IngredientName" placeholder="IngredientName" /><br />
                </div>
`;
    container.insertAdjacentHTML("beforeend", html);
}

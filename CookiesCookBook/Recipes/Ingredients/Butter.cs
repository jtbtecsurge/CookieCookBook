﻿namespace CookiesCookBook.Recipes.Ingredients;

public class Butter : Ingredient
{
    public override int Id => 3;
    public override string Name => "Butter";
    public override string PreaparationInstructions =>
        $"Melt on Low Heat.{base.PreaparationInstructions}";
}

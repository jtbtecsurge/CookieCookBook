﻿namespace CookiesCookBook.Recipes.Ingredients
{
    public class Chocolate : Ingredient
    {
        public override int Id => 4;
        public override string Name => "Chocolate";
        public override string PreaparationInstructions =>
            $"Melt in a warm water bath. {base.PreaparationInstructions}";
    }
}

namespace CookiesCookBook.Recipes.Ingredients;

public abstract class Spices : Ingredient
{
    public override string PreaparationInstructions =>
        $"Take half a teaspon. {base.PreaparationInstructions}";
}

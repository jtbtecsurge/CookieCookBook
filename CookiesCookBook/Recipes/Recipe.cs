using CookiesCookBook.Recipes.Ingredients;

namespace CookiesCookBook.Recipes
{
    public class Recipe
    {
        public IEnumerable<Ingredient> Ingredients { get; }

        public Recipe(List<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }

        public override string ToString()
        {
            var steps = new List<string>();
            foreach(var ingredient in Ingredients)
            {
                steps.Add($"{ingredient.Name}. {ingredient.PreaparationInstructions}");
            }

            return string.Join(Environment.NewLine, steps);
        }
    }
}

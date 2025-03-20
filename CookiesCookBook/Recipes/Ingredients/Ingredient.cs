namespace CookiesCookBook.Recipes.Ingredients
{
    public abstract class Ingredient
    {
        public abstract int Id { get; }
        public abstract string Name { get; }
        public virtual string PreaparationInstructions =>
            "Add to other Ingredients.";

        public override string ToString() =>
            $"{Id}. {Name}";
        
    }
}

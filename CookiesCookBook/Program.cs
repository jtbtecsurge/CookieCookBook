
using System.Diagnostics.Metrics;
using CookiesCookBook.Recipes;
using CookiesCookBook.Recipes.Ingredients;

var cookiesRecipeApp = new CookiesRecipeApp(
    new RecipesRepository(),
    new RecipesConsoleUserInteraction(
        new IngredientsRegister()));

cookiesRecipeApp.Run("recipe.txt");


Console.ReadKey();
public class CookiesRecipeApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesConsoleUserInteraction;

    public CookiesRecipeApp(
        IRecipesRepository recipesRepository, 
        IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesConsoleUserInteraction = recipesUserInteraction;
    }

    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesConsoleUserInteraction.PrintExistingRecipes(allRecipes);

        _recipesConsoleUserInteraction.PromptToCreateRecipe();

        var ingredients = _recipesConsoleUserInteraction.ReadIngredientsFromUser();

        //if (ingredients.Count > 0)
        //{
        //    var recipes = new Recipe(ingredients);
        //    allRecipes.Add(recipes);
        //    _recipesConsoleUserInteraction.Write(filePath, allRecipes);

        //    _recipesConsoleUserInteraction.ShowMessage("Recipe added: ");
        //    _recipesConsoleUserInteraction.ShowMessage(recipes.ToString());    
        //}
        //else
        //{
        //    _recipesConsoleUserInteraction.ShowMessage(
        //        "No ingredients have been selected." +
        //        "Recipes will not be saved.");
        //}

        _recipesConsoleUserInteraction.Exit();
    }
}

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
}

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
    
}

public class IngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheathFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetById(int id)
    {
        foreach(var ingredient in All)
        {
            if (ingredient.Id == id)
            {
                return ingredient;  
            }
        }
        return null;
    }
}

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(IngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
  
    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if(allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are: " + Environment.NewLine);
            var counter = 1;
            foreach( var recipe in allRecipes)
            {
                Console.WriteLine($"*****{counter}*****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                ++counter;
            }
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe!" +
            "Available ingredients are:");

        foreach(var ingredient in _ingredientsRegister.All)
        {
            Console.WriteLine(ingredient);
        }
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool shallStop = false;
        var ingredients = new List<Ingredient>();

        while (!shallStop)
        {
            Console.WriteLine("Add an ingredient by its ID, " +
                "or type anything else if finished.");

            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
            {
                var selectedingredient = _ingredientsRegister.GetById(id);
                if (selectedingredient is not null)
                {
                    ingredients.Add(selectedingredient);
                }  
            }
            else
            {
                shallStop = true;
            }
        }
        return ingredients;
    }
}

public class RecipesRepository : IRecipesRepository
{
    public List<Recipe> Read(string filePath)
    {
        return new List<Recipe>
        {
            new Recipe(new List<Ingredient>
            {
                new WheathFlour(),
                new Butter(),
                new Sugar()
            }),
            new Recipe(new List<Ingredient>()
            {
                new CocoaPowder(),
                new SpeltFlour(),
                new Cinnamon()
            })
        };
    }
}
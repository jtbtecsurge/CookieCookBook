
using System.Diagnostics.Metrics;
using System.Text.Json;
using CookiesCookBook.App;
using CookiesCookBook.DataAccess;
using CookiesCookBook.FileAccess;
using CookiesCookBook.Recipes;
using CookiesCookBook.Recipes.Ingredients;

const FileFormat Format = FileFormat.Json;

IStringsRepository stringsRepository = Format == FileFormat.Json ?
    new StringsJsonRepository() :
    new StringsTextualRepository();

const string FileName = "recipes";
var fileMetaData = new FileMetaData(FileName, Format);                                                                                                      

var ingredientsRegister =new IngredientsRegister(); 

var cookiesRecipeApp = new CookiesRecipeApp(
    new RecipesRepository(
        new StringsJsonRepository(),
        ingredientsRegister),
    new RecipesConsoleUserInteraction(
        ingredientsRegister));

cookiesRecipeApp.Run("recipes.json");











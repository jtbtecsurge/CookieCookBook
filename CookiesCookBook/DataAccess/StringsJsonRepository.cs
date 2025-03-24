
using System.Text.Json;

namespace CookiesCookBook.DataAccess;

public class StringsJsonRepository : StringsRepository
{
    private static readonly string Separator = Environment.NewLine;

    protected override string StringsToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }

    protected override List<string> TextToString(string fileContents)
    {
        return JsonSerializer.Deserialize<List<string>>(fileContents);
    }
}

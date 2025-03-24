namespace CookiesCookBook.DataAccess;

public abstract class StringsRepository : IStringsRepository
{
    public List<string> Read(string filePath)
    {


        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            return TextToString(fileContents);
        }
        return new List<string>();

    }
    protected abstract List<string> TextToString(string fileContents);

    public void Write(string filepath, List<string> strings)
    {
        File.WriteAllText(filepath, StringsToText(strings));
    }

    protected abstract string StringsToText(List<string> strings);
}

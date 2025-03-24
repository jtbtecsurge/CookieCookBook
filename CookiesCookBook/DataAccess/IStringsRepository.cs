namespace CookiesCookBook.DataAccess;

public interface IStringsRepository
{
    List<string> Read(string filePath);
    void Write(string filepath, List<string> strings);
}

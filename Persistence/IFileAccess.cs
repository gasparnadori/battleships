namespace battleships.Persistence;

public interface IFileAccess
{
    string Load(string path);
    void Save(string path, string content);
}
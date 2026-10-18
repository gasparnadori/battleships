namespace battleships.Persistence;

public class FileAccess:IFileAccess
{
    public string Load(string path)
    {
        return File.ReadAllText(path);
    }
    
    public void Save(string path, string content)
    {
        File.WriteAllText(path, content);
    }
}
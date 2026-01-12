namespace Audit;

public class WinFileSystem : IFileSystem
{
    private readonly string _basePath;

    public WinFileSystem(string basePath)
    {
        _basePath = basePath;
    }

    public string[] GetFiles(string directoryName)
    {
        var fullPath = Path.Combine(_basePath, directoryName);
        EnsureExistence(fullPath);
        return Directory.EnumerateFiles(fullPath, "*.*").ToArray();
    }

    public void WriteAllText(string filePath, string content)
    {
        var fullPath = Path.Combine(_basePath, filePath);
        EnsureExistence(Path.GetDirectoryName(fullPath)!);
        File.WriteAllText(fullPath, content);
    }

    public IEnumerable<string> ReadAllLines(string filePath)
    {
        throw new NotImplementedException();
    }

    private static DirectoryInfo EnsureExistence(string fullPath)
    {
        return Directory.CreateDirectory(fullPath);
    }
}
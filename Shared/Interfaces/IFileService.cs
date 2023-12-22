namespace GetAndRead.Shared.Interfaces;

public interface IFileService
{
    bool SaveContentToFile(string content);

    string GetContentFromFile();
}


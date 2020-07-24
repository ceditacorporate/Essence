namespace Cedita.Essense.Mobile.Interfaces
{
    public interface IFileservice
    {
        string GetStorageFolderPath();

        bool SaveFile<T>(string filename, T file, bool isTextFile = true);

        T LoadFile<T>(string filename, bool isTextFile = true);

    }
}

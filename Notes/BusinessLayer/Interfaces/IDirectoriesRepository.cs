using Directory = DataLayer.Entities.Directory;

namespace BusinessLayer.Interfaces
{
    public interface IDirectoriesRepository
    {
        IEnumerable<Directory> GetAllDirectories(bool includeMaterials = false);
        Directory GetDirectoryById(int directoryId, bool includeMaterials = false);
        void SaveDirectory(Directory directory);
        void DeleteDirectory(Directory directory);
    }
}
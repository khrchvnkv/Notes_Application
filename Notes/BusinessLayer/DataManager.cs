using BusinessLayer.Interfaces;

namespace BusinessLayer
{
    public class DataManager
    {
        public readonly IDirectoriesRepository DirectoriesRepository;
        public readonly IMaterialsRepository MaterialsRepository;

        public DataManager(IDirectoriesRepository directoriesRepository,
            IMaterialsRepository materialsRepository)
        {
            DirectoriesRepository = directoriesRepository;
            MaterialsRepository = materialsRepository;
        }
    }
}
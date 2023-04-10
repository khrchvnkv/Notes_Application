using BusinessLayer.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Directory = DataLayer.Entities.Directory;

namespace BusinessLayer.Implementation
{
    public class EFDirectoryRepository : IDirectoriesRepository
    {
        private readonly EFDBContext _context;

        public EFDirectoryRepository(EFDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Directory> GetAllDirectories(bool includeMaterials = false)
        {
            return includeMaterials ? 
                _context.Set<Directory>().Include(x => x.Materials).AsNoTracking() : 
                _context.Directory;
        }
        public Directory GetDirectoryById(int directoryId, bool includeMaterials = false) => 
            GetAllDirectories(includeMaterials).FirstOrDefault(d => d.Id == directoryId);
        public void SaveDirectory(Directory directory)
        {
            if (directory.Id == 0)
            {
                _context.Directory.Add(directory);
            }
            else
            {
                _context.Entry(directory).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
        public void DeleteDirectory(Directory directory)
        {
            _context.Directory.Remove(directory);
            _context.SaveChanges();
        }
    }
}
using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementation
{
    public class EFMaterialsRepository : IMaterialsRepository
    {
        private readonly EFDBContext _context;

        public EFMaterialsRepository(EFDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Material> GetAllMaterials(bool includeMaterials = false)
        {
            return includeMaterials ? 
                _context.Material.Include(x => x.Directory).AsNoTracking() : 
                _context.Material;
        }
        public Material GetMaterialById(int materialId, bool includeMaterials = false) => 
            GetAllMaterials(includeMaterials).FirstOrDefault(m => m.Id == materialId);
        public void SaveMaterial(Material material)
        {
            if (material.Id == 0)
            {
                _context.Material.Add(material);
            }
            else
            {
                _context.Entry(material).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
        public void DeleteMaterial(Material material)
        {
            _context.Material.Remove(material);
            _context.SaveChanges();
        }
    }
}
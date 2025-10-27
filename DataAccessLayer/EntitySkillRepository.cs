using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class EntitySkillRepository : IRepository<SkillRepo>, ISkillRepository
    {

        private readonly DataContext _context;


        public EntitySkillRepository(DataContext context)
        {
            _context = context;
        }


        public void Create(SkillRepo obj)
        {
            _context.Set<SkillRepo>().Add(obj);
            _context.SaveChanges();
        }


        public IEnumerable<SkillRepo> ReadAll()
        {

            return _context.Set<SkillRepo>()
                .Cast<SkillRepo>()
                .ToList();

        }


        public SkillRepo ReadById(int id)
        {

            var repo = _context.Skills
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == id);

            return repo;

        }


        public void Update(SkillRepo obj)
        {
            _context.SaveChanges();
        }


        public void Delete(SkillRepo obj)
        {
            _context.Set<SkillRepo>().Remove(obj);
            _context.SaveChanges();
        }

        public void DeleteAll()
        {    // Сначала удаляем все Skills
            var allSkills = _context.Skills.ToList();
            _context.Skills.RemoveRange(allSkills);
            _context.SaveChanges(); // Сохраняем изменения
        }

        public IEnumerable<SkillRepo> GetByNames(IEnumerable<string> names)
        {
            return _context.Skills.Where(s => names.Contains(s.Name)).ToList();
        }
    }
}

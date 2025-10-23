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

        ///<summary>Добавляет запись в БД </summary>
        /// <param name="obj">объект, который добавится в БД</param>
        public void Create(SkillRepo obj)
        {
            _context.Set<SkillRepo>().Add(obj);
            _context.SaveChanges();
        }

        ///<summary>Читает все записи в БД</summary>
        /// <returns>Возвращает все записи из БД</returns>
        public IEnumerable<SkillRepo> ReadAll()
        {

            return _context.Set<SkillRepo>()
                .Cast<SkillRepo>()
                .ToList();

        }

        ///<summary>Читает запись по id</summary>
        /// <param name="id">id, по которому ищут нужный объект</param>
        /// /// <returns>Возвращает нужную запись из БД</returns>
        public SkillRepo ReadById(int id)
        {

            var repo = _context.Skills
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == id);

            return repo;

        }

        ///<summary>Изменяет данные у записи </summary>
        /// <param name="obj">объект с измененными свойствами</param>
        public void Update(SkillRepo obj)
        {
            _context.SaveChanges();
        }

        ///<summary>Удаляет запись в БД </summary>
        /// <param name="obj">объект, который нужно удалить из БД</param>
        public void Delete(SkillRepo obj)
        {
            _context.Set<SkillRepo>().Remove(obj);
            _context.SaveChanges();
        }

        ///<summary>Удаляет ВСЕ записи в БД </summary>
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

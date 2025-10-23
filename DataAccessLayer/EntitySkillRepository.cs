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
            using (var context = new DataContext())
            {
                var repo = context.Skills
                    .AsNoTracking()
                    .FirstOrDefault(a => a.Id == id);

                return repo;

            }
        }

        ///<summary>Изменяет данные у записи </summary>
        /// <param name="obj">объект с измененными свойствами</param>
        public void Update(SkillRepo obj)
        {

            //var existing = _context.AnimeChans
            //    .Include(a => a.Skills)
            //    .FirstOrDefault(a => a.Id == animeChanRepo.Id);

            //if (existing == null)
            //{
            //    return;
            //}

            //// Обновляем все поля (кроме скилов)
            //existing.FirstName = animeChanRepo.FirstName;
            //existing.LastName = animeChanRepo.LastName;
            //existing.Age = animeChanRepo.Age;
            //existing.Height = animeChanRepo.Height;
            //existing.Weight = animeChanRepo.Weight;
            //existing.Size = animeChanRepo.Size;

            //// Обновляем скилы
            //foreach (var skill in animeChanRepo.Skills)
            //{
            //    var existingSkill = existing.Skills.FirstOrDefault(s => s.Id == skill.Id);
            //    if (existingSkill != null)
            //    {
            //        // изменяем существующие
            //        existingSkill.Name = skill.Name;
            //    }
            //    else
            //    {
            //        // добавляем новый, прикреплённый к контексту
            //        var newSkill = new SkillRepo
            //        {
            //            Name = skill.Name,
            //        };
            //        _context.Skills.Add(newSkill);
            //        existing.Skills.Add(newSkill);
            //    }
            //}

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
            _context.SaveChanges(); // Сохраняем удаление Skills
        }

        public IEnumerable<SkillRepo> GetByNames(IEnumerable<string> names)
        {
            return _context.Skills.Where(s => names.Contains(s.Name)).ToList();
        }
    }
}

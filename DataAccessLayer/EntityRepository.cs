using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataAccessLayer
{
    public class EntityRepository<T>: IRepository<T> where T: class, IDomainObject, new()
    {

        private readonly DataContext _context;


        public EntityRepository(DataContext context)
        {
            _context = context;
        }

        ///<summary>Добавляет запись в БД </summary>
        /// <param name="obj">объект, который добавится в БД</param>
        public void Create(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        ///<summary>Читает все записи в БД</summary>
        /// <returns>Возвращает все записи из БД</returns>
        public IEnumerable<T> ReadAll()
        {

            if (typeof(T) == typeof(AnimeChanRepo))
            {
                return _context.Set<AnimeChanRepo>()
                    .Include(a => a.Skills)
                    .Cast<T>()
                    .ToList();
            }
            return _context.Set<T>().ToList();
        }

        ///<summary>Читает запись по id</summary>
        /// <param name="id">id, по которому ищут нужный объект</param>
        /// /// <returns>Возвращает нужную запись из БД</returns>
        public T ReadById(int id)
        {
            using (var context = new DataContext())
            {
                // Если это AnimeChanRepo, то подгружаем связанные Skills
                if (typeof(T) == typeof(AnimeChanRepo))
                {
                    var repo = context.AnimeChans
                        .Include(a => a.Skills)
                        .AsNoTracking()
                        .FirstOrDefault(a => a.Id == id);

                    // Приводим тип, чтобы вернуть T
                    return repo as T;
                }

                // Для всех остальных типов — обычное поведение
                return context.Set<T>()
                    .AsNoTracking()
                    .FirstOrDefault(e => e.Id == id);
            }
        }

        ///<summary>Изменяет данные у записи </summary>
        /// <param name="obj">объект с измененными свойствами</param>
        public void Update(T obj)
        {
            if (obj is AnimeChanRepo animeChanRepo)
            {
                var existing = _context.AnimeChans
                    .Include(a => a.Skills)
                    .FirstOrDefault(a => a.Id == animeChanRepo.Id);

                if (existing == null)
                {
                    return; 
                }

                // Обновляем все поля (кроме скилов)
                existing.FirstName = animeChanRepo.FirstName;
                existing.LastName = animeChanRepo.LastName;
                existing.Age = animeChanRepo.Age;
                existing.Height = animeChanRepo.Height;
                existing.Weight = animeChanRepo.Weight;
                existing.Size = animeChanRepo.Size;

                // Обновляем скилы
                foreach (var skill in animeChanRepo.Skills)
                {
                    var existingSkill = existing.Skills.FirstOrDefault(s => s.Id == skill.Id);
                    if (existingSkill != null)
                    {
                        // изменяем существующие
                        existingSkill.Name = skill.Name;
                    }
                    else
                    {
                        // добавляем новый, прикреплённый к контексту
                        var newSkill = new SkillRepo
                        {
                            Name = skill.Name,
                            AnimeChanRepoId = existing.Id 
                        };
                        _context.Skills.Add(newSkill);
                        existing.Skills.Add(newSkill);
                    }
                }

                _context.SaveChanges();
            }
        }

        ///<summary>Удаляет запись в БД </summary>
        /// <param name="obj">объект, который нужно удалить из БД</param>
        public void Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        ///<summary>Удаляет ВСЕ записи в БД </summary>
        public void DeleteAll()
        {    // Сначала удаляем все Skills
            var allSkills = _context.Skills.ToList();
            _context.Skills.RemoveRange(allSkills);
            _context.SaveChanges(); // Сохраняем удаление Skills

            // Затем удаляем AnimeChans
            var allAnimeChans = _context.AnimeChans.ToList();
            _context.AnimeChans.RemoveRange(allAnimeChans);
            _context.SaveChanges(); // Сохраняем удаление AnimeChans
        }
    }
}

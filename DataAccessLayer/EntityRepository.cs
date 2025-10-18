using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataAccessLayer
{
    public class EntityRepository<T>: IRepository<T> where T: class, IDoMainObject, new()
    {

        private readonly DataContext _context;


        public EntityRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

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

            //return _context.Set<T>().ToList();
        }

        public T ReadById(int id)
        {
            using (var context = new DataContext())
            {
                // Если это AnimeChanRepo — подгружаем связанные Skills
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
            //return _context.Set<T>().Include("Skills").Where(o => o.Id == id).FirstOrDefault();
        }

        public void Update(T obj)
        {
            //T origin = _context.Set<T>().Where(o => o.Id == obj.Id).FirstOrDefault();

            //var properties = typeof(T).GetProperties();
            //foreach (var prop in properties)
            //{
            //    if (prop.CanWrite)
            //    {
            //        var newValue = prop.GetValue(obj);
            //        prop.SetValue(origin, newValue);
            //    }
            //}

            //_context.SaveChanges();
            if (obj is AnimeChanRepo animeChanRepo)
            {
                var existing = _context.AnimeChans
                    .Include(a => a.Skills)
                    .FirstOrDefault(a => a.Id == animeChanRepo.Id);

                if (existing == null) return;

                // Простые поля
                Debug.WriteLine("111");
                existing.FirstName = animeChanRepo.FirstName;
                existing.LastName = animeChanRepo.LastName;
                existing.Age = animeChanRepo.Age;
                existing.Height = animeChanRepo.Height;
                existing.Weight = animeChanRepo.Weight;
                existing.Size = animeChanRepo.Size;

                // Обновляем навыки
                foreach (var skill in animeChanRepo.Skills)
                {
                    var existingSkill = existing.Skills.FirstOrDefault(s => s.Id == skill.Id);
                    if (existingSkill != null)
                    {
                        // изменяем существующий
                        existingSkill.Name = skill.Name;
                    }
                    else
                    {
                        // добавляем новый, прикреплённый к контексту
                        var newSkill = new SkillRepo
                        {
                            Name = skill.Name,
                            AnimeChanRepoId = existing.Id // важно указать связь
                        };
                        _context.Skills.Add(newSkill);
                        existing.Skills.Add(newSkill);
                    }
                }

                _context.SaveChanges();
            }
        }

        public void Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

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

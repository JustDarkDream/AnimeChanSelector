using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class EntityAnimeChanRepository : IRepository<AnimeChanRepo>
    {

        private readonly DataContext _context;


        public EntityAnimeChanRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(AnimeChanRepo obj)
        {
            _context.Set<AnimeChanRepo>().Add(obj);
            _context.SaveChanges();
        }


        public IEnumerable<AnimeChanRepo> ReadAll()
        {
            return _context.Set<AnimeChanRepo>()
                .Include(a => a.Skills)
                .Cast<AnimeChanRepo>()
                .ToList();

        }


        public AnimeChanRepo ReadById(int id)
        {
            using (var context = new DataContext())
            {
                var repo = context.AnimeChans
                    .Include(a => a.Skills)
                    .AsNoTracking()
                    .FirstOrDefault(a => a.Id == id);

                return repo;

            }
        }

        public void Update(AnimeChanRepo obj)
        {

            var existing = _context.AnimeChans
                .Include(a => a.Skills)
                .FirstOrDefault(a => a.Id == obj.Id);

            if (existing == null)
            {
                return;
            }

            // Обновляем все поля (кроме скилов)
            existing.FirstName = obj.FirstName;
            existing.LastName = obj.LastName;
            existing.Age = obj.Age;
            existing.Height = obj.Height;
            existing.Weight = obj.Weight;
            existing.Size = obj.Size;

            // Обновляем скилы
            var newSkillIds = obj.Skills.Select(s => s.Id).ToList();

            var skillsToAdd = _context.Skills.Where(s => newSkillIds.Contains(s.Id))
                                             .ToList();

            existing.Skills = skillsToAdd;

            _context.SaveChanges();
        }

        public void Delete(AnimeChanRepo obj)
        {
            var existing = _context.Set<AnimeChanRepo>().Find(obj.Id);
            if (existing != null)
            {
                _context.Set<AnimeChanRepo>().Remove(existing);
                _context.SaveChanges();
            }
        }

        public void DeleteAll()
        {    
            var allAnimeChans = _context.AnimeChans.ToList();
            _context.AnimeChans.RemoveRange(allAnimeChans);
            _context.SaveChanges(); // Сохраняем удаление AnimeChans
        }
    }
}

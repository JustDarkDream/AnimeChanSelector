using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : IDomainObject, new()
    {
        void Create(T entity);
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        void Update(T entity);
        void Delete(T entity);
        void DeleteAll();
    }
}

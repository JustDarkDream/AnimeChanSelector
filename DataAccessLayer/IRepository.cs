namespace DataAccessLayer
{
    public interface IRepository<T> where T : IDomainObject, new()
    {
        ///<summary>Добавляет запись в БД </summary>
        /// <param name="entity">объект, который добавится в БД</param>
        void Create(T entity);

        ///<summary>Читает все записи в БД</summary>
        /// <returns>Возвращает все записи из БД</returns>
        IEnumerable<T> ReadAll();

        ///<summary>Читает запись по id</summary>
        /// <param name="id">id, по которому ищут нужный объект</param>
        /// <returns>Возвращает нужную запись из БД</returns>
        T ReadById(int id);

        ///<summary>Изменяет данные у записи </summary>
        /// <param name="obj">объект с измененными свойствами</param>
        void Update(T entity);

        ///<summary>Удаляет запись в БД </summary>
        /// <param name="obj">объект, который нужно удалить из БД</param>
        void Delete(T entity);

        ///<summary>Удаляет ВСЕ записи в БД </summary>
        void DeleteAll();
    }
}

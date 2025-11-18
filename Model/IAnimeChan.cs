using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IAnimeChan
    {
        ///<summary>Создает три НЕслучаных аниме-тянок</summary>
        public void CreateAnimeChans();

        ///<summary>Создаёт рандомную аниме тянку</summary>
        /// <returns>Возвращает новую сгенерированную аниме тянку</returns>
        public AnimeChan FindAnimeChan();

        ///<summary>Загружает сохраненный айди для танки</summary>
        /// <returns>Возвращает сохраненный айди ранее</returns>
        public int LoadId();

        ///<summary>Сохраняет айди тянки</summary>
        /// <param name="id">Айди, который сохранится в временный</param>
        public void SaveId(int id);

        ///<summary>Чистит ВСЕ данные в БД</summary>
        public void DeleteAnimeChans();

        ///<summary>Добавляет всех тянок со скиллами из статичного листа в БД</summary>
        public void CreateAnimeChansInDB();

        ///<summary>Ищет в общем списке нужную тянку по её id</summary>
        /// <param name="id">Айди, по которую ищется тянка</param>
        /// <returns>Возвращает найденную тянку (или же null, если ничего не нашел)</returns>
        public AnimeChan FindById(int id);

        ///<summary>Добавляет новую тянку в общий список</summary>
        /// <param name="firstName">Имя тянки</param>
        /// <param name="lastName">Фамилия тянки</param>
        /// <param name="age">Возраст тянки</param>
        /// <param name="height">Рост тянки</param>
        /// <param name="weight">Вес тянки</param>
        /// <param name="size">Размер у тянки</param>
        /// <param name="skills">Навыки тянки</param>
        public void AddAnimeChan(string firstName, string lastName, int age, int height, int weight, int size, List<Skill> skills);

        ///<summary>Удаляет аниме тянку</summary>
        /// <param name="id">Айди, по которому удаляется тянка</param>
        public void DeleteAnimeChan(int id);

        ///<summary>Сохраняет изменения характеристик тянки</summary>
        /// <param name="firstName">Имя тянки</param>
        /// <param name="lastName">Фамилия тянки</param>
        /// <param name="age">Возраст тянки</param>
        /// <param name="height">Рост тянки</param>
        /// <param name="weight">Вес тянки</param>
        /// <param name="size">Размер у тянки</param>
        /// <param name="skills">Навыки тянки</param>
        /// <param name="id">Айди тянки, у которой и сохранятся изменения</param>
        public void SaveChangeAnimeChan(string firstName, string lastName, int age, int height, int weight, int size, List<Skill> skills, int id);

        ///<summary>Загружает весь список аниме тянок со скиллами</summary>
        /// <returns>Возвращает сам список тянок</returns>
        public IEnumerable<AnimeChan> LoadAnimeChanList();
    }
}

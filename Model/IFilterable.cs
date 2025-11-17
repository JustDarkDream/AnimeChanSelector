using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IFilterable
    {
        ///<summary>Сбрасывает значения фильтра до первоначальных</summary>
        public void DestroyFilter();

        ///<summary>Загружает отфильтрованный список аниме тянок</summary>
        /// <returns>Возвращает отфильтрованный список аниме тянок</returns>
        public List<AnimeChan> LoadFilterAnimeChanList();

        ///<summary>Изменяет отфильтрованный список аниме тянок</summary>
        /// <param name="ageFrom">Возраст ОТ</param>
        /// <param name="ageTo">Возраст ДО</param>
        /// <param name="heightFrom">Рост ОТ</param>
        /// <param name="heightTo">Рост ДО</param>
        /// <param name="weightFrom">Вес ОТ</param>
        /// <param name="weightTo">Вес ДО</param>
        /// <param name="sizeFrom">Размер ОТ</param>
        /// <param name="sizeTo">Размер ДО</param>
        /// <param name="skills">Навыки тянки</param>
        /// <param name="isСonsiderAll">Учитывать ли все навыки или хотя бы один</param>
        public void FilterAnimeChanList(int ageFrom, int ageTo, int heightFrom, int heightTo, int weightFrom, int weightTo, int sizeFrom, int sizeTo, List<Skill> skills, bool isСonsiderAll);

        ///<summary>Загружает данные фильтрации</summary>
        /// <returns>Возвращает все данные фильтрации</returns>
        public FilterStats LoadFilterStats();
    }
}

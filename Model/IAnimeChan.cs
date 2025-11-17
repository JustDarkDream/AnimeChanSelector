using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal interface IAnimeChan
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
    }
}

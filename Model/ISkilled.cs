using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal interface ISkilled
    {
        ///<summary>Сохраняет навык в список навыков</summary>
        /// <param name="skill">Навык, который сохраняется</param>
        public void SaveSkill(Skill skill);

        ///<summary>Очищает список навыков</summary>
        public void ClearSkills();

        ///<summary>Загружает список навыков</summary>
        /// <returns>Возвращает список навыков, который был сохранен ранее</returns>
        public List<Skill> LoadSkills();

        ///<summary>Создает новый скилл</summary>
        /// <param name="name">Имя, которое будет присвоено новосозданному скилу</param>
        /// <returns>Возвращает сам скилл/returns>
        public Skill CreateSkill(string name);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IMainPerson
    {
        ///<summary>Сохраняет все веденные данные в регистрации</summary>
        /// <returns>Сохраняет все веденные данные в регистрации</returns>
        public MainPerson GetMainPerson();

        ///<summary>Сохраняет данные пользователя</summary>
        /// <param name="firstName">Имя пользователя</param>
        /// <param name="lastName">Фамилия пользователя</param>
        /// <param name="age">Возраст пользователя</param>
        /// <param name="height">Рост пользователя</param>
        /// <param name="weight">Вес пользователя</param>
        /// <param name="size">Размер у пользователя</param>
        public void SaveMainPerson(string firstName, string lastName, int age, int height, int weight, int size);
    }
}

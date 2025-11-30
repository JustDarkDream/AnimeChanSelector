using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Model
{
    public interface ILogic
    {
        event Action<List<SkillDTO>> LoadSkillsInViewEvent;
        event Action<string> WriteConclutionEvent;
        event Action<FilterStatsDTO> FilterStatsLoadedEvent;
        event Action<IEnumerable<AnimeChanDTO>> LoadAnimeChanListEvent;
        event Action<AnimeChanDTO> FindByIdEvent;
        event Action<int> LoadIdEvent;
        event Action<List<AnimeChanDTO>> LoadFilterAnimeChanListEvent;
        event Action<AnimeChanDTO> FindAnimeChanEvent;
        event Action<MainPersonDTO> GetMainPersonEvent;
        event Action<SkillDTO> CreateSkillEvent;

        ///<summary>вызывает метод CreateAnimeChans() у модуля, реализующий IAnimeChan</summary>
        public void CreateAnimeChans();

        ///<summary>вызывает метод FindAnimeChan() у модуля, реализующий IAnimeChan</summary>
        public void FindAnimeChan();

        ///<summary>вызывает метод LoadId() у модуля, реализующий IAnimeChan</summary>
        public void LoadId();

        ///<summary>вызывает метод SaveId(параметр) у модуля, реализующий IAnimeChan</summary>
        /// <param name="id">Айди, который сохранится в временный</param>
        public void SaveId(int id);

        ///<summary>вызывает метод CreateAnimeChansInDB() у модуля, реализующий IAnimeChan</summary>
        public void CreateAnimeChansInDB();

        ///<summary>вызывает метод CreateAnimeChansInDB(параметры) у модуля, реализующий IAnimeChan</summary>
        /// <param name="firstName">Имя тянки</param>
        /// <param name="lastName">Фамилия тянки</param>
        /// <param name="age">Возраст тянки</param>
        /// <param name="height">Рост тянки</param>
        /// <param name="weight">Вес тянки</param>
        /// <param name="size">Размер у тянки</param>
        /// <param name="skills">Навыки тянки</param>
        public void AddAnimeChan(string firstName, string lastName, int age, int height, int weight, int size, List<SkillDTO> skills);

        ///<summary>вызывает метод DeleteAnimeChan(параметр) у модуля, реализующий IAnimeChan</summary>
        ///<param name="id">Айди, по которому удаляется тянка</param>
        public void DeleteAnimeChan(int id);

        ///<summary>вызывает метод SaveChangeAnimeChan(параметры) у модуля, реализующий IAnimeChan</summary>
        ///<param name="firstName">Имя тянки</param>
        /// <param name="lastName">Фамилия тянки</param>
        /// <param name="age">Возраст тянки</param>
        /// <param name="height">Рост тянки</param>
        /// <param name="weight">Вес тянки</param>
        /// <param name="size">Размер у тянки</param>
        /// <param name="skills">Навыки тянки</param>
        /// <param name="id">Айди тянки, у которой и сохранятся изменения</param>
        public void SaveChangeAnimeChan(string firstName, string lastName, int age, int height, int weight, int size, List<SkillDTO> skills, int id);

        ///<summary>вызывает метод LoadAnimeChanList() у модуля, реализующий IAnimeChan</summary>
        public void LoadAnimeChanList();

        ///<summary>вызывает метод DeleteAnimeChans() у модуля, реализующий IAnimeChan</summary>
        public void DeleteAnimeChans();

        ///<summary>вызывает метод FindById(параметр) у модуля, реализующий IAnimeChan</summary>
        ///<param name="id">Айди, по которую ищется тянка</param>
        public void FindById(int id);

        ///<summary>вызывает метод SaveSkill(параметр) у модуля, реализующий ISkilled</summary>
        /// <param name="skill">Навык, который сохраняется</param>
        public void SaveSkill(SkillDTO skill);

        ///<summary>вызывает метод ClearSkills() у модуля, реализующий ISkilled</summary>
        public void ClearSkills();

        ///<summary>вызывает метод LoadSkills() у модуля, реализующий ISkilled</summary>
        public void LoadSkills();

        ///<summary>вызывает метод CreateSkill(параметр) у модуля, реализующий ISkilled</summary>
        /// <param name="name">Имя, которое будет присвоено новосозданному скилу</param>
        public void CreateSkill(string name);

        ///<summary>вызывает метод DeleteSkills() у модуля, реализующий ISkilled</summary>
        public void DeleteSkills();

        ///<summary>вызывает метод LoadAllSkillsInDB() у модуля, реализующий ISkilled</summary>
        public void LoadAllSkillsInDB();

        ///<summary>вызывает метод GetMainPerson() у модуля, реализующий IMainPerson</summary>
        public void GetMainPerson();

        ///<summary>вызывает метод SaveMainPerson(параметры) у модуля, реализующий IMainPerson</summary>
        /// <param name="firstName">Имя пользователя</param>
        /// <param name="lastName">Фамилия пользователя</param>
        /// <param name="age">Возраст пользователя</param>
        /// <param name="height">Рост пользователя</param>
        /// <param name="weight">Вес пользователя</param>
        /// <param name="size">Размер у пользователя</param>
        public void SaveMainPerson(string firstName, string lastName, int age, int height, int weight, int size);

        ///<summary>вызывает метод DestroyFilter() у модуля, реализующий IFilterable</summary>
        public void DestroyFilter();

        ///<summary>вызывает метод LoadFilterAnimeChanList() у модуля, реализующий IFilterable</summary>
        public void LoadFilterAnimeChanList();

        ///<summary>вызывает метод FilterAnimeChanList(параметры) у модуля, реализующий IFilterable</summary>
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
        public void FilterAnimeChanList(int ageFrom, int ageTo, int heightFrom, int heightTo, int weightFrom, int weightTo, int sizeFrom, int sizeTo, List<SkillDTO> skills, bool isСonsiderAll);

        ///<summary>вызывает метод LoadFilterStats() у модуля, реализующий IFilterable</summary>
        public void LoadFilterStats();

        ///<summary>вызывает метод MakeConclution() у модуля, реализующий IConclution</summary>
        public void MakeConclution();
    }
}

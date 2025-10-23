using DataAccessLayer;
using System.Diagnostics;
using System.Xml.Linq;


namespace Model
{
    public class BourgeoisLogic
    {
        //readonly IRepository<AnimeChanRepo> repository = new AnimeChanRepository();
        //readonly IUnitOfWork unitOfWork = new EntityUnitOfWork();
        readonly IUnitOfWork unitOfWork = new DapperUnitOfWork();

        ///<summary>Создает три НЕслучаных аниме-тянок</summary>
        public void CreateAnimeChan()
        {
            unitOfWork.AnimeChanRepos.DeleteAll();
            unitOfWork.SkillRepos.DeleteAll();

            foreach(Skills skill in Enum.GetValues(typeof(Skills)))
            {
                unitOfWork.SkillRepos.Create(new SkillRepo {Name = skill.ToString() });
            }

            var anime = new AnimeChanRepo()
            {
                FirstName = "Цукико",
                LastName = "Амано",
                Age = 22,
                Height = 165,
                Weight = 53,
                Size = 2,
                Skills = unitOfWork.SkillRepos.GetByNames(new[] {Skills.Cleaning.ToString(),
                                                                 Skills.Cooking.ToString(),
                                                                 Skills.Dancing.ToString()
                                                                  }).ToList()
            };
            unitOfWork.AnimeChanRepos.Create(anime);

            anime = new AnimeChanRepo()
            {
                FirstName = "Амане",
                LastName = "Хосино",
                Age = 19,
                Height = 168,
                Weight = 51,
                Size = 3,
                Skills = unitOfWork.SkillRepos.GetByNames(new[] {Skills.Cooking.ToString(),
                                                                 Skills.Dancing.ToString()
                                                                }).ToList()
            };
            unitOfWork.AnimeChanRepos.Create(anime);

            anime = new AnimeChanRepo()
            {
                FirstName = "Миюки",
                LastName = "Кирисава",
                Age = 15,
                Height = 159,
                Weight = 57,
                Size = 4,
                Skills = unitOfWork.SkillRepos.GetByNames(new[] {Skills.Jumping.ToString(),
                                                                 Skills.FireballCast.ToString()
                                                                }).ToList()
            };
            unitOfWork.AnimeChanRepos.Create(anime);

            anime = new AnimeChanRepo()
            {
                FirstName = "Хатсунэ",
                LastName = "Мику",
                Age = 16,
                Height = 158,
                Weight = 42,
                Size = 1,
                Skills = unitOfWork.SkillRepos.GetByNames(new[] {Skills.Singing.ToString(),
                                                                 Skills.Music.ToString(),
                                                                 Skills.Dancing.ToString(),
                                                                 Skills.Art.ToString()
                                                                }).ToList()
            };
            unitOfWork.AnimeChanRepos.Create(anime);
        }

        ///<summary>Ищет в общем списке нужную тянку по её id</summary>
        /// <param name="id">Айди, по которую ищется тянка</param>
        /// <returns>Возвращает найденную тянку (или же null, если ничего не нашел)</returns>
        public AnimeChan FindById(int id)
        {
            return new AnimeChan(unitOfWork.AnimeChanRepos.ReadById(id));
        }

        ///<summary>Сохраняет список навыков</summary>
        /// <param name="list">Список навыков, который сохраняет</param>
        public void SaveSkills(Skill skill)
        {
            Saves.skills.Add(skill);
        }

        public void ClearSkills()
        {
            Saves.skills.Clear();
        }

        ///<summary>Загружает список навыков</summary>
        /// <returns>Возвращает список навыков, который был сохранен ранее</returns>
        public List<Skill> LoadSkills()
        {
            return new List<Skill>(Saves.skills);
        }

        public List<Skill> GetChanSkills(int id)
        {
            List<Skill> skills = new List<Skill>();
            foreach (var skill in unitOfWork.ChanSkillRepos.GetSkillsByChanId(id))
            {
                skills.Add(new Skill(skill));
            }
            return skills;  
        }

        ///<summary>Добавляет новую тянку в общий список</summary>
        /// <param name="firstName">Имя тянки</param>
        /// <param name="lastName">Фамилия тянки</param>
        /// <param name="age">Возраст тянки</param>
        /// <param name="height">Рост тянки</param>
        /// <param name="weight">Вес тянки</param>
        /// <param name="size">Размер у тянки</param>
        /// <param name="skills">Навыки тянки</param>
        public void AddAnimeChan(string firstName, string lastName, int age, int height, int weight, int size, List<Skill> skills)
        {
            //animeChanList.Add(new AnimeChan(firstName, lastName, age, id, height, weight, size, skills));
            AnimeChanRepo anime = new AnimeChanRepo()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Height = height,
                Weight = weight,
                Size = size,
                Skills = unitOfWork.SkillRepos.GetByNames(skills.Select(x => x.Name)).ToList()

            };
            //repository.Create(anime);

            Saves.temporaryID = anime.Id;
        }

        ///<summary>Удаляет аниме тянку</summary>
        /// <param name="id">Айди, по которому удаляется тянка</param>
        public void DeleteAnimeChan(int id)
        {
            unitOfWork.AnimeChanRepos.Delete(unitOfWork.AnimeChanRepos.ReadById(id));
        }

        ///<summary>Сохраняет изменения характеристик тянки</summary>
        /// <param name="firstName">Имя тянки</param>
        /// <param name="lastName">Фамилия тянки</param>
        /// <param name="age">Возраст тянки</param>
        /// <param name="height">Рост тянки</param>
        /// <param name="weight">Вес тянки</param>
        /// <param name="size">Размер у тянки</param>
        /// <param name="skills">Навыки тянки</param>
        /// <param name="id">Айди тянки, у которой и сохранятся изменения</param>
        public void SaveChangeAnimeChan(string firstName, string lastName, int age, int height, int weight, int size, List<Skill> skills, int id)
        {
            AnimeChanRepo animeChan = unitOfWork.AnimeChanRepos.ReadById(id);
            animeChan.Age = age;
            animeChan.Height = height;
            animeChan.Weight = weight;
            animeChan.FirstName = firstName;
            animeChan.LastName = lastName;
            animeChan.Size = size;
            animeChan.Skills = unitOfWork.SkillRepos.GetByNames(skills.Select(x => x.Name)).ToList();
            foreach (SkillRepo skill in animeChan.Skills)
            {
                Debug.WriteLine(skill.Name);
            }
            unitOfWork.AnimeChanRepos.Update(animeChan);
            Saves.temporaryID = animeChan.Id;
        }

        ///<summary>Загружает сохраненный айди</summary>
        /// <returns>Возвращает сохраненный айди ранее</returns>
        public int LoadId()
        {
            return Saves.temporaryID;
        }

        ///<summary>Сохраняет айди</summary>
        /// <param name="id">Айди, который сохранится в временный</param>
        public void SaveId(int id)
        {
            Saves.temporaryID = id;
        }

        ///<summary>Загружает данные фильтрации</summary>
        /// <returns>Возвращает все данные фильтрации</returns>
        public FilterStats LoadFilterStats()
        {
            return Saves.filterStats;
        }

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
        public void FilterAnimeChanList(int ageFrom, int ageTo, int heightFrom, int heightTo, int weightFrom, int weightTo, int sizeFrom, int sizeTo, List<Skill> skills, bool isСonsiderAll)
        {
            List<AnimeChan> list = unitOfWork.AnimeChanRepos.ReadAll()
                                             .Select(x => new AnimeChan(x))
                                             .ToList();
            Saves.filterStats.AgeFrom = ageFrom;
            Saves.filterStats.AgeTo = ageTo;
            Saves.filterStats.HeightFrom = heightFrom;
            Saves.filterStats.HeightTo = heightTo;
            Saves.filterStats.WeightFrom = weightFrom;
            Saves.filterStats.WeightTo = weightTo;
            Saves.filterStats.SizeFrom = sizeFrom;
            Saves.filterStats.SizeTo = sizeTo;
            Saves.filterStats.Skills = skills;
            Saves.filterStats.isСonsiderAll = isСonsiderAll;

            List<AnimeChan> fAnimeChanList = list.Where(a => a.Age >= ageFrom && a.Age <= ageTo && //Фильтруется по всем данным, кроме данных из списка
            a.Height >= heightFrom && a.Age <= heightTo &&
            a.Weight >= weightFrom && a.Weight <= weightTo &&
            a.Size >= sizeFrom && a.Size <= sizeTo).ToList();
            if (skills.Count != 0)
            {
                // Собираем список имён навыков, по которым фильтруем
                var skillNames = skills.Select(s => s.Name).ToHashSet();

                if (isСonsiderAll)
                {
                    // Тянка должна содержать ВСЕ выбранные навыки
                    Saves.filterAnimeChanList = fAnimeChanList
                        .Where(a => skillNames.All(reqName => a.Skills.Any(s => s.Name == reqName)))
                        .ToList();
                }
                else
                {
                    // Тянка должна содержать ХОТЯ БЫ ОДИН из выбранных навыков
                    Saves.filterAnimeChanList = fAnimeChanList
                        .Where(a => a.Skills.Any(s => skillNames.Contains(s.Name)))
                        .ToList();
                }
            }
            else
            {
                Saves.filterAnimeChanList = fAnimeChanList; //Не отфильтровывает дополнительно, если список навыков пуст
            }
        }

        ///<summary>Загружает отфильтрованный список аниме тянок</summary>
        /// <returns>Возвращает отфильтрованный список аниме тянок</returns>
        public List<AnimeChan> LoadFilterAnimeChanList()
        {
            return Saves.filterAnimeChanList
                .Select(a => new AnimeChan
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Age = a.Age,
                    Height = a.Height,
                    Weight = a.Weight,
                    Size = a.Size,
                    Skills = a.Skills.Select(s => new Skill
                    {
                        Id = s.Id,
                        Name = s.Name
                    }).ToList()
                })
                .ToList();
        }

        ///<summary>Сбрасывает значения фильтра до первоначальных</summary>
        public void DestroyFilter()
        {
            Saves.filterStats.AgeFrom = 0;
            Saves.filterStats.AgeTo = 100;
            Saves.filterStats.HeightFrom = 0;
            Saves.filterStats.HeightTo = 200;
            Saves.filterStats.WeightFrom = 0;
            Saves.filterStats.WeightTo = 100;
            Saves.filterStats.SizeFrom = 0;
            Saves.filterStats.SizeTo = 10;
            Saves.filterStats.Skills.Clear();
            Saves.filterStats.isСonsiderAll = false;
        }
        public IEnumerable<AnimeChan> LoadAnimeChanList()
        {
            return unitOfWork.AnimeChanRepos.ReadAll()
                .Select(x => new AnimeChan(x))
                .ToList();
        }

        public Skill CreateSkill(string name)
        {
            return new Skill { Name = name };
        }

        ///<summary>Сохраняет данные пользователя</summary>
        /// <param name="firstName">Имя пользователя</param>
        /// <param name="lastName">Фамилия пользователя</param>
        /// <param name="age">Возраст пользователя</param>
        /// <param name="height">Рост пользователя</param>
        /// <param name="weight">Вес пользователя</param>
        /// <param name="size">Размер у пользователя</param>
        public void SaveMainPerson(string firstName, string lastName, int age, int height, int weight, int size)
        {
            Saves.mainPerson = new MainPerson(firstName, lastName, age, height, weight, size);
        }

        ///<summary>Создаёт рандомную аниме тянку</summary>
        /// <returns>Возвращает новую сгенерированную аниме тянку</returns>
        public AnimeChan FindAnimeChan()
        {
            Random random = new Random();

            string firstName = AnimeChanName.firstName[random.Next(0, AnimeChanName.firstName.Count)]; //AnimeChanName содержит списки имен и фамилий для тянок
            string lastName = AnimeChanName.lastName[random.Next(0, AnimeChanName.lastName.Count)];
            int age = random.Next(15, 51);
            int height = random.Next(140, 201);
            int weight = random.Next(35, 81);
            int size = random.Next(1, 9);


            List<Skill> skills = new List<Skill>();
            int count = random.Next(1, 6);
            Array enums = Enum.GetValues(typeof(Skills));
            while (skills.Count < count) //Добавляет в список навыков новой тянки случайные неповторяющиеся навыки
            {
                Skill skill = new Skill();
                skill.Name = enums.GetValue(random.Next(enums.Length)).ToString();
                if (!skills.Any(x => x.Name == skill.Name))
                {
                    skills.Add(skill);
                }
            }

            var animeChan = new AnimeChanRepo()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Height = height,
                Weight = weight,
                Size = size,
                Skills = skills.Select(s => new SkillRepo { Name = s.Name }).ToList()
            };


            unitOfWork.AnimeChanRepos.Create(animeChan);
            return new AnimeChan(animeChan);
        }

        public MainPerson GetMainPerson()
        {
            return Saves.mainPerson;
        }

        ///<summary>Создаёт результат отношений с выбранной тянкой</summary>
        /// <returns>Возвращает результат отношений с выбранной тянкой</returns>
        public string Conclution()
        {
            int points = 0; //Очки, от которых будет зависеть продолжительность встречи

            string ageString = ""; //Блок текста, связанный с возрастом
            string heightString = ""; //Блок текста, связанный с ростом
            string weightString = ""; //Блок текста, связанный с весом
            string sizeString = ""; //Блок текста, связанный с размером

            AnimeChan animeChan = new AnimeChan(unitOfWork.AnimeChanRepos.ReadById(Saves.temporaryID));

            //AnimeChan animeChan = animeChanList.Where(f => f.Id == temporaryID).FirstOrDefault(); //Ищем тянку по сохраненному временному id

            int agePoints = 25 - (int)Math.Abs((Saves.mainPerson.Age - animeChan.Age - 2) * 2.5); //Очки за разницу в возрасте
                                                                                                  //(чем меньше разница - тем больше очков,
                                                                                                  //в идеале тянка должна быть на 2 года младше пользователя)
            if (agePoints < 0)
            {
                agePoints = 0;
            }
            int heightPoints = 25 - (int)Math.Abs((Saves.mainPerson.Height - animeChan.Height - 10) * 25 / 30); //Очки за разницу в росте
                                                                                                                //(чем меньше разница - тем больше очков,
                                                                                                                //в идеале тянка должна быть ниже пользователя на 10)
            if (heightPoints < 0)
            {
                heightPoints = 0;
            }
            int weightPoints = 25 - (int)Math.Abs((Saves.mainPerson.Weight - animeChan.Weight - 15)); //Очки за разницу в весе
                                                                                                      //(чем меньше разница - тем больше очков,
                                                                                                      //в идеале тянка должна легче пользователя на 15)
            if (weightPoints < 0)
            {
                weightPoints = 0;
            }
            int sizePoints = (Saves.mainPerson.Size - (animeChan.Size * 2) + 2) * 5; //Очки за разницу в размере
                                                                                     //(чем больше у пользователя - тем больше очков)
            if (sizePoints < 0)
            {
                sizePoints = 0;
            }
            if (sizePoints > 25)
            {
                sizePoints = 25;
            }

            //Все возможные тексты, зависящие от набранных очков за каждый критерий
            if (agePoints <= 5)
            {
                ageString = "Ваша разница в возрасте слишком высока! Прохожие вас видят разные поколения. Самый старший из вас чувствует себя педофилом, за что стыдно...";
            }
            else if (agePoints <= 10)
            {
                ageString = "Ваша разница в возрасте достаточно высока... Вам трудно найти общие темы для общения, но в принципе терпимо. " +
            "Иногда вы чувствуете, что живёте в разных эпохах: разные музыкальные вкусы, разные воспоминания из детства. " +
            "Но это учит вас обоих быть более терпимыми и находить красоту в различиях.";
            }
            else if (agePoints <= 15)
            {
                ageString = "Ваша разница в возрасте терпимая. Конечно, вашу вторую половинку привлекают больше ровесники, нежели вы, но вы почти не ссоритесь из-за возраста. " +
            "Вам есть чему поучиться друг у друга: один привносит мудрость и опыт, другой - свежий взгляд на жизнь. " +
            "Иногда друзья могут подшучивать над вашей разницей, но вас это не сильно беспокоит.";
            }
            else if (agePoints <= 20)
            {
                ageString = "Ваша разница в возрасте нормальная. Вы находитесь на одной жизненной волне, несмотря на небольшую разницу в годах. " +
            "Общие интересы и цели помогают легко находить темы для разговоров. " +
            "Иногда вы даже забываете, что между вами есть какая-то разница - настолько гармоничными бывают ваши отношения.";
            }
            else
            {
                ageString = "Ваша разница в возрасте идеальная! Вы будто созданы друг для друга - одинаковые взгляды на жизнь, общие ценности и прекрасное взаимопонимание. " +
            "Разница в возрасте стала вашим преимуществом: вы дополняете друг друга как паззл. " +
            "Окружающие часто отмечают, насколько вы гармонично выглядите вместе и как хорошо понимаете друг друга с полуслова.";
            }

            if (heightPoints <= 5)
            {
                heightString = "Ваша разница в росте слишком высока! Один из вас чувствует себя родителем... Иногда кто-то из вас боится самого старшего, потому что тот выглядит огромным как титан...";
            }
            else if (heightPoints <= 10)
            {
                heightString = "Ваша разница в росте высокая! Вам нужно буквально подстраиваться под друг друга: " +
                  "один постоянно наклоняется, другой тянется вверх. Совместные танцы выглядят забавно, " +
                  "а обниматься приходится очень креативно. Но если вы смогли полюбить друг друга несмотря на такую разницу.";
            }
            else if (heightPoints <= 15)
            {
                heightString = "Ваша разница в росте терпимая. Вам приходится искать компромиссы: один наклоняется, другой приподнимается. " +
                  "Общие фото иногда получаются забавными, а поцелуи требуют небольшой акробатики. ";
            }
            else if (heightPoints <= 20)
            {
                heightString = "Ваша разница в росте нормальная. Она практически незаметна в повседневной жизни и не вызывает неудобств. " +
                  "Вам удобно держаться за руки, а в объятиях вы чувствуете себя защищенно и уютно. " +
                  "Иногда кто-то из вас может пошутить над разницей, но это лишь добавляет отношениям милой непосредственности.";
            }
            else
            {
                heightString = "Ваша разница в росте идеальная! Вы созданы друг для друга - ваши взгляды встречаются на одном уровне, " +
                  "обниматься невероятно удобно, а поцелуи не требуют ни от кого усилий. " +
                  "Вы выглядите гармоничной парой и чувствуете полный комфорт в бытовых мелочах.";
            }

            if (weightPoints <= 5)
            {
                weightString = "Ваша разница в весе слишком высока! Вы выглядите как в комедии Толстый и Тонкий. Иногда кто-то из вас путает пухлого партнера с подушкой...";
            }
            else if (weightPoints <= 10)
            {
                weightString = "Ваша разница в весе высока. Обнимаясь, вы чувствуете заметную разницу, но это скорее приятно, чем нет. " +
                  "Один из вас может чувствовать себя защитником, другой - более хрупким и нуждающимся в опеке. " +
                  "Такая разница учит вас быть внимательнее к потребностям друг друга и находить удобные позы для совместного отдыха.";
            }
            else if (weightPoints <= 15)
            {
                weightString = "Ваша разница в весе терпимая. Иногда вы замечаете, что один из вас может легко поднять другого, " +
                  "а в объятиях чувствуется приятная разница. Это создает ощущение заботы и защиты. " +
                  "Вам комфортно вместе, а небольшая разница лишь добавляет отношениям пикантности и особого шарма.";
            }
            else if (weightPoints <= 20)
            {
                weightString = "Ваша разница в весе нормальная. Она практически не ощущается в повседневной жизни и не создает неудобств. " +
                  "Вы с легкостью можете делить друг с другом одежду (если, конечно, рост позволяет!), а объятия получаются крепкими и уютными. " +
                  "Телесная гармония добавляет вашим отношениям особую теплоту и близость.";
            }
            else
            {
                weightString = "Ваша разница в весе идеальна! Вы прекрасно гармонируете друг с другом - обниматься удобно, " +
                  "а в танце вы двигаетесь в полном единстве. Физическая близость доставляет комфорт и удовольствие обоим. " +
                  "Вы чувствуете, что созданы быть вместе даже в таких мелочах!";
            }

            if (sizePoints <= 5)
            {
                sizeString = "Ваша разница в размере слишком высока! Комплексы вас настигают волной, вы как можно реже хотите это видеть и об этом думать. Вам двоим безумно стыдно...";
            }
            else if (sizePoints <= 10)
            {
                sizeString = "Ваша разница в размере высока. Хорошо лишь тому партнеру, у которого маленький размер. Но другому хочется больше чувств...";
            }
            else if (sizePoints <= 15)
            {
                sizeString = "Ваша разница в размере терпимая. Впринципе у вас нет ссор на эту тему, однако кто-то из вас двоих иногда засматривается на противоположный пол, редко сожалея о том, что у вас есть терпимая, но разница.";
            }
            else if (sizePoints <= 20)
            {
                sizeString = "Ваша разница в размере нормальная. Вам приносит удовольствие это осознание. В идеале хотелось бы побольше, но вас и так все устраивает.";
            }
            else
            {
                sizeString = "Ваша разница в размере идеальна! Вы чувствуете, что вы идеально подходите друг другу в этом плане. Вам приносит это безумное удовольствие и не у кого из вас нет комплексов по этому поводу!";
            }

            points = agePoints + heightPoints + weightPoints + sizePoints; //Суммируем в общее значение
            double years = Math.Pow(points / 100.0, 3) * 50; //Конвертируем очки в годы

            string yearsStr = "";
            int count = -1;
            foreach (char x in years.ToString()) //Сокращаем дробное значение у переменной years до двух запятой
            {
                yearsStr += x;

                if (count >= 0)
                {
                    count++;
                }

                if (count == 2)
                {
                    break;
                }

                if (x == ',')
                {
                    count = 0;
                }
            }


            string str = "ВЫ ВСТРЕЧАЛИСЬ ЦЕЛЫХ " + yearsStr + " лет!\n\n\n\n" + ageString + "\n\n" + heightString + "\n\n" + weightString; //Клепаем результат в один огромным текст
            if (Saves.mainPerson.Age >= 16 && animeChan.Age >= 16)
            {
                str += "\n\n" + sizeString;
            }
            return str;
        }
}
}

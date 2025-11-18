using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AnimeChanLogic: IAnimeChan
    {
        private Saves saves;
        private IUnitOfWork unitOfWork;

        public AnimeChanLogic(Saves savess, IUnitOfWork unitOfWorkk)
        {
            saves = savess;
            unitOfWork = unitOfWorkk;
        }

        public void CreateAnimeChans()
        {
            var anime = new AnimeChan()
            {
                FirstName = "Цукико",
                LastName = "Амано",
                Age = 22,
                Height = 165,
                Weight = 53,
                Size = 2,
                Skills = { new Skill { Name = Skills.Cleaning.ToString() },
                           new Skill { Name = Skills.Cooking.ToString() },
                           new Skill { Name = Skills.Dancing.ToString() },}
            };
            saves.AnimeChanList.Add(anime);

            anime = new AnimeChan()
            {
                FirstName = "Амане",
                LastName = "Хосино",
                Age = 19,
                Height = 168,
                Weight = 51,
                Size = 3,
                Skills = { new Skill { Name = Skills.Cooking.ToString() },
                           new Skill { Name = Skills.Dancing.ToString() }, }
            };
            saves.AnimeChanList.Add(anime);

            anime = new AnimeChan()
            {
                FirstName = "Миюки",
                LastName = "Кирисава",
                Age = 15,
                Height = 159,
                Weight = 57,
                Size = 4,
                Skills = { new Skill { Name = Skills.Jumping.ToString() },
                           new Skill { Name = Skills.FireballCast.ToString() }, }
            };
            saves.AnimeChanList.Add(anime);

            anime = new AnimeChan()
            {
                FirstName = "Хатсунэ",
                LastName = "Мику",
                Age = 16,
                Height = 158,
                Weight = 42,
                Size = 1,
                Skills = { new Skill { Name = Skills.Singing.ToString() },
                           new Skill { Name = Skills.Music.ToString() },
                           new Skill { Name = Skills.Dancing.ToString() },
                           new Skill { Name = Skills.Art.ToString() },}
            };
            saves.AnimeChanList.Add(anime);
        }

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
                Skills = unitOfWork.SkillRepos.GetByNames(skills.Select(x => x.Name)).ToList()
            };


            unitOfWork.AnimeChanRepos.Create(animeChan);
            return new AnimeChan(animeChan);
        }

        public int LoadId()
        {
            return saves.TemporaryID;
        }

        public void SaveId(int id)
        {
            saves.TemporaryID = id;
        }

        public void CreateAnimeChansInDB()
        {
            foreach (AnimeChan animeChan in saves.AnimeChanList)
            {
                unitOfWork.AnimeChanRepos.Create(new AnimeChanRepo()
                {
                    FirstName = animeChan.FirstName,
                    LastName = animeChan.LastName,
                    Age = animeChan.Age,
                    Height = animeChan.Height,
                    Weight = animeChan.Weight,
                    Size = animeChan.Size,
                    Skills = unitOfWork.SkillRepos.GetByNames(animeChan.Skills.Select(x => x.Name)).ToList()
                });
            }
        }

        public void AddAnimeChan(string firstName, string lastName, int age, int height, int weight, int size, List<Skill> skills)
        {
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

            unitOfWork.AnimeChanRepos.Create(anime);

            saves.TemporaryID = anime.Id;
        }

        public void DeleteAnimeChan(int id)
        {
            unitOfWork.AnimeChanRepos.Delete(unitOfWork.AnimeChanRepos.ReadById(id));
        }

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

            unitOfWork.AnimeChanRepos.Update(animeChan);
            saves.TemporaryID = animeChan.Id;
        }
        public IEnumerable<AnimeChan> LoadAnimeChanList()
        {
            return unitOfWork.AnimeChanRepos.ReadAll()
                .Select(x => new AnimeChan(x))
                .ToList();
        }

        public void DeleteAnimeChans()
        {
            unitOfWork.AnimeChanRepos.DeleteAll();
        }

        public AnimeChan FindById(int id)
        {
            return new AnimeChan(unitOfWork.AnimeChanRepos.ReadById(id));
        }
    }
}

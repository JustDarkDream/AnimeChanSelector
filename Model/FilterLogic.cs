using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FilterLogic: IFilterable
    {
        private Saves saves;
        private IUnitOfWork unitOfWork;

        public FilterLogic(Saves savess, IUnitOfWork unitOfWorkk)
        {
            saves = savess;
            unitOfWork = unitOfWorkk;
        }
        public FilterStats LoadFilterStats()
        {
            return saves.FilterStats;
        }

        public void FilterAnimeChanList(int ageFrom, int ageTo, int heightFrom, int heightTo, int weightFrom, int weightTo, int sizeFrom, int sizeTo, List<Skill> skills, bool isСonsiderAll)
        {
            List<AnimeChan> list = unitOfWork.AnimeChanRepos.ReadAll()
                                             .Select(x => new AnimeChan(x))
                                             .ToList();
            saves.FilterStats.AgeFrom = ageFrom;
            saves.FilterStats.AgeTo = ageTo;
            saves.FilterStats.HeightFrom = heightFrom;
            saves.FilterStats.HeightTo = heightTo;
            saves.FilterStats.WeightFrom = weightFrom;
            saves.FilterStats.WeightTo = weightTo;
            saves.FilterStats.SizeFrom = sizeFrom;
            saves.FilterStats.SizeTo = sizeTo;
            saves.FilterStats.Skills = skills;
            saves.FilterStats.isСonsiderAll = isСonsiderAll;

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
                    saves.FilterAnimeChanList = fAnimeChanList
                        .Where(a => skillNames.All(reqName => a.Skills.Any(s => s.Name == reqName)))
                        .ToList();
                }
                else
                {
                    // Тянка должна содержать ХОТЯ БЫ ОДИН из выбранных навыков
                    saves.FilterAnimeChanList = fAnimeChanList
                        .Where(a => a.Skills.Any(s => skillNames.Contains(s.Name)))
                        .ToList();
                }
            }
            else
            {
                saves.FilterAnimeChanList = fAnimeChanList; //Не отфильтровывает дополнительно, если список навыков пуст
            }
        }

        public List<AnimeChan> LoadFilterAnimeChanList()
        {
            List<AnimeChan> FilteredAnimeChanList = saves.FilterAnimeChanList
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

            return FilteredAnimeChanList;
        }

        public void DestroyFilter()
        {
            saves.FilterStats.AgeFrom = 0;
            saves.FilterStats.AgeTo = 100;
            saves.FilterStats.HeightFrom = 0;
            saves.FilterStats.HeightTo = 200;
            saves.FilterStats.WeightFrom = 0;
            saves.FilterStats.WeightTo = 100;
            saves.FilterStats.SizeFrom = 0;
            saves.FilterStats.SizeTo = 10;
            saves.FilterStats.Skills.Clear();
            saves.FilterStats.isСonsiderAll = false;
        }
    }
}

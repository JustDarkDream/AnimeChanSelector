using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Model
{
    public class SkillLogic: ISkilled
    {
        event Action<List<SkillDTO>> LoadSkillsInViewEvent;
        private Saves saves { get; set; }
        private IUnitOfWork unitOfWork { get; set; }

        public SkillLogic(Saves savess, IUnitOfWork unitOfWorkk)
        {
            saves = savess;
            unitOfWork = unitOfWorkk;
        }
        public void LoadAllSkillsInDB()
        {
            foreach (Skills skill in Enum.GetValues(typeof(Skills)))
            {
                unitOfWork.SkillRepos.Create(new SkillRepo { Name = skill.ToString() });
            }
        }
        public void SaveSkill(Skill skill)
        {
            saves.Skills.Add(skill);
        }

        public void ClearSkills()
        {
            saves.Skills.Clear();
        }

        public List<Skill> LoadSkills()
        {
            return new List<Skill>(saves.Skills);
        }

        public Skill CreateSkill(string name)
        {
            return new Skill { Name = name };
        }

        public void DeleteSkills()
        {
            unitOfWork.SkillRepos.DeleteAll();
        }
    }
}

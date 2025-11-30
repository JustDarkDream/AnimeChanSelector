using Azure;
using DataAccessLayer;
using Shared;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Linq;


namespace Model
{
    public class BourgeoisLogic: ILogic
    {
        public event Action<List<SkillDTO>> LoadSkillsInViewEvent;
        public event Action<string> WriteConclutionEvent;
        public event Action<FilterStatsDTO> FilterStatsLoadedEvent;
        public event Action<IEnumerable<AnimeChanDTO>> LoadAnimeChanListEvent;
        public event Action<AnimeChanDTO> FindByIdEvent;
        public event Action<int> LoadIdEvent;
        public event Action<List<AnimeChanDTO>> LoadFilterAnimeChanListEvent;
        public event Action<AnimeChanDTO> FindAnimeChanEvent;
        public event Action<MainPersonDTO> GetMainPersonEvent;
        public event Action<SkillDTO> CreateSkillEvent;

        Saves Save;
        IUnitOfWork unitOfWork;

        private IAnimeChan AnimeChanLogic { get; }
        private ISkilled SkillLogic { get; }
        private IMainPerson MainPersonLogic { get; }
        private IConclution ConclutionLogic { get; }
        private IFilterable FilterLogic { get; }

        public BourgeoisLogic(IUnitOfWork UnitOfWork, Saves saves, IAnimeChan anime, ISkilled skill, IMainPerson main, IConclution concl, IFilterable filter)
        {
            unitOfWork = UnitOfWork;
            Save = saves;

            AnimeChanLogic = anime;
            SkillLogic = skill;
            MainPersonLogic = main;
            ConclutionLogic = concl;
            FilterLogic = filter;
        }

        public void CreateAnimeChans()
        {
            AnimeChanLogic.CreateAnimeChans();
        }

        public void FindAnimeChan()
        {
            AnimeChan anime = AnimeChanLogic.FindAnimeChan();
            AnimeChanDTO animeDTO = new AnimeChanDTO
            (
            anime.FirstName,
            anime.LastName,
            anime.Height,
            anime.Weight,
            anime.Age,
            anime.Id,
            anime.Size,
            anime.Skills.Select(skill => new SkillDTO
            (
                skill.Id,
                skill.Name
            )).ToList()
            );


            FindAnimeChanEvent.Invoke(animeDTO);
        }

        public void LoadId()
        {
            LoadIdEvent.Invoke(AnimeChanLogic.LoadId());
        }

        public void SaveId(int id)
        {
            AnimeChanLogic.SaveId(id);
        }

        public void CreateAnimeChansInDB()
        {
            AnimeChanLogic.CreateAnimeChansInDB();
        }

        public void AddAnimeChan(string firstName, string lastName, int age, int height, int weight, int size, List<SkillDTO> skillsDTO)
        {
            List<Skill> skills = skillsDTO.Select(dto => new Skill(dto)).ToList();
            AnimeChanLogic.AddAnimeChan(firstName, lastName, age, height, weight, size, skills);
        }

        public void DeleteAnimeChan(int id)
        {
            AnimeChanLogic.DeleteAnimeChan(id);
        }

        public void SaveChangeAnimeChan(string firstName, string lastName, int age, int height, int weight, int size, List<SkillDTO> skillsDTO, int id)
        {
            List<Skill> skills = skillsDTO.Select(dto => new Skill(dto)).ToList();
            AnimeChanLogic.SaveChangeAnimeChan(firstName, lastName, age, height, weight, size, skills, id);
        }

        public void LoadAnimeChanList()
        {
            IEnumerable<AnimeChan> animes = AnimeChanLogic.LoadAnimeChanList();
            IEnumerable<AnimeChanDTO> animesDTO = animes.Select(anime => new AnimeChanDTO
            (
                anime.FirstName,
                anime.LastName,
                anime.Height,
                anime.Weight,
                anime.Age,
                anime.Id,
                anime.Size,
                anime.Skills.Select(skill => new SkillDTO
                (
                    skill.Id,
                    skill.Name
                )).ToList()
            ));

            LoadAnimeChanListEvent.Invoke(animesDTO);
        }

        public void DeleteAnimeChans()
        {
            AnimeChanLogic.DeleteAnimeChans();
        }

        public void FindById(int id)
        {
            AnimeChan chan = AnimeChanLogic.FindById(id);
            AnimeChanDTO chanDTO = new AnimeChanDTO
            (
                chan.FirstName,
                chan.LastName,
                chan.Height,
                chan.Weight,
                chan.Age,
                chan.Id,
                chan.Size,
                chan.Skills.Select(skill => new SkillDTO
                (
                    skill.Id,
                    skill.Name
                )).ToList()
            );
            FindByIdEvent.Invoke(chanDTO);
        }

        public void LoadAllSkillsInDB()
        {
            SkillLogic.LoadAllSkillsInDB();
        }

        public void SaveSkill(SkillDTO skillDTO)
        {
            Skill skill = new Skill(skillDTO);
            SkillLogic.SaveSkill(skill);
        }

        public void ClearSkills()
        {
            SkillLogic.ClearSkills();
        }

        public void LoadSkills()
        {
            LoadSkillsInViewEvent.Invoke(SkillLogic.LoadSkills().Select(skill => new SkillDTO
            (
                skill.Id,
                skill.Name
            )).ToList());
        }

        public void CreateSkill(string name)
        {
            Skill skill = SkillLogic.CreateSkill(name);

            SkillDTO skillDTO = new SkillDTO
            (
                skill.Id,
                skill.Name
            );

            CreateSkillEvent.Invoke(skillDTO);
        }

        public void DeleteSkills()
        {
            SkillLogic.DeleteSkills();
        }

        public void SaveMainPerson(string firstName, string lastName, int age, int height, int weight, int size)
        {
            MainPersonLogic.SaveMainPerson(firstName, lastName, age, height, weight, size);
        }

        public void GetMainPerson()
        {
            MainPerson person = MainPersonLogic.GetMainPerson();
            MainPersonDTO personDTO = new MainPersonDTO
            (
                person.FirstName,
                person.LastName,
                person.Height,
                person.Weight,
                person.Age,
                person.Size
            );
            GetMainPersonEvent.Invoke(personDTO);
        }

        public void LoadFilterStats()
        {
            FilterStats filterStats = FilterLogic.LoadFilterStats();

            FilterStatsDTO filterStatsDTO = new FilterStatsDTO
            (
                filterStats.AgeFrom,
                filterStats.AgeTo,
                filterStats.HeightFrom,
                filterStats.HeightTo,
                filterStats.WeightFrom,
                filterStats.WeightTo,
                filterStats.SizeFrom,
                filterStats.SizeTo,
                filterStats.Skills.Select(skill => new SkillDTO
                (
                    skill.Id,
                    skill.Name
                )).ToList(),
                filterStats.isСonsiderAll
            );

            FilterStatsLoadedEvent.Invoke(filterStatsDTO);
        }

        public void FilterAnimeChanList(int ageFrom, int ageTo, int heightFrom, int heightTo, int weightFrom, int weightTo, int sizeFrom, int sizeTo, List<SkillDTO> skillsDTO, bool isСonsiderAll)
        {
            List<Skill> skills = skillsDTO.Select(dto => new Skill(dto)).ToList();
            FilterLogic.FilterAnimeChanList(ageFrom, ageTo, heightFrom, heightTo, weightFrom, weightTo, sizeFrom, sizeTo, skills, isСonsiderAll);
        }

        public void LoadFilterAnimeChanList()
        {
            List<AnimeChan> animes = FilterLogic.LoadFilterAnimeChanList();
            List<AnimeChanDTO> animesDTO = animes.Select(anime => new AnimeChanDTO
            (
                anime.FirstName,
                anime.LastName,
                anime.Height,
                anime.Weight,
                anime.Age,
                anime.Id,
                anime.Size,
                anime.Skills.Select(skill => new SkillDTO
                (
                    skill.Id,
                    skill.Name
                )).ToList()
            )).ToList();
            LoadFilterAnimeChanListEvent.Invoke(animesDTO);
        }

        public void DestroyFilter()
        {
            FilterLogic.DestroyFilter();
        }

        public void MakeConclution()
        {
            WriteConclutionEvent.Invoke(ConclutionLogic.MakeConclution());
        }
    }
}

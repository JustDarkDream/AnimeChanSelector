using DataAccessLayer;

namespace Model
{
    public class Skill : IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; internal set; }

        public Skill(DataAccessLayer.SkillRepo repo)
        {
            Id = repo.Id;
            Name = repo.Name;
        }

        public Skill(Shared.SkillDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
        }

        public Skill()
        {

        }
    }
}

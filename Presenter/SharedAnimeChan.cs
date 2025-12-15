using Shared;
using System.Collections.ObjectModel;

public class SharedAnimeChan
{
    public event Action Changed;

    private AnimeChanDTO dto;

    public ObservableCollection<SkillDTO> Skills { get; }

    public AnimeChanDTO DTO => new AnimeChanDTO(
        dto.FirstName,
        dto.LastName,
        dto.Height,
        dto.Weight,
        dto.Age,
        dto.Id,
        dto.Size,
        dto.Skills
    );

    public SharedAnimeChan(AnimeChanDTO dto)
    {
        this.dto = dto;
        Skills = new ObservableCollection<SkillDTO>(dto.Skills);
    }

    public void Update(string firstName = null, string lastName = null, int? height = null, int? weight = null, int? age = null, int? size = null, int? id = null, List<SkillDTO> skills = null)
    {
        dto = new AnimeChanDTO(
            firstName ?? dto.FirstName,
            lastName ?? dto.LastName,
            height ?? dto.Height,
            weight ?? dto.Weight,
            age ?? dto.Age,
            id ?? dto.Id,
            size ?? dto.Size,
            skills ?? dto.Skills
        );

        Changed?.Invoke();
    }

    public void SetSkills(List<SkillDTO> skills)
    {
        Skills.Clear();
        foreach (var skill in skills)
            Skills.Add(skill);

        Changed?.Invoke();
    }
}

using Controller;
using Shared;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;

public class SkillSettingsVM : ViewModel, INotifyPropertyChanged
{
    private readonly SharedAnimeChan shared;

    public ObservableCollection<SkillDTO> CurrentSkills { get; }
    public ObservableCollection<string> AllSkills { get; }

    private string selectedSkill;
    public string SelectedSkill
    {
        get => selectedSkill;
        set
        {
            selectedSkill = value;
            OnPropertyChanged(nameof(SelectedSkill));
        }
    }

    private SkillDTO selectedCurrentSkill;
    public SkillDTO SelectedCurrentSkill
    {
        get => selectedCurrentSkill;
        set
        {
            selectedCurrentSkill = value;
            OnPropertyChanged(nameof(SelectedCurrentSkill));
        }
    }

    public RelayCommand AddSkillCommand { get; }
    public RelayCommand RemoveSkillCommand { get; }
    public RelayCommand SaveCommand { get; }

    public event Action<ViewModel> SkillsSettingsMVReadyEvent;
    public event PropertyChangedEventHandler PropertyChanged;

    public SkillSettingsVM(SharedAnimeChan sharedAnimeChan)
    {
        shared = sharedAnimeChan;

        AllSkills = new ObservableCollection<string>(
            Enum.GetNames(typeof(Skills))
        );

        CurrentSkills = shared.Skills;

        AddSkillCommand = new RelayCommand(AddSkill);
        RemoveSkillCommand = new RelayCommand(RemoveSkill);
        SaveCommand = new RelayCommand(Save);
    }

    public void Start() => SkillsSettingsMVReadyEvent?.Invoke(this);

    private void AddSkill()
    {
        if (SelectedSkill == null)
            return;

        if (CurrentSkills.Any(s => s.Name == SelectedSkill))
            return;

        shared.Skills.Add(new SkillDTO(0, selectedSkill));
    }

    private void RemoveSkill()
    {
        if (SelectedCurrentSkill == null)
            return;

        shared.Skills.Remove(SelectedCurrentSkill);
    }

    private void Save()
    {
        shared.Update(skills : CurrentSkills.ToList());
    }

    protected void OnPropertyChanged(string prop)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}

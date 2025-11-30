using Ninject;
using System.Data;
using Shared;

namespace ViewForms
{
    public partial class SkillsSetting : Form, IViewSkillSetting
    {
        public event Action<string> CreateSkillEvent;
        public event Action ClearSkillsEvent;
        public event Action<SkillDTO> SaveSkillEvent;

        SkillDTO skillDTO;

        /// <summary>
        /// Конструктор формы "настройка скиллов".
        /// </summary>
        /// <param name="skills">Коллекция объектов класса Skill</param>
        public SkillsSetting(List<SkillDTO> skills)
        {

            InitializeComponent();

            skillsComboBox.DataSource = Enum.GetValues(typeof(SkillsDTO)); //Загружаем в комбо бокс все возможные навыки

            foreach (SkillDTO skill in skills) //Считывает информацию с списка навыков и закидываем в ListView
            {
                ListViewItem item = new ListViewItem(skill.Name);

                skillsView.Items.Add(item);
                item.Tag = skill;
            }
        }

        ///<summary>Вызывается при нажатии на кнопку удалении навыка. Удаляет навык из ListView</summary>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (skillsComboBox.SelectedItem is SkillDTO selectedSkill)
            {
                var item = skillsView.Items //Проверяет на наличие ListView этого элемента
                    .Cast<ListViewItem>()
                    .FirstOrDefault(i => i.Tag is SkillDTO s && s.Equals(selectedSkill));

                if (item != null) //Если он есть
                {
                    skillsView.Items.Remove(item);
                }
            }

            if (skillsComboBox.SelectedItem is SkillsDTO selected)
            {
                // Проверяем, нет ли уже такого навыка
                var existingItem = skillsView.Items
                    .Cast<ListViewItem>()
                    .FirstOrDefault(i => i.Text.Equals(selected.ToString()));

                if (existingItem != null)
                {
                    CreateSkillEvent.Invoke(selected.ToString());
                    SkillDTO newSkill = skillDTO;

                    skillsView.Items.Remove(existingItem);
                }
            }
        }

        ///<summary>Вызывается при нажатии на кнопку добавлении навыка. Добавляем навык в ListView</summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            if (skillsComboBox.SelectedItem is SkillsDTO selected)
            {
                // Проверяем, нет ли уже такого навыка
                var existingItem = skillsView.Items
                    .Cast<ListViewItem>()
                    .FirstOrDefault(i => i.Text.Equals(selected.ToString()));

                if (existingItem == null)
                {
                    CreateSkillEvent.Invoke(selected.ToString());
                    SkillDTO newSkill = skillDTO;

                    ListViewItem newItem = skillsView.Items.Add(newSkill.Name);
                    newItem.Tag = newSkill;
                }
            }
        }

        ///<summary>Вызывается при нажатии на кнопку сохранении. Сохраняет все выбранные навыки</summary>
        private void saveButton_Click(object sender, EventArgs e)
        {

            List<SkillDTO> skills = new List<SkillDTO>();
            foreach (ListViewItem item in skillsView.Items) //Считывает информацию с ListView и закидывает в список
            {
                if (item.Tag is SkillDTO skill)
                {
                    skills.Add(skill);
                }
            }
            ClearSkillsEvent.Invoke();

            foreach (SkillDTO skill in skills)
            {
                SaveSkillEvent.Invoke(skill); //Сохраняет навыки
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Событие загрузки формы настроек скиллов
        /// </summary>
        /// <param name="sender">ФОрма настройки скиллов</param>
        /// <param name="e">Контейнер аргументов</param>
        private void SkillsSetting_Load(object sender, EventArgs e)
        {

        }

        public void CreateSkill(SkillDTO skill)
        {
            skillDTO = skill;
        }
    }
}

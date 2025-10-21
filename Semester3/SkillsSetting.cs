using Model;
using System.Data;

namespace ViewForms
{
    public partial class SkillsSetting : Form
    {

        BourgeoisLogic logic = new BourgeoisLogic();

        /// <summary>
        /// Конструктор формы "настройка скиллов".
        /// </summary>
        /// <param name="skills">Коллекция объектов класса Skill</param>
        public SkillsSetting(List<Skill> skills)
        {
            InitializeComponent();

            skillsComboBox.DataSource = Enum.GetValues(typeof(Skills)); //Загружаем в комбо бокс все возможные навыки

            foreach (var skill in skills) //Считывает информацию с списка навыков и закидываем в ListView
            {
                ListViewItem item = new ListViewItem(skill.Name);

                skillsView.Items.Add(item);
                item.Tag = skill;
            }
        }

        ///<summary>Вызывается при нажатии на кнопку удалении навыка. Удаляет навык из ListView</summary>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (skillsComboBox.SelectedItem is Skill selectedSkill)
            {
                var item = skillsView.Items //Проверяет на наличие ListView этого элемента
                    .Cast<ListViewItem>()
                    .FirstOrDefault(i => i.Tag is Skill s && s.Equals(selectedSkill));

                if (item != null) //Если он есть
                {
                    skillsView.Items.Remove(item);
                }
            }

            if (skillsComboBox.SelectedItem is Skills selected)
            {
                // Проверяем, нет ли уже такого навыка
                var existingItem = skillsView.Items
                    .Cast<ListViewItem>()
                    .FirstOrDefault(i => i.Text.Equals(selected.ToString()));

                if (existingItem != null)
                {
                    Skill newSkill = logic.CreateSkill(selected.ToString());

                    skillsView.Items.Remove(existingItem);
                }
            }
        }

        ///<summary>Вызывается при нажатии на кнопку добавлении навыка. Добавляем навык в ListView</summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            if (skillsComboBox.SelectedItem is Skills selected)
            {
                // Проверяем, нет ли уже такого навыка
                var existingItem = skillsView.Items
                    .Cast<ListViewItem>()
                    .FirstOrDefault(i => i.Text.Equals(selected.ToString()));

                if (existingItem == null)
                {
                    Skill newSkill = logic.CreateSkill(selected.ToString());

                    ListViewItem newItem = skillsView.Items.Add(newSkill.Name);
                    newItem.Tag = newSkill;
                }
            }
        }

        ///<summary>Вызывается при нажатии на кнопку сохранении. Сохраняет все выбранные навыки</summary>
        private void saveButton_Click(object sender, EventArgs e)
        {

            List<Skill> skills = new List<Skill>();
            foreach (ListViewItem item in skillsView.Items) //Считывает информацию с ListView и закидывает в список
            {
                if (item.Tag is Skill skill)
                {
                    skills.Add(skill);
                }
            }
            logic.ClearSkills();
            foreach (Skill skill in skills)
            {
                logic.SaveSkills(skill); //Сохраняет навыки
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void SkillsSetting_Load(object sender, EventArgs e)
        {

        }
    }
}

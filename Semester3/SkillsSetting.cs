using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ViewForms
{
    public partial class SkillsSetting : Form
    {

        BourgeoisLogic logic = new BourgeoisLogic();

        public SkillsSetting(List<Skills> skills)
        {
            InitializeComponent();

            skillsComboBox.DataSource = Enum.GetValues(typeof(Skills)); //Загружаем в комбо бокс все возможные навыки

            foreach (var skill in skills) //Считывает информацию с списка навыков и закидываем в ListView
            {
                ListViewItem item = new ListViewItem(skill.ToString());

                skillsView.Items.Add(item);
                item.Tag = skill;
            }
        }

        ///<summary>Вызывается при нажатии на кнопку удалении навыка. Удаляет навык из ListView</summary>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (skillsComboBox.SelectedItem is Skills selectedSkill)
            {
                var item = skillsView.Items //Проверяет на наличие ListView этого элемента
                    .Cast<ListViewItem>()
                    .FirstOrDefault(i => i.Tag is Skills s && s.Equals(selectedSkill));

                if (item != null) //Если он есть
                {
                    skillsView.Items.Remove(item);
                }
            }
        }

        ///<summary>Вызывается при нажатии на кнопку добавлении навыка. Добавляем навык в ListView</summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            var existingItem = skillsView.Items
                .Cast<ListViewItem>()
                .FirstOrDefault(i => i.Text.Equals(skillsComboBox.SelectedItem.ToString())); //Проверяет на наличие ListView этого элемента

            if (existingItem == null) //Если его  нет
            {
                var selected = skillsComboBox.SelectedItem;

                ListViewItem newItem = skillsView.Items.Add(selected.ToString());
                newItem.Tag = selected;
            }
        }

        ///<summary>Вызывается при нажатии на кнопку сохранении. Сохраняет все выбранные навыки</summary>
        private void saveButton_Click(object sender, EventArgs e)
        {

            List<Skills> skills = new List<Skills>();
            foreach (ListViewItem item in skillsView.Items) //Считывает информацию с ListView и закидывает в список
            {
                if (item.Tag is Skills skill)
                {
                    skills.Add(skill);
                }
            }

            logic.SaveSkills(skills);
            Close();
        }
    }
}

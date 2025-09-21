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

            //skillsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            skillsComboBox.DataSource = Enum.GetValues(typeof(Skills));

            foreach (var skill in skills)
            {
                ListViewItem item = new ListViewItem(skill.ToString());

                skillsView.Items.Add(item);
                item.Tag = skill;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
        //    ListViewItem item = skillsView.Items
        //.Cast<ListViewItem>()
        //.FirstOrDefault(item => item.Text.Equals(skillsComboBox.SelectedItem.ToString()));
        //    if (item != null)
        //    {

        //        skillsView.Items.Remove(item);
        //        item.Tag = skill;
        //    }


            if (skillsComboBox.SelectedItem is Skills selectedSkill)
            {
                var item = skillsView.Items
                    .Cast<ListViewItem>()
                    .FirstOrDefault(i => i.Tag is Skills s && s.Equals(selectedSkill));

                if (item != null)
                {
                    skillsView.Items.Remove(item);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //            ListViewItem item = skillsView.Items
            //.Cast<ListViewItem>()
            //.FirstOrDefault(item => item.Text.Equals(skillsComboBox.SelectedItem.ToString()));
            //            if (item == null)
            //            {

            //                skillsView.Items.Add(skillsComboBox.SelectedItem.ToString());
            //                item.Tag = skillsComboBox.SelectedItem;
            //            }
            var existingItem = skillsView.Items
                .Cast<ListViewItem>()
                .FirstOrDefault(i => i.Text.Equals(skillsComboBox.SelectedItem.ToString()));

            if (existingItem == null)
            {
                var selected = skillsComboBox.SelectedItem;

                // Add возвращает ListViewItem — сохраняем его
                ListViewItem newItem = skillsView.Items.Add(selected.ToString());
                newItem.Tag = selected; // <-- теперь всё ок
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;

            List<Skills> skills = new List<Skills>();
            foreach (ListViewItem item in skillsView.Items)
            {
                if (item.Tag is Skills skill)
                {
                    skills.Add(skill);
                }
            }

            logic.SaveSkills(skills);
            Debug.WriteLine($"Всего навыков: {skills.Count}");
            foreach (Skills skill in skills)
            {
                Debug.WriteLine(skill);
            }
            Close();
        }

        private void skillsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

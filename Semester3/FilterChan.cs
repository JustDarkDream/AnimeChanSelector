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
using Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

namespace ViewForms
{
    public partial class FilterChan : Form
    {
        BourgeoisLogic logic = new BourgeoisLogic();
        public FilterChan()
        {
            InitializeComponent();
            FilterStats filterStats = logic.LoadFilterStats();

            ageFrom.Text = filterStats.AgeFrom.ToString();
            ageTo.Text = filterStats.AgeTo.ToString();
            heightFrom.Text = filterStats.HeightFrom.ToString();
            heightTo.Text = filterStats.HeightTo.ToString();
            sizeFrom.Text = filterStats.SizeFrom.ToString();
            sizeTo.Text = filterStats.SizeTo.ToString();
            weightFrom.Text = filterStats.WeightFrom.ToString();
            weightTo.Text = filterStats.WeightTo.ToString();

            checkBox1.Checked = filterStats.isСonsiderAll;

            foreach (var skill in filterStats.Skills)
            {
                ListViewItem item = new ListViewItem(skill.ToString());
                item.Tag = skill;

                listView1.Items.Add(item);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ageValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveFilter_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ageFrom.Text, out int agefrom) && agefrom >= 0)
            {
                if (int.TryParse(ageTo.Text, out int ageto) && ageto >= 0)
                {
                    if (int.TryParse(heightFrom.Text, out int heightfrom) && heightfrom >= 0)
                    {
                        if (int.TryParse(heightTo.Text, out int heightto) && heightto >= 0)
                        {
                            if (int.TryParse(weightFrom.Text, out int weightfrom) && weightfrom >= 0)
                            {
                                if (int.TryParse(weightTo.Text, out int weightto) && weightto >= 0)
                                {
                                    if (int.TryParse(sizeFrom.Text, out int sizefrom) && sizefrom >= 0)
                                    {
                                        if (int.TryParse(sizeTo.Text, out int sizeto) && sizeto >= 0)
                                        {
                                            if (agefrom <= ageto)
                                            {
                                                if (heightfrom <= heightto)
                                                {
                                                    if (weightfrom <= weightto)
                                                    {
                                                        if (sizefrom <= sizeto)
                                                        {
                                                            List<Skills> skills = new List<Skills>();

                                                            foreach (ListViewItem item in listView1.Items)
                                                            {
                                                                if (item.Tag is Skills skill)
                                                                {
                                                                    skills.Add(skill);
                                                                }
                                                            }
                                                            logic.FilterAnimeChanList(agefrom, ageto, heightfrom, heightto, weightfrom, weightto, sizefrom, sizeto, skills, checkBox1.Checked);
                                                            this.DialogResult = DialogResult.OK;
                                                            Close();
                                                        }
                                                        else
                                                        {
                                                            Error error = new Error("Значение \"Размер ОТ\" не может быть больше значения \"Размер ДО\"");
                                                            error.ShowDialog();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Error error = new Error("Значение \"Вес ОТ\" не может быть больше значения \"Вес ДО\"");
                                                        error.ShowDialog();
                                                    }
                                                }
                                                else
                                                {
                                                    Error error = new Error("Значение \"Рост ОТ\" не может быть больше значения \"Рост ДО\"");
                                                    error.ShowDialog();
                                                }
                                            }
                                            else
                                            {
                                                Error error = new Error("Значение \"Возраст ОТ\" не может быть больше значения \"Возраст ДО\"");
                                                error.ShowDialog();
                                            }
                                        }
                                        else
                                        {
                                            Error error = new Error("Введено некорректное значение в \"Размер ДО\". Введите неотрицательно число");
                                            error.ShowDialog();
                                        }
                                    }
                                    else
                                    {
                                        Error error = new Error("Введено некорректное значение в \"Размер ОТ\". Введите неотрицательно число");
                                        error.ShowDialog();
                                    }
                                }
                                else
                                {
                                    Error error = new Error("Введено некорректное значение в \"Вес ДО\". Введите неотрицательно число");
                                    error.ShowDialog();
                                }
                            }
                            else
                            {
                                Error error = new Error("Введено некорректное значение в \"Вес ОТ\". Введите неотрицательно число");
                                error.ShowDialog();
                            }
                        }
                        else
                        {
                            Error error = new Error("Введено некорректное значение в \"Рост ДО\". Введите неотрицательно число");
                            error.ShowDialog();
                        }
                    }
                    else
                    {
                        Error error = new Error("Введено некорректное значение в \"Рост ОТ\". Введите неотрицательно число");
                        error.ShowDialog();
                    }
                }
                else
                {
                    Error error = new Error("Введено некорректное значение в \"Возраст ДО\". Введите неотрицательно число");
                    error.ShowDialog();
                }
            }
            else
            {
                Error error = new Error("Введено некорректное значение в \"Возраст ОТ\". Введите неотрицательно число");
                error.ShowDialog();
            }
        }

        private void skillsSettung_Click(object sender, EventArgs e)
        {
            List<Skills> skills = new List<Skills>();

            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Tag is Skills skill) // ← Правильно!
                {
                    skills.Add(skill);
                }
            }

            SkillsSetting skillsSetting = new SkillsSetting(skills);

            listView1.Items.Clear();

            skillsSetting.ShowDialog();
            Debug.WriteLine(logic.LoadSkills().Count);

            foreach (Skills skill in logic.LoadSkills())
            {
                ListViewItem newItem = new ListViewItem(skill.ToString()); // Используйте ToString()
                newItem.Tag = skill; // Сохраняем enum значение в Tag
                listView1.Items.Add(newItem);
            }
        }
    }
}

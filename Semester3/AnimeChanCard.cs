using Microsoft.VisualBasic.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ViewForms
{
    public partial class AnimeChanCard : Form
    {
        BourgeoisLogic logic = new BourgeoisLogic();
        int animeChanId = 0;

        public AnimeChanCard(AnimeChan animeChan, bool isEditable)
        {
            InitializeComponent();
            firstName.Text = animeChan.FirstName;
            lastName.Text = animeChan.LastName;

            ageValue.Text = animeChan.Age.ToString();
            heightValue.Text = animeChan.Height.ToString();
            weightValue.Text = animeChan.Weight.ToString();
            sizeValue.Text = animeChan.Size.ToString();

            animeChanId = animeChan.Id;

            listView1.Clear();

            foreach (var skill in animeChan.Skills)
            {
                ListViewItem item = new ListViewItem(skill.ToString());
                item.Tag = skill;

                listView1.Items.Add(item);
            }
            addChan.Visible = false;
            addChan.Enabled = false;
            chooseHer.Visible = !isEditable;
            chooseHer.Enabled = !isEditable;
            skillsSettung.Visible = isEditable;
            skillsSettung.Enabled = isEditable;
            saveChanges.Enabled = isEditable;
            saveChanges.Visible = isEditable;

            firstName.Enabled = isEditable;
            lastName.Enabled = isEditable;
            ageValue.Enabled = isEditable;
            heightValue.Enabled = isEditable;
            weightValue.Enabled = isEditable;
            sizeValue.Enabled = isEditable;

        }
        public AnimeChanCard()
        {
            InitializeComponent();
            firstName.Text = "";
            lastName.Text = "";
            ageValue.Text = "";
            heightValue.Text = "";
            weightValue.Text = "";
            sizeValue.Text = "";
            listView1.Clear();

            addChan.Visible = true;
            addChan.Enabled = true;
            chooseHer.Visible = false;
            chooseHer.Enabled = false;
            skillsSettung.Visible = true;
            skillsSettung.Enabled = true;
            saveChanges.Enabled = false;
            saveChanges.Visible = false;

            firstName.Enabled = true;
            lastName.Enabled = true;
            ageValue.Enabled = true;
            heightValue.Enabled = true;
            weightValue.Enabled = true;
            sizeValue.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void height_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void skillsSettung_Click(object sender, EventArgs e)
        {
            List<Skills> skills = new List<Skills>();

            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Tag is Skills skill)
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
                ListViewItem newItem = new ListViewItem(skill.ToString());
                newItem.Tag = skill;
                listView1.Items.Add(newItem);
            }
        }

        private void addChan_Click(object sender, EventArgs e)
        {
            {
                if (int.TryParse(ageValue.Text, out int age) && age >= 0)
                {
                    if (int.TryParse(heightValue.Text, out int height) && height >= 0)
                    {
                        if (int.TryParse(weightValue.Text, out int weight) && weight >= 0)
                        {
                            if (int.TryParse(sizeValue.Text, out int size) && size >= 0)
                            {
                                if (firstName.Text.Length > 0)
                                {
                                    if (lastName.Text.Length > 0)
                                    {
                                        List<Skills> skills = new List<Skills>();

                                        foreach (ListViewItem item in listView1.Items)
                                        {
                                            if (item.Tag is Skills skill)
                                            {
                                                skills.Add(skill);
                                            }
                                        }
                                        logic.AddAnimeChan(firstName.Text, lastName.Text, age, height, weight, size, skills);
                                        this.DialogResult = DialogResult.OK;
                                        Close();
                                    }
                                    else
                                    {
                                        Error error = new Error("Ничего не введено в строку \"Фамилия\". Введите что-нибудь");
                                        error.ShowDialog();
                                    }
                                }
                                else
                                {
                                    Error error = new Error("Ничего не введено в строку \"Имя\". Введите что-нибудь");
                                    error.ShowDialog();
                                }
                            }
                            else
                            {
                                Error error = new Error("Введено некорректное значение в \"Размер\". Введите неотрицательно число");
                                error.ShowDialog();
                            }
                        }
                        else
                        {
                            Error error = new Error("Введено некорректное значение в \"Вес\". Введите неотрицательно число");
                            error.ShowDialog();
                        }
                    }
                    else
                    {
                        Error error = new Error("Введено некорректное значение в \"Рост\". Введите неотрицательно число");
                        error.ShowDialog();
                    }
                }
                else
                {
                    Error error = new Error("Введено некорректное значение в \"Возраст\". Введите неотрицательно число");
                    error.ShowDialog();
                }
            }
        }

        private void saveChanges_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ageValue.Text, out int age) && age >= 0)
            {
                if (int.TryParse(heightValue.Text, out int height) && height >= 0)
                {
                    if (int.TryParse(weightValue.Text, out int weight) && weight >= 0)
                    {
                        if (int.TryParse(sizeValue.Text, out int size) && size >= 0)
                        {
                            if (firstName.Text.Length > 0)
                            {
                                if (lastName.Text.Length > 0)
                                {
                                    List<Skills> skills = new List<Skills>();

                                    foreach (ListViewItem item in listView1.Items)
                                    {
                                        if (item.Tag is Skills skill)
                                        {
                                            skills.Add(skill);
                                        }
                                    }
                                    logic.SaveChangeAnimeChan(firstName.Text, lastName.Text, age, height, weight, size, skills, animeChanId);
                                    this.DialogResult = DialogResult.OK;
                                    Close();
                                }
                                else
                                {
                                    Error error = new Error("Ничего не введено в строку \"Фамилия\". Введите что-нибудь");
                                    error.ShowDialog();
                                }
                            }
                            else
                            {
                                Error error = new Error("Ничего не введено в строку \"Имя\". Введите что-нибудь");
                                error.ShowDialog();
                            }
                        }
                        else
                        {
                            Error error = new Error("Введено некорректное значение в \"Размер\". Введите число");
                            error.ShowDialog();
                        }
                    }
                    else
                    {
                        Error error = new Error("Введено некорректное значение в \"Вес\". Введите число");
                        error.ShowDialog();
                    }
                }
                else
                {
                    Error error = new Error("Введено некорректное значение в \"Рост\". Введите число");
                    error.ShowDialog();
                }
            }
            else
            {
                Error error = new Error("Введено некорректное значение в \"Возраст\". Введите число");
                error.ShowDialog();
            }
        }

        private void chooseHer_Click(object sender, EventArgs e)
        {
            logic.SaveId(animeChanId);
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}

using Model;
using Microsoft.VisualBasic;
using System.Data;
using System.Linq;

namespace ViewForms
{
    public partial class Form1 : Form
    {

        DataGridView table;
        BourgeoisLogic logic = new BourgeoisLogic();
        public Form1()
        {
            InitializeComponent();

            table = dataGridView1;

            CreateDataGridView();
        }

        private void CreateDataGridView()
        {
            table.Rows.Clear();
            table.Columns.Clear();

            table.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColumnFirstName",
                HeaderText = "Имя",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            table.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColumnLastName",
                HeaderText = "Фамилия",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            table.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColumnAge",
                HeaderText = "Возраст",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            table.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColumnId",
                HeaderText = "Id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            foreach (var i in logic.CreateAnimeChan())
            {
                table.Rows.Add(i.FirstName, i.LastName, i.Age, i.Id);
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (dataGridView1.CurrentRow != null && dataGridView1.SelectedRows.Count == 1)
                {
                    int id = Convert.ToInt32(table.CurrentRow.Cells["ColumnId"].Value);

                    AnimeChanCard animeChanCard = new AnimeChanCard(logic.FindForId(id), false);
                    if (animeChanCard.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    if (dataGridView1.SelectedRows.Count == 0)
                    {
                        Error error = new Error("Выберите строку, чтобы показать характеристики Аниме-тян");
                        error.ShowDialog();
                    }
                    else if (dataGridView1.SelectedRows.Count > 1)
                    {
                        Error error = new Error("Выбрано слишком много. Выберите лишь одну строку");
                        error.ShowDialog();
                    }
                }
            }
        }

        private void createChan_Click(object sender, EventArgs e)
        {
            AnimeChanCard animeChanCard = new AnimeChanCard();
            if (animeChanCard.ShowDialog() == DialogResult.OK)
            {
                int id = logic.LoadId();
                table.Rows.Add(logic.FindForId(id).FirstName, logic.FindForId(id).LastName, logic.FindForId(id).Age, logic.FindForId(id).Id);
            }
        }

        private void deleteChan_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(table.CurrentRow.Cells["ColumnId"].Value);

                logic.DeleteAnimeChan(id);
                table.Rows.Remove(table.CurrentRow);
            }
            else
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    Error error = new Error("Выберите строку, чтобы удалить Аниме-тян");
                    error.ShowDialog();
                }
                else if (dataGridView1.SelectedRows.Count > 1)
                {
                    Error error = new Error("Выбрано слишком много. Выберите лишь одну строку");
                    error.ShowDialog();
                }
            }
        }

        private void SettingChan_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(table.CurrentRow.Cells["ColumnId"].Value);

                AnimeChanCard animeChanCard = new AnimeChanCard(logic.FindForId(id), true);
                if (animeChanCard.ShowDialog() == DialogResult.OK)
                {
                    DataGridViewRow foundRows = table.Rows.Cast<DataGridViewRow>()
                                                          .FirstOrDefault(row => Convert.ToInt32(row.Cells["ColumnId"].Value) == id);
                    foundRows.Cells["ColumnFirstName"].Value = logic.FindForId(id).FirstName;
                    foundRows.Cells["ColumnLastName"].Value = logic.FindForId(id).LastName;
                    foundRows.Cells["ColumnAge"].Value = logic.FindForId(id).Age;
                }
            }
            else
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    Error error = new Error("Выберите строку, чтобы изменить характеристики Аниме-тян");
                    error.ShowDialog();
                }
                else if (dataGridView1.SelectedRows.Count > 1)
                {
                    Error error = new Error("Выбрано слишком много. Выберите лишь одну строку");
                    error.ShowDialog();
                }
            }
        }

        private void filter_Click(object sender, EventArgs e)
        {
            FilterChan filterChan = new FilterChan();
            if (filterChan.ShowDialog() == DialogResult.OK)
            {
                table.Rows.Clear();
                foreach (var i in logic.LoadFilterAnimeChanList())
                {
                    table.Rows.Add(i.FirstName, i.LastName, i.Age, i.Id);
                };
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            table.Rows.Clear();
            foreach (var i in logic.LoadAnimeChanList())
            {
                table.Rows.Add(i.FirstName, i.LastName, i.Age, i.Id);
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnimeChan animeChan = logic.FindAnimeChan();
            table.Rows.Add(animeChan.FirstName, animeChan.LastName, animeChan.Age, animeChan.Id);
        }
    }
}

using Model;
using Microsoft.VisualBasic;
using System.Data;
using System.Linq;
using DataAccessLayer;
using System.Diagnostics;

namespace ViewForms
{
    public partial class MainForm : Form
    {

        DataGridView table;
        BourgeoisLogic logic = new BourgeoisLogic();
        public MainForm()
        {
            InitializeComponent();

            table = dataGridView1;

            CreateDataGridView();
        }

        ///<summary>Создаёт начальную таблицу с аниме тянками</summary>
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

            logic.CreateAnimeChan();
            //AnimeChan anime = logic.LoadAnimeChanList(0);
            //int i = 0;
            //while (anime != null)
            //{
            //    anime = logic.LoadAnimeChanList(i);
            //    i++;
            //    table.Rows.Add(anime.FirstName, anime.LastName, anime.Age, anime.Id);
            //}
            foreach (var i in logic.LoadAnimeChanList())
            {
                table.Rows.Add(i.FirstName, i.LastName, i.Age, i.Id);
            };
        }

        ///<summary>Вызывается при нажатии на кнопку просмотра тянки. Позволяет выбрать тян, открывая для этого специальную форму</summary>
        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (dataGridView1.CurrentRow != null && dataGridView1.SelectedRows.Count == 1) //Проверяет, выбрана ли лишь одна строка
                {
                    int id = Convert.ToInt32(table.CurrentRow.Cells["ColumnId"].Value); //Считываем значение id этой строки

                    AnimeChanCard animeChanCard = new AnimeChanCard(logic.FindForId(id), false); //Создаем новую форму
                    if (animeChanCard.ShowDialog() == DialogResult.OK) //Если изменения сохранены, то закрывает эту форму и открывает итоговое окно
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

        ///<summary>Вызывается при нажатии на кнопку создании тянки. Позволяет создать тянку, открывая для этого специальную форму</summary>
        private void createChan_Click(object sender, EventArgs e)
        {
            AnimeChanCard animeChanCard = new AnimeChanCard(); //Создаем новую форму
            if (animeChanCard.ShowDialog() == DialogResult.OK) //Если изменения сохранены, то добавляет в таблицу новую тян
            {
                int id = logic.LoadId();
                table.Rows.Add(logic.FindForId(id).FirstName, logic.FindForId(id).LastName, logic.FindForId(id).Age, logic.FindForId(id).Id);
            }
        }

        ///<summary>Вызывается при нажатии на кнопку удалении тянки. Позволяет удалить тянку из таблицы</summary>
        private void deleteChan_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.SelectedRows.Count == 1) //Проверяет, выбрана ли лишь одна строка
            {
                int id = Convert.ToInt32(table.CurrentRow.Cells["ColumnId"].Value); //Считываем значение id этой строки

                logic.DeleteAnimeChan(id); //Удаляет тян из общего списка
                table.Rows.Remove(table.CurrentRow); //Удаляет тян из таблицы
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

        ///<summary>Вызывается при нажатии на кнопку редактирования тянки. Позволяет редактировать определенную тянку, открывая для этого специальную форму</summary>
        private void SettingChan_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.SelectedRows.Count == 1) //Проверяет, выбрана ли лишь одна строка
            {
                int id = Convert.ToInt32(table.CurrentRow.Cells["ColumnId"].Value); //Считываем значение id этой строки

                AnimeChanCard animeChanCard = new AnimeChanCard(logic.FindForId(id), true); //Создаем новую форму
                if (animeChanCard.ShowDialog() == DialogResult.OK) //Если изменения сохранены, то находит нужную строку по id и обновляет её
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

        ///<summary>Вызывается при нажатии на кнопку фильтрации. Фильтрует таблицу, открывая для этого специальную форму</summary>
        private void filter_Click(object sender, EventArgs e)
        {
            FilterChan filterChan = new FilterChan(); //Создаем новую форму
            if (filterChan.ShowDialog() == DialogResult.OK) //Если изменения сохранены, то очищает таблицу и загружает значения из отфильтрованного списка
            {
                table.Rows.Clear();
                //AnimeChan anime = logic.LoadFilterAnimeChanList(0);
                //int i = 0;
                //while (anime != null)
                //{
                //    anime = logic.LoadFilterAnimeChanList(i);
                //    i++;
                //    table.Rows.Add(anime.FirstName, anime.LastName, anime.Age, anime.Id);
                //}
                foreach (var i in logic.LoadFilterAnimeChanList())
                {
                    table.Rows.Add(i.FirstName, i.LastName, i.Age, i.Id);
                };
            }
        }

        ///<summary>Вызывается при нажатии на кнопку удаления фильтрации. Приводит таблицу без фильтрации</summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            logic.DestroyFilter();
            table.Rows.Clear();

            //logic.LoadAnimeChanList();
            //AnimeChan anime = logic.LoadAnimeChanList();
            //int i = 0;
            //while (anime != null)
            //{
            //    anime = logic.LoadAnimeChanList(i);
            //    i++;
            //    table.Rows.Add(anime.FirstName, anime.LastName, anime.Age, anime.Id);
            //}
            foreach (var i in logic.LoadAnimeChanList()) //Загружает строки с аниме тянками из полного списка в таблицу
            {
                table.Rows.Add(i.FirstName, i.LastName, i.Age, i.Id);
            };
        }

        ///<summary>Вызывается при нажатии на кнопку нахождения тянки. Добавляет в таблицу новую сгенерированную тянку</summary>
        private void button2_Click(object sender, EventArgs e)
        {
            AnimeChan animeChan = logic.FindAnimeChan();
            table.Rows.Add(animeChan.FirstName, animeChan.LastName, animeChan.Age, animeChan.Id);
        }
    }
}

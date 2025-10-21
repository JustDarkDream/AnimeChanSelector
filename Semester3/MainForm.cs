using Model;
using System.Data;

namespace ViewForms
{
    public partial class MainForm : Form
    {

        DataGridView table;
        BourgeoisLogic logic = new BourgeoisLogic();
        public MainForm()
        {
            InitializeComponent();

            table = dgwTabel;

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
            }
            ;
        }

        ///<summary>Вызывается при нажатии на кнопку просмотра тянки. Позволяет выбрать тян, открывая для этого специальную форму</summary>
        private void btnshowcard_Click(object sender, EventArgs e)
        {
            {
                if (dgwTabel.CurrentRow != null && dgwTabel.SelectedRows.Count == 1) //Проверяет, выбрана ли лишь одна строка
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
                    if (dgwTabel.SelectedRows.Count == 0)
                    {
                        ErrorForm error = new ErrorForm("Выберите строку, чтобы показать характеристики Аниме-тян");
                        error.ShowDialog();
                    }
                    else if (dgwTabel.SelectedRows.Count > 1)
                    {
                        ErrorForm error = new ErrorForm("Выбрано слишком много. Выберите лишь одну строку");
                        error.ShowDialog();
                    }
                }
            }
        }

        ///<summary>Вызывается при нажатии на кнопку создании тянки. Позволяет создать тянку, открывая для этого специальную форму</summary>
        private void btnCreateChan_Click(object sender, EventArgs e)
        {
            AnimeChanCard animeChanCard = new AnimeChanCard(); //Создаем новую форму
            if (animeChanCard.ShowDialog() == DialogResult.OK) //Если изменения сохранены, то добавляет в таблицу новую тян
            {
                int id = logic.LoadId();
                table.Rows.Add(logic.FindForId(id).FirstName, logic.FindForId(id).LastName, logic.FindForId(id).Age, logic.FindForId(id).Id);
            }
        }

        ///<summary>Вызывается при нажатии на кнопку удалении тянки. Позволяет удалить тянку из таблицы</summary>
        private void btnDeleteChan_Click(object sender, EventArgs e)
        {
            if (dgwTabel.CurrentRow != null && dgwTabel.SelectedRows.Count <= 1) //Проверяет, выбрана ли лишь одна строка
            {
                int id = Convert.ToInt32(table.CurrentRow.Cells["ColumnId"].Value); //Считываем значение id этой строки

                logic.DeleteAnimeChan(id); //Удаляет тян из общего списка
                table.Rows.Remove(table.Rows[table.CurrentCell.RowIndex]); //Удаляет тян из таблицы
            }
            else
            {
                if (dgwTabel.SelectedRows.Count == 0)
                {
                    ErrorForm error = new ErrorForm("Выберите строку, чтобы удалить Аниме-тян");
                    error.ShowDialog();
                }
                else if (dgwTabel.SelectedRows.Count > 1)
                {
                    ErrorForm error = new ErrorForm("Выбрано слишком много. Выберите лишь одну строку");
                    error.ShowDialog();
                }
            }
        }

        ///<summary>Вызывается при нажатии на кнопку редактирования тянки. Позволяет редактировать определенную тянку, открывая для этого специальную форму</summary>
        private void btnSettingChan_Click(object sender, EventArgs e)
        {
            if (dgwTabel.CurrentRow != null && dgwTabel.SelectedRows.Count <= 1) //Проверяет, выбрана ли лишь одна строка
            {
                int id = Convert.ToInt32(table.Rows[table.CurrentCell.RowIndex].Cells["ColumnId"].Value); //Считываем значение id этой строки

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
                if (dgwTabel.SelectedRows.Count == 0)
                {
                    ErrorForm error = new ErrorForm("Выберите строку, чтобы изменить характеристики Аниме-тян");
                    error.ShowDialog();
                }
                else if (dgwTabel.SelectedRows.Count > 1)
                {
                    ErrorForm error = new ErrorForm("Выбрано слишком много. Выберите лишь одну строку");
                    error.ShowDialog();
                }
            }
        }

        ///<summary>Вызывается при нажатии на кнопку фильтрации. Фильтрует таблицу, открывая для этого специальную форму</summary>
        private void btnfilter_Click(object sender, EventArgs e)
        {
            FilterChan filterChan = new FilterChan(); //Создаем новую форму
            if (filterChan.ShowDialog() == DialogResult.OK) //Если изменения сохранены, то очищает таблицу и загружает значения из отфильтрованного списка
            {
                table.Rows.Clear();
              
                foreach (var i in logic.LoadFilterAnimeChanList())
                {
                    table.Rows.Add(i.FirstName, i.LastName, i.Age, i.Id);
                }
                ;
            }
        }

        ///<summary>Вызывается при нажатии на кнопку удаления фильтрации. Приводит таблицу без фильтрации</summary>
        private void btnFilterOff_Click(object sender, EventArgs e)
        {
            logic.DestroyFilter();
            table.Rows.Clear();

            foreach (var i in logic.LoadAnimeChanList()) //Загружает строки с аниме тянками из полного списка в таблицу
            {
                table.Rows.Add(i.FirstName, i.LastName, i.Age, i.Id);
            }
            ;
        }

        ///<summary>Вызывается при нажатии на кнопку нахождения тянки. Добавляет в таблицу новую сгенерированную тянку</summary>
        private void button2_Click(object sender, EventArgs e)
        {
            AnimeChan animeChan = logic.FindAnimeChan();
            table.Rows.Add(animeChan.FirstName, animeChan.LastName, animeChan.Age, animeChan.Id);
        }

        /// <summary>
        /// Событие изменения размеров формы
        /// </summary>
        /// <param name="sender">форма Mainform</param>
        /// <param name="e">Контейнер аргументов события</param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                float scaleFactor = (float)this.ClientSize.Width / 800f;
                btncreateChan.Font = new Font("Segoe UI", 7f * scaleFactor, FontStyle.Regular);
                btndeleteChan.Font = new Font("Segoe UI", 7f * scaleFactor, FontStyle.Regular);
                btnfilter.Font = new Font("Segoe UI", 7f * scaleFactor, FontStyle.Regular);
                btnFilterOff.Font = new Font("Segoe UI", 7f * scaleFactor, FontStyle.Regular);
                btnfindChan.Font = new Font("Segoe UI", 7f * scaleFactor, FontStyle.Regular);
                btnSettingChan.Font = new Font("Segoe UI", 7f * scaleFactor, FontStyle.Regular);
                btnshowCard.Font = new Font("Segoe UI", 7f * scaleFactor, FontStyle.Regular);
                lblName.Font = new Font("Segoe UI", 7f * scaleFactor, FontStyle.Regular);
                dgwTabel.Font = new Font("Segoe UI", 7f * scaleFactor, FontStyle.Regular);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

    }
}

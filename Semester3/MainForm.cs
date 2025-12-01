using Shared;
using Ninject;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace ViewForms
{
    public partial class MainForm : Form, IViewMainForm
    {
        public event Action LoadAnimeChanListEvent;
        public event Action<int> FindByIdEvent;
        public event Action LoadIdEvent;
        public event Action<int> DeleteAnimeChanEvent;
        public event Action LoadFilterAnimeChanListEvent;
        public event Action DestroyFilterEvent;
        public event Action FindAnimeChanEvent;
        public event Action GetMainPersonEvent;

        public event Func<IViewAnimeChanCard> GetIViewAnimeChanCardEvent;
        public event Func<IViewFilterChan> GetIViewFilterChanEvent;

        List<AnimeChanDTO> listChanDTO;
        List<AnimeChanDTO> filterListChanDTO;
        AnimeChanDTO findByIdChanDTO;
        AnimeChanDTO findChanDTO;
        MainPersonDTO mainPersonDTO;
        int loadId;

        DataGridView table;
        
        /// <summary>
        /// Конструктор главной формы
        /// </summary>
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
        }

        public void WriteAnimeChanTable()
        {
            LoadAnimeChanListEvent.Invoke();
            foreach (var i in listChanDTO)
            {
                table.Rows.Add(i.FirstName, i.LastName, i.Age, i.Id);
            }
        }

        ///<summary>Вызывается при нажатии на кнопку просмотра тянки. Позволяет выбрать тян, открывая для этого специальную форму</summary>
        private void btnshowcard_Click(object sender, EventArgs e)
        {
            {
                if (dgwTabel.CurrentRow != null && dgwTabel.SelectedRows.Count <= 1) //Проверяет, выбрана ли лишь одна строка
                {
                    int id = Convert.ToInt32(table.CurrentRow.Cells["ColumnId"].Value); //Считываем значение id этой строки

                    FindByIdEvent.Invoke(id);
                    IViewAnimeChanCard animeChanCard = GetIViewAnimeChanCardEvent.Invoke(); //Создаем новую форму

                    if (animeChanCard.CorrectWork(findByIdChanDTO, false)) //Если изменения сохранены, то закрывает эту форму и открывает итоговое окно
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
            IViewAnimeChanCard animeChanCard = GetIViewAnimeChanCardEvent.Invoke(); //Создаем новую форму

            if (animeChanCard.CorrectWork()) //Если изменения сохранены, то добавляет в таблицу новую тян
            {
                LoadIdEvent.Invoke();
                int id = loadId;
                FindByIdEvent.Invoke(id);
                table.Rows.Add(findByIdChanDTO.FirstName, findByIdChanDTO.LastName, findByIdChanDTO.Age, findByIdChanDTO.Id);
            }
        }

        ///<summary>Вызывается при нажатии на кнопку удалении тянки. Позволяет удалить тянку из таблицы</summary>
        private void btnDeleteChan_Click(object sender, EventArgs e)
        {
            if (dgwTabel.CurrentRow != null && dgwTabel.SelectedRows.Count <= 1) //Проверяет, выбрана ли лишь одна строка
            {
                int id = Convert.ToInt32(table.CurrentRow.Cells["ColumnId"].Value); //Считываем значение id этой строки

                DeleteAnimeChanEvent.Invoke(id); //Удаляет тян из общего списка
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
                FindByIdEvent.Invoke(id);
                IViewAnimeChanCard animeChanCard = GetIViewAnimeChanCardEvent.Invoke(); //Создаем новую форму

                if (animeChanCard.CorrectWork(findByIdChanDTO, true)) //Если изменения сохранены, то находит нужную строку по id и обновляет её DialogResult.OK
                {
                    DataGridViewRow foundRows = table.Rows.Cast<DataGridViewRow>()
                                                          .FirstOrDefault(row => Convert.ToInt32(row.Cells["ColumnId"].Value) == id);
                    FindByIdEvent.Invoke(id);
                    foundRows.Cells["ColumnFirstName"].Value = findByIdChanDTO.FirstName;
                    foundRows.Cells["ColumnLastName"].Value = findByIdChanDTO.LastName;
                    foundRows.Cells["ColumnAge"].Value = findByIdChanDTO.Age;
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
            IViewFilterChan filterChan = GetIViewFilterChanEvent.Invoke(); //Создаем новую форму

            if (filterChan.CorrectWork()) //Если изменения сохранены, то очищает таблицу и загружает значения из отфильтрованного списка
            {
                table.Rows.Clear();

                LoadFilterAnimeChanListEvent.Invoke();

                foreach (var i in filterListChanDTO)
                {
                    table.Rows.Add(i.FirstName, i.LastName, i.Age, i.Id);
                }
                ;
            }
        }

        ///<summary>Вызывается при нажатии на кнопку удаления фильтрации. Приводит таблицу без фильтрации</summary>
        private void btnFilterOff_Click(object sender, EventArgs e)
        {
            DestroyFilterEvent.Invoke();
            table.Rows.Clear();

            LoadAnimeChanListEvent.Invoke();
            foreach (var i in listChanDTO) //Загружает строки с аниме тянками из полного списка в таблицу
            {
                table.Rows.Add(i.FirstName, i.LastName, i.Age, i.Id);
            }
            ;
        }

        ///<summary>Вызывается при нажатии на кнопку нахождения тянки. Добавляет в таблицу новую сгенерированную тянку</summary>
        private void button2_Click(object sender, EventArgs e)
        {
            FindAnimeChanEvent.Invoke();
            AnimeChanDTO animeChan = findChanDTO;
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
                label1.Font = new Font("Segoe UI", 5f * scaleFactor, FontStyle.Regular);
                label2.Font = new Font("Segoe UI", 5f * scaleFactor, FontStyle.Regular);
                label3.Font = new Font("Segoe UI", 5f * scaleFactor, FontStyle.Regular);
                label4.Font = new Font("Segoe UI", 5f * scaleFactor, FontStyle.Regular);
                label5.Font = new Font("Segoe UI", 5f * scaleFactor, FontStyle.Regular);
                label6.Font = new Font("Segoe UI", 5f * scaleFactor, FontStyle.Regular);
                lblAge.Font = new Font("Segoe UI", 5f * scaleFactor, FontStyle.Regular);
                lblFirstName.Font = new Font("Segoe UI", 5f * scaleFactor, FontStyle.Regular);
                lblHeight.Font = new Font("Segoe UI", 5f * scaleFactor, FontStyle.Regular);
                lblLstName.Font = new Font("Segoe UI", 5f * scaleFactor, FontStyle.Regular);
                lblSize.Font = new Font("Segoe UI", 5f * scaleFactor, FontStyle.Regular);
                lblWeight.Font = new Font("Segoe UI", 5f * scaleFactor, FontStyle.Regular);
            }
        }

        /// <summary>
        /// Событие загрузки формы
        /// </summary>
        /// <param name="sender">MainForm</param>
        /// <param name="e">Контейнер аргументов события</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            GetMainPersonEvent.Invoke();
            MainPersonDTO mainPerson = mainPersonDTO;
            this.lblFirstName.Text = mainPerson.FirstName;
            this.lblLstName.Text = mainPerson.LastName;
            this.lblAge.Text = mainPerson.Age.ToString();
            this.lblHeight.Text = mainPerson.Height.ToString();
            this.lblWeight.Text = mainPerson.Weight.ToString();
            this.lblSize.Text = mainPerson.Size.ToString();
        }

        public void LoadAnimeChanList(IEnumerable<AnimeChanDTO> list)
        {
            listChanDTO = list.ToList();
        }

        public void FindById(AnimeChanDTO chan)
        {
            findByIdChanDTO = chan;
        }

        public void LoadId(int id)
        {
            loadId = id;
        }

        public void FilterAnimeChanList(List<AnimeChanDTO> chans)
        {
            filterListChanDTO = chans;
        }

        public void FindAnimeChan(AnimeChanDTO chan)
        {
            findChanDTO = chan;
        }

        public void GetMainPerson(MainPersonDTO main)
        {
            mainPersonDTO = main;
        }

        public void LoadAnimeChanList(List<AnimeChanDTO> list)
        {
            listChanDTO = list;
        }
    }
}

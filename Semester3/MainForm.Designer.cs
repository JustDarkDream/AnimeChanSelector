namespace ViewForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            label1 = new Label();
            showCard = new Button();
            createChan = new Button();
            deleteChan = new Button();
            SettingChan = new Button();
            filter = new Button();
            button1 = new Button();
            findChan = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(82, 128);
            dataGridView1.Margin = new Padding(5, 6, 5, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 72;
            dataGridView1.Size = new Size(1176, 544);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(432, 18);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(460, 84);
            label1.TabIndex = 1;
            label1.Text = "Таблица с тянками";
            // 
            // showCard
            // 
            showCard.FlatStyle = FlatStyle.Flat;
            showCard.Font = new Font("Segoe UI", 14F);
            showCard.Location = new Point(82, 954);
            showCard.Margin = new Padding(5, 6, 5, 6);
            showCard.Name = "showCard";
            showCard.Size = new Size(237, 136);
            showCard.TabIndex = 2;
            showCard.Text = "Показать Тян";
            showCard.UseVisualStyleBackColor = true;
            showCard.Click += button1_Click;
            // 
            // createChan
            // 
            createChan.FlatStyle = FlatStyle.Flat;
            createChan.Font = new Font("Segoe UI", 14F);
            createChan.Location = new Point(82, 740);
            createChan.Margin = new Padding(5, 6, 5, 6);
            createChan.Name = "createChan";
            createChan.Size = new Size(237, 136);
            createChan.TabIndex = 3;
            createChan.Text = "Создать Тян";
            createChan.UseVisualStyleBackColor = true;
            createChan.Click += createChan_Click;
            // 
            // deleteChan
            // 
            deleteChan.FlatStyle = FlatStyle.Flat;
            deleteChan.Font = new Font("Segoe UI", 14F);
            deleteChan.Location = new Point(993, 740);
            deleteChan.Margin = new Padding(5, 6, 5, 6);
            deleteChan.Name = "deleteChan";
            deleteChan.Size = new Size(266, 136);
            deleteChan.TabIndex = 4;
            deleteChan.Text = "Удалить Тян";
            deleteChan.UseVisualStyleBackColor = true;
            deleteChan.Click += deleteChan_Click;
            // 
            // SettingChan
            // 
            SettingChan.FlatStyle = FlatStyle.Flat;
            SettingChan.Font = new Font("Segoe UI", 14F);
            SettingChan.Location = new Point(681, 740);
            SettingChan.Margin = new Padding(5, 6, 5, 6);
            SettingChan.Name = "SettingChan";
            SettingChan.Size = new Size(278, 136);
            SettingChan.TabIndex = 5;
            SettingChan.Text = "Редактировать Тян";
            SettingChan.UseVisualStyleBackColor = true;
            SettingChan.Click += SettingChan_Click;
            // 
            // filter
            // 
            filter.FlatStyle = FlatStyle.Flat;
            filter.Font = new Font("Segoe UI", 14F);
            filter.Location = new Point(365, 954);
            filter.Margin = new Padding(5, 6, 5, 6);
            filter.Name = "filter";
            filter.Size = new Size(593, 136);
            filter.TabIndex = 6;
            filter.Text = "Отфильтровать";
            filter.UseVisualStyleBackColor = true;
            filter.Click += filter_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(993, 954);
            button1.Margin = new Padding(5, 6, 5, 6);
            button1.Name = "button1";
            button1.Size = new Size(266, 136);
            button1.TabIndex = 7;
            button1.Text = "Убрать фильтр";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // findChan
            // 
            findChan.FlatStyle = FlatStyle.Flat;
            findChan.Font = new Font("Segoe UI", 14F);
            findChan.Location = new Point(365, 740);
            findChan.Margin = new Padding(5, 6, 5, 6);
            findChan.Name = "findChan";
            findChan.Size = new Size(285, 136);
            findChan.TabIndex = 8;
            findChan.Text = "Найти Тян";
            findChan.UseVisualStyleBackColor = true;
            findChan.Click += button2_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1114);
            Controls.Add(findChan);
            Controls.Add(button1);
            Controls.Add(filter);
            Controls.Add(SettingChan);
            Controls.Add(deleteChan);
            Controls.Add(createChan);
            Controls.Add(showCard);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "MainForm";
            Text = "Подбор тянки";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button showCard;
        private Button createChan;
        private Button deleteChan;
        private Button SettingChan;
        private Button filter;
        private Button button1;
        private Button findChan;
    }
}

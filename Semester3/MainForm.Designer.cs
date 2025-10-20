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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            dgwTabel = new DataGridView();
            lblName = new Label();
            btncreateChan = new Button();
            btndeleteChan = new Button();
            btnSettingChan = new Button();
            btnfindChan = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            btnfilter = new Button();
            btnshowCard = new Button();
            btnFilterOff = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgwTabel).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // dgwTabel
            // 
            dgwTabel.AllowUserToAddRows = false;
            dgwTabel.AllowUserToDeleteRows = false;
            dgwTabel.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgwTabel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwTabel.Dock = DockStyle.Fill;
            dgwTabel.Location = new Point(5, 109);
            dgwTabel.Margin = new Padding(5, 6, 5, 6);
            dgwTabel.Name = "dgwTabel";
            dgwTabel.ReadOnly = true;
            dgwTabel.RowHeadersWidth = 72;
            dgwTabel.Size = new Size(1355, 507);
            dgwTabel.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Top;
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 20F);
            lblName.Location = new Point(466, 0);
            lblName.Margin = new Padding(5, 0, 5, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(432, 62);
            lblName.TabIndex = 1;
            lblName.Text = "Таблица с тянками";
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btncreateChan
            // 
            btncreateChan.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btncreateChan.Dock = DockStyle.Fill;
            btncreateChan.FlatStyle = FlatStyle.Flat;
            btncreateChan.Font = new Font("Segoe UI", 14F);
            btncreateChan.Location = new Point(683, 6);
            btncreateChan.Margin = new Padding(5, 6, 5, 6);
            btncreateChan.Name = "btncreateChan";
            btncreateChan.Size = new Size(329, 230);
            btncreateChan.TabIndex = 2;
            btncreateChan.Text = "Создать Тян";
            btncreateChan.UseVisualStyleBackColor = true;
            btncreateChan.Click += btnCreateChan_Click;
            // 
            // btndeleteChan
            // 
            btndeleteChan.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btndeleteChan.BackgroundImage = Properties.Resources.image3;
            btndeleteChan.BackgroundImageLayout = ImageLayout.Stretch;
            btndeleteChan.Dock = DockStyle.Fill;
            btndeleteChan.FlatStyle = FlatStyle.Flat;
            btndeleteChan.Font = new Font("Segoe UI", 14F);
            btndeleteChan.Location = new Point(5, 6);
            btndeleteChan.Margin = new Padding(5, 6, 5, 6);
            btndeleteChan.Name = "btndeleteChan";
            btndeleteChan.Size = new Size(329, 230);
            btndeleteChan.TabIndex = 3;
            btndeleteChan.Text = "Удалить Тян";
            btndeleteChan.UseVisualStyleBackColor = true;
            btndeleteChan.Click += btnDeleteChan_Click;
            // 
            // btnSettingChan
            // 
            btnSettingChan.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSettingChan.Dock = DockStyle.Fill;
            btnSettingChan.FlatStyle = FlatStyle.Flat;
            btnSettingChan.Font = new Font("Segoe UI", 14F);
            btnSettingChan.Location = new Point(344, 6);
            btnSettingChan.Margin = new Padding(5, 6, 5, 6);
            btnSettingChan.Name = "btnSettingChan";
            btnSettingChan.Size = new Size(329, 230);
            btnSettingChan.TabIndex = 4;
            btnSettingChan.Text = "Редактировать Тян";
            btnSettingChan.UseVisualStyleBackColor = true;
            btnSettingChan.Click += btnSettingChan_Click;
            // 
            // btnfindChan
            // 
            btnfindChan.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnfindChan.Dock = DockStyle.Fill;
            btnfindChan.FlatStyle = FlatStyle.Flat;
            btnfindChan.Font = new Font("Segoe UI", 14F);
            btnfindChan.Location = new Point(1022, 6);
            btnfindChan.Margin = new Padding(5, 6, 5, 6);
            btnfindChan.Name = "btnfindChan";
            btnfindChan.Size = new Size(332, 230);
            btnfindChan.TabIndex = 1;
            btnfindChan.Text = "Найти Тян";
            btnfindChan.UseVisualStyleBackColor = true;
            btnfindChan.Click += button2_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 56.37343F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 43.62657F));
            tableLayoutPanel1.Size = new Size(1371, 1114);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel5, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 631);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 51.6666679F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 48.3333321F));
            tableLayoutPanel2.Size = new Size(1365, 480);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.AutoSize = true;
            tableLayoutPanel4.ColumnCount = 4;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.Controls.Add(btndeleteChan, 0, 0);
            tableLayoutPanel4.Controls.Add(btnSettingChan, 1, 0);
            tableLayoutPanel4.Controls.Add(btncreateChan, 2, 0);
            tableLayoutPanel4.Controls.Add(btnfindChan, 3, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(1359, 242);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.Controls.Add(btnfilter, 0, 0);
            tableLayoutPanel5.Controls.Add(btnshowCard, 1, 0);
            tableLayoutPanel5.Controls.Add(btnFilterOff, 2, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 251);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(1359, 226);
            tableLayoutPanel5.TabIndex = 3;
            // 
            // btnfilter
            // 
            btnfilter.Dock = DockStyle.Fill;
            btnfilter.FlatStyle = FlatStyle.Flat;
            btnfilter.Font = new Font("Segoe UI", 14F);
            btnfilter.Location = new Point(5, 6);
            btnfilter.Margin = new Padding(5, 6, 5, 6);
            btnfilter.Name = "btnfilter";
            btnfilter.Size = new Size(443, 214);
            btnfilter.TabIndex = 9;
            btnfilter.Text = "Отфильтровать";
            btnfilter.UseVisualStyleBackColor = true;
            btnfilter.Click += btnfilter_Click;
            // 
            // btnshowCard
            // 
            btnshowCard.Dock = DockStyle.Fill;
            btnshowCard.FlatStyle = FlatStyle.Flat;
            btnshowCard.Font = new Font("Segoe UI", 14F);
            btnshowCard.Location = new Point(458, 6);
            btnshowCard.Margin = new Padding(5, 6, 5, 6);
            btnshowCard.Name = "btnshowCard";
            btnshowCard.Size = new Size(443, 214);
            btnshowCard.TabIndex = 8;
            btnshowCard.Text = "Показать Тян";
            btnshowCard.UseVisualStyleBackColor = true;
            btnshowCard.Click += btnshowcard_Click;
            // 
            // btnFilterOff
            // 
            btnFilterOff.Dock = DockStyle.Fill;
            btnFilterOff.FlatStyle = FlatStyle.Flat;
            btnFilterOff.Font = new Font("Segoe UI", 14F);
            btnFilterOff.Location = new Point(911, 6);
            btnFilterOff.Margin = new Padding(5, 6, 5, 6);
            btnFilterOff.Name = "btnFilterOff";
            btnFilterOff.Size = new Size(443, 214);
            btnFilterOff.TabIndex = 10;
            btnFilterOff.Text = "Убрать фильтр";
            btnFilterOff.UseVisualStyleBackColor = true;
            btnFilterOff.Click += btnFilterOff_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(dgwTabel, 0, 1);
            tableLayoutPanel3.Controls.Add(lblName, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 16.5594864F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 83.44051F));
            tableLayoutPanel3.Size = new Size(1365, 622);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1114);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            MinimumSize = new Size(500, 500);
            Name = "MainForm";
            Text = "Подбор тянки";
            Load += MainForm_Load;
            SizeChanged += MainForm_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)dgwTabel).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwTabel;
        private Label lblName;
        private Button btncreateChan;
        private Button btndeleteChan;
        private Button btnSettingChan;
        private Button btnfindChan;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private Button btnfilter;
        private Button btnshowCard;
        private Button btnFilterOff;
    }
}

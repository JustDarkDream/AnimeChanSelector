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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            dgwTabel = new DataGridView();
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
            tableLayoutPanel6 = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel8 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            lblFirstName = new Label();
            lblLstName = new Label();
            lblAge = new Label();
            lblHeight = new Label();
            lblWeight = new Label();
            lblSize = new Label();
            lblName = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)dgwTabel).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel8.SuspendLayout();
            SuspendLayout();
            // 
            // dgwTabel
            // 
            dgwTabel.AllowUserToAddRows = false;
            dgwTabel.AllowUserToDeleteRows = false;
            dgwTabel.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgwTabel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwTabel.Dock = DockStyle.Fill;
            dgwTabel.Location = new Point(5, 264);
            dgwTabel.Margin = new Padding(5, 6, 5, 6);
            dgwTabel.Name = "dgwTabel";
            dgwTabel.ReadOnly = true;
            dgwTabel.RowHeadersWidth = 72;
            dgwTabel.Size = new Size(1355, 501);
            dgwTabel.TabIndex = 0;
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
            btncreateChan.Size = new Size(329, 153);
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
            btndeleteChan.Size = new Size(329, 153);
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
            btnSettingChan.Size = new Size(329, 153);
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
            btnfindChan.Size = new Size(332, 153);
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
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 69.74866F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30.2513466F));
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
            tableLayoutPanel2.Location = new Point(3, 780);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 51.6666679F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 48.3333321F));
            tableLayoutPanel2.Size = new Size(1365, 331);
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
            tableLayoutPanel4.Size = new Size(1359, 165);
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
            tableLayoutPanel5.Location = new Point(3, 174);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(1359, 154);
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
            btnfilter.Size = new Size(443, 142);
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
            btnshowCard.Size = new Size(443, 142);
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
            btnFilterOff.Size = new Size(443, 142);
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
            tableLayoutPanel3.Controls.Add(tableLayoutPanel6, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.4630356F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 66.5369644F));
            tableLayoutPanel3.Size = new Size(1365, 771);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.4878578F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.5121422F));
            tableLayoutPanel6.Controls.Add(tableLayoutPanel7, 1, 0);
            tableLayoutPanel6.Controls.Add(lblName, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(1359, 252);
            tableLayoutPanel6.TabIndex = 1;
            tableLayoutPanel6.Paint += tableLayoutPanel6_Paint;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.2834663F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.71654F));
            tableLayoutPanel7.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel7.Controls.Add(tableLayoutPanel8, 1, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(594, 3);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(762, 246);
            tableLayoutPanel7.TabIndex = 3;
            tableLayoutPanel7.Paint += tableLayoutPanel7_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources.McLovin;
            pictureBox1.Location = new Point(5, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(238, 236);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel8.Controls.Add(label1, 0, 0);
            tableLayoutPanel8.Controls.Add(label2, 0, 1);
            tableLayoutPanel8.Controls.Add(label3, 0, 2);
            tableLayoutPanel8.Controls.Add(label4, 0, 3);
            tableLayoutPanel8.Controls.Add(label5, 0, 4);
            tableLayoutPanel8.Controls.Add(label6, 0, 5);
            tableLayoutPanel8.Controls.Add(lblFirstName, 1, 0);
            tableLayoutPanel8.Controls.Add(lblLstName, 1, 1);
            tableLayoutPanel8.Controls.Add(lblAge, 1, 2);
            tableLayoutPanel8.Controls.Add(lblHeight, 1, 3);
            tableLayoutPanel8.Controls.Add(lblWeight, 1, 4);
            tableLayoutPanel8.Controls.Add(lblSize, 1, 5);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(251, 5);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 6;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel8.Size = new Size(506, 236);
            tableLayoutPanel8.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 39);
            label1.TabIndex = 0;
            label1.Text = "Имя";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 39);
            label2.Name = "label2";
            label2.Size = new Size(100, 39);
            label2.TabIndex = 1;
            label2.Text = "Фамилия";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 78);
            label3.Name = "label3";
            label3.Size = new Size(100, 39);
            label3.TabIndex = 2;
            label3.Text = "Возраст";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 117);
            label4.Name = "label4";
            label4.Size = new Size(100, 39);
            label4.TabIndex = 3;
            label4.Text = "Рост";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 156);
            label5.Name = "label5";
            label5.Size = new Size(100, 39);
            label5.TabIndex = 4;
            label5.Text = "Вес";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 195);
            label6.Name = "label6";
            label6.Size = new Size(100, 41);
            label6.TabIndex = 5;
            label6.Text = "Размер";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Dock = DockStyle.Fill;
            lblFirstName.Location = new Point(109, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(394, 39);
            lblFirstName.TabIndex = 6;
            lblFirstName.Text = "label7";
            lblFirstName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLstName
            // 
            lblLstName.AutoSize = true;
            lblLstName.Dock = DockStyle.Fill;
            lblLstName.Location = new Point(109, 39);
            lblLstName.Name = "lblLstName";
            lblLstName.Size = new Size(394, 39);
            lblLstName.TabIndex = 7;
            lblLstName.Text = "label8";
            lblLstName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Dock = DockStyle.Fill;
            lblAge.Location = new Point(109, 78);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(394, 39);
            lblAge.TabIndex = 8;
            lblAge.Text = "label9";
            lblAge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Dock = DockStyle.Fill;
            lblHeight.Location = new Point(109, 117);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(394, 39);
            lblHeight.TabIndex = 9;
            lblHeight.Text = "label10";
            lblHeight.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Dock = DockStyle.Fill;
            lblWeight.Location = new Point(109, 156);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(394, 39);
            lblWeight.TabIndex = 10;
            lblWeight.Text = "label11";
            lblWeight.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Dock = DockStyle.Fill;
            lblSize.Location = new Point(109, 195);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(394, 41);
            lblSize.TabIndex = 11;
            lblSize.Text = "label12";
            lblSize.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 20F);
            lblName.Location = new Point(5, 190);
            lblName.Margin = new Padding(5, 0, 5, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(432, 62);
            lblName.TabIndex = 2;
            lblName.Text = "Таблица с тянками";
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(28, 28);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
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
            StartPosition = FormStartPosition.CenterScreen;
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
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwTabel;
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
        private TableLayoutPanel tableLayoutPanel6;
        private Label lblName;
        private TableLayoutPanel tableLayoutPanel7;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblFirstName;
        private Label lblLstName;
        private Label lblAge;
        private Label lblHeight;
        private Label lblWeight;
        private Label lblSize;
        private ContextMenuStrip contextMenuStrip1;
    }
}

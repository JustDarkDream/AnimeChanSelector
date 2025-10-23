namespace ViewForms
{
    partial class AnimeChanCard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            firstName = new TextBox();
            label2 = new Label();
            characteristics = new Label();
            label1 = new Label();
            listView1 = new ListView();
            addChan = new Button();
            ageValue = new TextBox();
            heightValue = new TextBox();
            weightValue = new TextBox();
            sizeValue = new TextBox();
            skillsSettung = new Button();
            lastName = new TextBox();
            saveChanges = new Button();
            label3 = new Label();
            chooseHer = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // firstName
            // 
            firstName.Font = new Font("Segoe UI", 15F);
            firstName.Location = new Point(21, 106);
            firstName.Margin = new Padding(5, 6, 5, 6);
            firstName.MaxLength = 20;
            firstName.Name = "firstName";
            firstName.Size = new Size(842, 54);
            firstName.TabIndex = 0;
            firstName.Text = "label1";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(10, 278);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(845, 82);
            label2.TabIndex = 1;
            label2.Text = "Данные";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // characteristics
            // 
            characteristics.Font = new Font("Segoe UI", 12F);
            characteristics.Location = new Point(10, 334);
            characteristics.Margin = new Padding(5, 0, 5, 0);
            characteristics.Name = "characteristics";
            characteristics.Size = new Size(153, 358);
            characteristics.TabIndex = 2;
            characteristics.Text = "Возраст:\r\n\r\nРост:\r\n\r\nВес:\r\n\r\nРазмер:";
            characteristics.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(17, 674);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(845, 90);
            label1.TabIndex = 3;
            label1.Text = "Навыки";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            listView1.Location = new Point(5, 6);
            listView1.Margin = new Padding(5, 6, 5, 6);
            listView1.Name = "listView1";
            listView1.Size = new Size(839, 216);
            listView1.TabIndex = 6;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // addChan
            // 
            addChan.Font = new Font("Segoe UI", 15F);
            addChan.Location = new Point(17, 1190);
            addChan.Margin = new Padding(5, 6, 5, 6);
            addChan.Name = "addChan";
            addChan.Size = new Size(845, 150);
            addChan.TabIndex = 5;
            addChan.Text = "Добавить Тян";
            addChan.UseVisualStyleBackColor = true;
            addChan.Click += addChan_Click;
            // 
            // ageValue
            // 
            ageValue.Font = new Font("Segoe UI", 12F);
            ageValue.Location = new Point(130, 384);
            ageValue.Margin = new Padding(5, 6, 5, 6);
            ageValue.MaxLength = 4;
            ageValue.Name = "ageValue";
            ageValue.Size = new Size(707, 45);
            ageValue.TabIndex = 2;
            ageValue.Text = "0";
            // 
            // heightValue
            // 
            heightValue.Font = new Font("Segoe UI", 12F);
            heightValue.Location = new Point(130, 462);
            heightValue.Margin = new Padding(5, 6, 5, 6);
            heightValue.MaxLength = 4;
            heightValue.Name = "heightValue";
            heightValue.Size = new Size(707, 45);
            heightValue.TabIndex = 3;
            heightValue.Text = "0";
            // 
            // weightValue
            // 
            weightValue.Font = new Font("Segoe UI", 12F);
            weightValue.Location = new Point(130, 538);
            weightValue.Margin = new Padding(5, 6, 5, 6);
            weightValue.MaxLength = 4;
            weightValue.Name = "weightValue";
            weightValue.Size = new Size(707, 45);
            weightValue.TabIndex = 4;
            weightValue.Text = "0";
            // 
            // sizeValue
            // 
            sizeValue.Font = new Font("Segoe UI", 12F);
            sizeValue.Location = new Point(130, 612);
            sizeValue.Margin = new Padding(5, 6, 5, 6);
            sizeValue.MaxLength = 4;
            sizeValue.Name = "sizeValue";
            sizeValue.Size = new Size(707, 45);
            sizeValue.TabIndex = 5;
            sizeValue.Text = "0";
            // 
            // skillsSettung
            // 
            skillsSettung.Dock = DockStyle.Top;
            skillsSettung.Font = new Font("Segoe UI", 15F);
            skillsSettung.Location = new Point(5, 238);
            skillsSettung.Margin = new Padding(5, 6, 5, 6);
            skillsSettung.Name = "skillsSettung";
            skillsSettung.Size = new Size(842, 78);
            skillsSettung.TabIndex = 7;
            skillsSettung.Text = "Редактировать навыки";
            skillsSettung.TextAlign = ContentAlignment.BottomCenter;
            skillsSettung.UseVisualStyleBackColor = true;
            skillsSettung.Click += skillsSettung_Click;
            // 
            // lastName
            // 
            lastName.Font = new Font("Segoe UI", 15F);
            lastName.Location = new Point(21, 186);
            lastName.Margin = new Padding(5, 6, 5, 6);
            lastName.MaxLength = 20;
            lastName.Name = "lastName";
            lastName.Size = new Size(842, 54);
            lastName.TabIndex = 1;
            lastName.Text = "label1";
            // 
            // saveChanges
            // 
            saveChanges.Font = new Font("Segoe UI", 15F);
            saveChanges.Location = new Point(17, 1190);
            saveChanges.Margin = new Padding(5, 6, 5, 6);
            saveChanges.Name = "saveChanges";
            saveChanges.Size = new Size(845, 150);
            saveChanges.TabIndex = 12;
            saveChanges.Text = "Сохранить изменения";
            saveChanges.UseVisualStyleBackColor = true;
            saveChanges.Click += saveChanges_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(21, 18);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(845, 82);
            label3.TabIndex = 22;
            label3.Text = "Имя-Фамилия";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chooseHer
            // 
            chooseHer.Font = new Font("Segoe UI", 15F);
            chooseHer.Location = new Point(14, 1130);
            chooseHer.Margin = new Padding(5, 6, 5, 6);
            chooseHer.Name = "chooseHer";
            chooseHer.Size = new Size(845, 150);
            chooseHer.TabIndex = 23;
            chooseHer.Text = "Выбрать её";
            chooseHer.UseVisualStyleBackColor = true;
            chooseHer.Click += chooseHer_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(skillsSettung, 0, 1);
            tableLayoutPanel1.Controls.Add(listView1, 0, 0);
            tableLayoutPanel1.Location = new Point(10, 770);
            tableLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(852, 348);
            tableLayoutPanel1.TabIndex = 24;
            // 
            // AnimeChanCard
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 1340);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(chooseHer);
            Controls.Add(label3);
            Controls.Add(saveChanges);
            Controls.Add(lastName);
            Controls.Add(sizeValue);
            Controls.Add(weightValue);
            Controls.Add(heightValue);
            Controls.Add(ageValue);
            Controls.Add(addChan);
            Controls.Add(label1);
            Controls.Add(characteristics);
            Controls.Add(label2);
            Controls.Add(firstName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(5, 6, 5, 6);
            Name = "AnimeChanCard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AnimeChanCard";
            Load += AnimeChanCard_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox firstName;
        private Label label2;
        private Label characteristics;
        private Label label1;
        private ListView listView1;
        private Button addChan;
        private TextBox ageValue;
        private TextBox heightValue;
        private TextBox weightValue;
        private TextBox sizeValue;
        private Button skillsSettung;
        private TextBox lastName;
        private Button saveChanges;
        private Label label3;
        private Button chooseHer;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
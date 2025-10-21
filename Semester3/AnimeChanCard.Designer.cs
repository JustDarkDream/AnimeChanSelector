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
            firstName.Location = new Point(12, 53);
            firstName.Name = "firstName";
            firstName.Size = new Size(493, 34);
            firstName.TabIndex = 0;
            firstName.Text = "label1";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(8, 170);
            label2.Name = "label2";
            label2.Size = new Size(493, 41);
            label2.TabIndex = 1;
            label2.Text = "Данные";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // characteristics
            // 
            characteristics.Font = new Font("Segoe UI", 12F);
            characteristics.Location = new Point(8, 198);
            characteristics.Name = "characteristics";
            characteristics.Size = new Size(89, 179);
            characteristics.TabIndex = 2;
            characteristics.Text = "Возраст:\r\n\r\nРост:\r\n\r\nВес:\r\n\r\nРазмер:";
            characteristics.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(12, 368);
            label1.Name = "label1";
            label1.Size = new Size(493, 45);
            label1.TabIndex = 3;
            label1.Text = "Навыки";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            listView1.Location = new Point(3, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(491, 110);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            // 
            // addChan
            // 
            addChan.Font = new Font("Segoe UI", 15F);
            addChan.Location = new Point(12, 626);
            addChan.Name = "addChan";
            addChan.Size = new Size(493, 75);
            addChan.TabIndex = 5;
            addChan.Text = "Добавить Тян";
            addChan.UseVisualStyleBackColor = true;
            addChan.Click += addChan_Click;
            // 
            // ageValue
            // 
            ageValue.Font = new Font("Segoe UI", 12F);
            ageValue.Location = new Point(79, 223);
            ageValue.Name = "ageValue";
            ageValue.Size = new Size(414, 29);
            ageValue.TabIndex = 6;
            ageValue.Text = "0";
            // 
            // heightValue
            // 
            heightValue.Font = new Font("Segoe UI", 12F);
            heightValue.Location = new Point(79, 262);
            heightValue.Name = "heightValue";
            heightValue.Size = new Size(414, 29);
            heightValue.TabIndex = 7;
            heightValue.Text = "0";
            // 
            // weightValue
            // 
            weightValue.Font = new Font("Segoe UI", 12F);
            weightValue.Location = new Point(79, 300);
            weightValue.Name = "weightValue";
            weightValue.Size = new Size(414, 29);
            weightValue.TabIndex = 8;
            weightValue.Text = "0";
            // 
            // sizeValue
            // 
            sizeValue.Font = new Font("Segoe UI", 12F);
            sizeValue.Location = new Point(79, 337);
            sizeValue.Name = "sizeValue";
            sizeValue.Size = new Size(414, 29);
            sizeValue.TabIndex = 9;
            sizeValue.Text = "0";
            // 
            // skillsSettung
            // 
            skillsSettung.Dock = DockStyle.Top;
            skillsSettung.Font = new Font("Segoe UI", 15F);
            skillsSettung.Location = new Point(3, 119);
            skillsSettung.Name = "skillsSettung";
            skillsSettung.Size = new Size(491, 39);
            skillsSettung.TabIndex = 10;
            skillsSettung.Text = "Редактировать навыки";
            skillsSettung.TextAlign = ContentAlignment.BottomCenter;
            skillsSettung.UseVisualStyleBackColor = true;
            skillsSettung.Click += skillsSettung_Click;
            // 
            // lastName
            // 
            lastName.Font = new Font("Segoe UI", 15F);
            lastName.Location = new Point(12, 93);
            lastName.Name = "lastName";
            lastName.Size = new Size(493, 34);
            lastName.TabIndex = 11;
            lastName.Text = "label1";
            // 
            // saveChanges
            // 
            saveChanges.Font = new Font("Segoe UI", 15F);
            saveChanges.Location = new Point(12, 626);
            saveChanges.Name = "saveChanges";
            saveChanges.Size = new Size(493, 75);
            saveChanges.TabIndex = 12;
            saveChanges.Text = "Сохранить изменения";
            saveChanges.UseVisualStyleBackColor = true;
            saveChanges.Click += saveChanges_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(493, 41);
            label3.TabIndex = 22;
            label3.Text = "Имя-Фамилия";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chooseHer
            // 
            chooseHer.Font = new Font("Segoe UI", 15F);
            chooseHer.Location = new Point(12, 627);
            chooseHer.Name = "chooseHer";
            chooseHer.Size = new Size(493, 75);
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
            tableLayoutPanel1.Controls.Add(listView1, 0, 0);
            tableLayoutPanel1.Controls.Add(skillsSettung, 0, 1);
            tableLayoutPanel1.Location = new Point(8, 416);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(497, 174);
            tableLayoutPanel1.TabIndex = 24;
            // 
            // AnimeChanCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 743);
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
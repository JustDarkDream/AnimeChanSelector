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
            SuspendLayout();
            // 
            // firstName
            // 
            firstName.Font = new Font("Segoe UI", 15F);
            firstName.Location = new Point(21, 106);
            firstName.Margin = new Padding(5, 6, 5, 6);
            firstName.Name = "firstName";
            firstName.Size = new Size(842, 54);
            firstName.TabIndex = 0;
            firstName.Text = "label1";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(14, 341);
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
            characteristics.Location = new Point(14, 396);
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
            label1.Location = new Point(21, 736);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(845, 90);
            label1.TabIndex = 3;
            label1.Text = "Навыки";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            listView1.Location = new Point(21, 832);
            listView1.Margin = new Padding(5, 6, 5, 6);
            listView1.Name = "listView1";
            listView1.Size = new Size(842, 254);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            // 
            // addChan
            // 
            addChan.Font = new Font("Segoe UI", 15F);
            addChan.Location = new Point(21, 1252);
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
            ageValue.Location = new Point(135, 446);
            ageValue.Margin = new Padding(5, 6, 5, 6);
            ageValue.Name = "ageValue";
            ageValue.Size = new Size(707, 45);
            ageValue.TabIndex = 6;
            ageValue.Text = "0";
            // 
            // heightValue
            // 
            heightValue.Font = new Font("Segoe UI", 12F);
            heightValue.Location = new Point(135, 524);
            heightValue.Margin = new Padding(5, 6, 5, 6);
            heightValue.Name = "heightValue";
            heightValue.Size = new Size(707, 45);
            heightValue.TabIndex = 7;
            heightValue.Text = "0";
            // 
            // weightValue
            // 
            weightValue.Font = new Font("Segoe UI", 12F);
            weightValue.Location = new Point(135, 601);
            weightValue.Margin = new Padding(5, 6, 5, 6);
            weightValue.Name = "weightValue";
            weightValue.Size = new Size(707, 45);
            weightValue.TabIndex = 8;
            weightValue.Text = "0";
            // 
            // sizeValue
            // 
            sizeValue.Font = new Font("Segoe UI", 12F);
            sizeValue.Location = new Point(135, 674);
            sizeValue.Margin = new Padding(5, 6, 5, 6);
            sizeValue.Name = "sizeValue";
            sizeValue.Size = new Size(707, 45);
            sizeValue.TabIndex = 9;
            sizeValue.Text = "0";
            // 
            // skillsSettung
            // 
            skillsSettung.Font = new Font("Segoe UI", 15F);
            skillsSettung.Location = new Point(230, 1102);
            skillsSettung.Margin = new Padding(5, 6, 5, 6);
            skillsSettung.Name = "skillsSettung";
            skillsSettung.Size = new Size(415, 80);
            skillsSettung.TabIndex = 10;
            skillsSettung.Text = "Редактировать навыки";
            skillsSettung.UseVisualStyleBackColor = true;
            skillsSettung.Click += skillsSettung_Click;
            // 
            // lastName
            // 
            lastName.Font = new Font("Segoe UI", 15F);
            lastName.Location = new Point(21, 186);
            lastName.Margin = new Padding(5, 6, 5, 6);
            lastName.Name = "lastName";
            lastName.Size = new Size(842, 54);
            lastName.TabIndex = 11;
            lastName.Text = "label1";
            // 
            // saveChanges
            // 
            saveChanges.Font = new Font("Segoe UI", 15F);
            saveChanges.Location = new Point(21, 1252);
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
            chooseHer.Location = new Point(21, 1254);
            chooseHer.Margin = new Padding(5, 6, 5, 6);
            chooseHer.Name = "chooseHer";
            chooseHer.Size = new Size(845, 150);
            chooseHer.TabIndex = 23;
            chooseHer.Text = "Выбрать её";
            chooseHer.UseVisualStyleBackColor = true;
            chooseHer.Click += chooseHer_Click;
            // 
            // AnimeChanCard
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 1428);
            Controls.Add(chooseHer);
            Controls.Add(label3);
            Controls.Add(saveChanges);
            Controls.Add(lastName);
            Controls.Add(skillsSettung);
            Controls.Add(sizeValue);
            Controls.Add(weightValue);
            Controls.Add(heightValue);
            Controls.Add(ageValue);
            Controls.Add(addChan);
            Controls.Add(listView1);
            Controls.Add(label1);
            Controls.Add(characteristics);
            Controls.Add(label2);
            Controls.Add(firstName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(5, 6, 5, 6);
            Name = "AnimeChanCard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AnimeChanCard";
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
    }
}
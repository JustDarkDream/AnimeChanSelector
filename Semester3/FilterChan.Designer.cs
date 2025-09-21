namespace ViewForms
{
    partial class FilterChan
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
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            ageFrom = new TextBox();
            label5 = new Label();
            label6 = new Label();
            ageTo = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            heightFrom = new TextBox();
            weightFrom = new TextBox();
            sizeFrom = new TextBox();
            heightTo = new TextBox();
            weightTo = new TextBox();
            sizeTo = new TextBox();
            saveFilter = new Button();
            label13 = new Label();
            listView1 = new ListView();
            checkBox1 = new CheckBox();
            skillsSettung = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 15F);
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(2, 13);
            label2.Name = "label2";
            label2.Size = new Size(123, 41);
            label2.TabIndex = 2;
            label2.Text = "Возраст:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(2, 54);
            label1.Name = "label1";
            label1.Size = new Size(123, 41);
            label1.TabIndex = 3;
            label1.Text = "Рост:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(2, 95);
            label3.Name = "label3";
            label3.Size = new Size(123, 41);
            label3.TabIndex = 4;
            label3.Text = "Вес:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(2, 136);
            label4.Name = "label4";
            label4.Size = new Size(123, 41);
            label4.TabIndex = 5;
            label4.Text = "Размер:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ageFrom
            // 
            ageFrom.Font = new Font("Segoe UI", 12F);
            ageFrom.Location = new Point(186, 22);
            ageFrom.Name = "ageFrom";
            ageFrom.Size = new Size(174, 29);
            ageFrom.TabIndex = 7;
            ageFrom.Text = "0";
            ageFrom.TextChanged += ageValue_TextChanged;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(131, 13);
            label5.Name = "label5";
            label5.Size = new Size(49, 41);
            label5.TabIndex = 8;
            label5.Text = "От";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(374, 13);
            label6.Name = "label6";
            label6.Size = new Size(49, 41);
            label6.TabIndex = 9;
            label6.Text = "До";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ageTo
            // 
            ageTo.Font = new Font("Segoe UI", 12F);
            ageTo.Location = new Point(429, 22);
            ageTo.Name = "ageTo";
            ageTo.Size = new Size(174, 29);
            ageTo.TabIndex = 10;
            ageTo.Text = "0";
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 15F);
            label7.Location = new Point(131, 54);
            label7.Name = "label7";
            label7.Size = new Size(49, 41);
            label7.TabIndex = 11;
            label7.Text = "От";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 15F);
            label8.Location = new Point(131, 95);
            label8.Name = "label8";
            label8.Size = new Size(49, 41);
            label8.TabIndex = 12;
            label8.Text = "От";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 15F);
            label9.Location = new Point(131, 136);
            label9.Name = "label9";
            label9.Size = new Size(49, 41);
            label9.TabIndex = 13;
            label9.Text = "От";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 15F);
            label10.Location = new Point(374, 54);
            label10.Name = "label10";
            label10.Size = new Size(49, 41);
            label10.TabIndex = 14;
            label10.Text = "До";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 15F);
            label11.Location = new Point(374, 95);
            label11.Name = "label11";
            label11.Size = new Size(49, 41);
            label11.TabIndex = 15;
            label11.Text = "До";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.Font = new Font("Segoe UI", 15F);
            label12.Location = new Point(374, 136);
            label12.Name = "label12";
            label12.Size = new Size(49, 41);
            label12.TabIndex = 16;
            label12.Text = "До";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // heightFrom
            // 
            heightFrom.Font = new Font("Segoe UI", 12F);
            heightFrom.Location = new Point(186, 63);
            heightFrom.Name = "heightFrom";
            heightFrom.Size = new Size(174, 29);
            heightFrom.TabIndex = 17;
            heightFrom.Text = "0";
            // 
            // weightFrom
            // 
            weightFrom.Font = new Font("Segoe UI", 12F);
            weightFrom.Location = new Point(186, 107);
            weightFrom.Name = "weightFrom";
            weightFrom.Size = new Size(174, 29);
            weightFrom.TabIndex = 18;
            weightFrom.Text = "0";
            // 
            // sizeFrom
            // 
            sizeFrom.Font = new Font("Segoe UI", 12F);
            sizeFrom.Location = new Point(186, 148);
            sizeFrom.Name = "sizeFrom";
            sizeFrom.Size = new Size(174, 29);
            sizeFrom.TabIndex = 19;
            sizeFrom.Text = "0";
            // 
            // heightTo
            // 
            heightTo.Font = new Font("Segoe UI", 12F);
            heightTo.Location = new Point(429, 66);
            heightTo.Name = "heightTo";
            heightTo.Size = new Size(174, 29);
            heightTo.TabIndex = 20;
            heightTo.Text = "0";
            // 
            // weightTo
            // 
            weightTo.Font = new Font("Segoe UI", 12F);
            weightTo.Location = new Point(429, 107);
            weightTo.Name = "weightTo";
            weightTo.Size = new Size(174, 29);
            weightTo.TabIndex = 21;
            weightTo.Text = "0";
            // 
            // sizeTo
            // 
            sizeTo.Font = new Font("Segoe UI", 12F);
            sizeTo.Location = new Point(429, 148);
            sizeTo.Name = "sizeTo";
            sizeTo.Size = new Size(174, 29);
            sizeTo.TabIndex = 22;
            sizeTo.Text = "0";
            // 
            // saveFilter
            // 
            saveFilter.FlatStyle = FlatStyle.Flat;
            saveFilter.Font = new Font("Segoe UI", 14F);
            saveFilter.Location = new Point(165, 377);
            saveFilter.Name = "saveFilter";
            saveFilter.Size = new Size(285, 45);
            saveFilter.TabIndex = 23;
            saveFilter.Text = "Сохранить";
            saveFilter.UseVisualStyleBackColor = true;
            saveFilter.Click += saveFilter_Click;
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 15F);
            label13.Location = new Point(2, 199);
            label13.Name = "label13";
            label13.Size = new Size(123, 47);
            label13.TabIndex = 24;
            label13.Text = "Навыки:";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // listView1
            // 
            listView1.Location = new Point(131, 199);
            listView1.Name = "listView1";
            listView1.Size = new Size(472, 103);
            listView1.TabIndex = 25;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(2, 283);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(110, 19);
            checkBox1.TabIndex = 27;
            checkBox1.Text = "Учитывать всё?";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // skillsSettung
            // 
            skillsSettung.Font = new Font("Segoe UI", 15F);
            skillsSettung.Location = new Point(244, 308);
            skillsSettung.Name = "skillsSettung";
            skillsSettung.Size = new Size(242, 40);
            skillsSettung.TabIndex = 28;
            skillsSettung.Text = "Редактировать навыки";
            skillsSettung.UseVisualStyleBackColor = true;
            skillsSettung.Click += skillsSettung_Click;
            // 
            // FilterChan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 434);
            Controls.Add(skillsSettung);
            Controls.Add(checkBox1);
            Controls.Add(listView1);
            Controls.Add(label13);
            Controls.Add(saveFilter);
            Controls.Add(sizeTo);
            Controls.Add(weightTo);
            Controls.Add(heightTo);
            Controls.Add(sizeFrom);
            Controls.Add(weightFrom);
            Controls.Add(heightFrom);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(ageTo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(ageFrom);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "FilterChan";
            Text = "FilterChan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox ageFrom;
        private Label label5;
        private Label label6;
        private TextBox ageTo;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox heightFrom;
        private TextBox weightFrom;
        private TextBox sizeFrom;
        private TextBox heightTo;
        private TextBox weightTo;
        private TextBox sizeTo;
        private Button saveFilter;
        private Label label13;
        private ListView listView1;
        private CheckBox checkBox1;
        private Button skillsSettung;
    }
}
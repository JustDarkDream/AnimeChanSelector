namespace ViewForms
{
    partial class Registration
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
            label1 = new Label();
            lastName = new TextBox();
            sizeValue = new TextBox();
            weightValue = new TextBox();
            heightValue = new TextBox();
            ageValue = new TextBox();
            characteristics = new Label();
            label3 = new Label();
            firstName = new TextBox();
            label2 = new Label();
            registrate = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            btnAutoInput = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(204, 124);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(595, 114);
            label1.TabIndex = 7;
            label1.Text = "Регистрация";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lastName
            // 
            lastName.Font = new Font("Segoe UI", 15F);
            lastName.Location = new Point(93, 452);
            lastName.Margin = new Padding(5, 6, 5, 6);
            lastName.Name = "lastName";
            lastName.Size = new Size(842, 54);
            lastName.TabIndex = 1;
            lastName.Text = "label1";
            lastName.TextChanged += lastName_TextChanged;
            // 
            // sizeValue
            // 
            sizeValue.Font = new Font("Segoe UI", 12F);
            sizeValue.Location = new Point(192, 846);
            sizeValue.Margin = new Padding(5, 6, 5, 6);
            sizeValue.Name = "sizeValue";
            sizeValue.Size = new Size(707, 45);
            sizeValue.TabIndex = 5;
            sizeValue.Text = "0";
            // 
            // weightValue
            // 
            weightValue.Font = new Font("Segoe UI", 12F);
            weightValue.Location = new Point(192, 764);
            weightValue.Margin = new Padding(5, 6, 5, 6);
            weightValue.Name = "weightValue";
            weightValue.Size = new Size(707, 45);
            weightValue.TabIndex = 4;
            weightValue.Text = "0";
            // 
            // heightValue
            // 
            heightValue.Font = new Font("Segoe UI", 12F);
            heightValue.Location = new Point(192, 690);
            heightValue.Margin = new Padding(5, 6, 5, 6);
            heightValue.Name = "heightValue";
            heightValue.Size = new Size(707, 45);
            heightValue.TabIndex = 3;
            heightValue.Text = "0";
            // 
            // ageValue
            // 
            ageValue.Font = new Font("Segoe UI", 12F);
            ageValue.Location = new Point(204, 618);
            ageValue.Margin = new Padding(5, 6, 5, 6);
            ageValue.Name = "ageValue";
            ageValue.Size = new Size(707, 45);
            ageValue.TabIndex = 2;
            ageValue.Text = "0";
            // 
            // characteristics
            // 
            characteristics.Font = new Font("Segoe UI", 12F);
            characteristics.Location = new Point(77, 580);
            characteristics.Margin = new Padding(5, 0, 5, 0);
            characteristics.Name = "characteristics";
            characteristics.Size = new Size(153, 344);
            characteristics.TabIndex = 10;
            characteristics.Text = "Возраст:\r\n\r\nРост:\r\n\r\nВес:\r\n\r\nРазмер:";
            characteristics.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(93, 516);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(845, 82);
            label3.TabIndex = 9;
            label3.Text = "Данные";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // firstName
            // 
            firstName.Font = new Font("Segoe UI", 15F);
            firstName.Location = new Point(93, 372);
            firstName.Margin = new Padding(5, 6, 5, 6);
            firstName.Name = "firstName";
            firstName.Size = new Size(842, 54);
            firstName.TabIndex = 0;
            firstName.Text = "label1";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(93, 284);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(845, 82);
            label2.TabIndex = 8;
            label2.Text = "Имя-Фамилия";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // registrate
            // 
            registrate.Font = new Font("Segoe UI", 15F);
            registrate.Location = new Point(77, 1086);
            registrate.Margin = new Padding(5, 6, 5, 6);
            registrate.Name = "registrate";
            registrate.Size = new Size(845, 150);
            registrate.TabIndex = 6;
            registrate.Text = "Зарегистрироваться";
            registrate.UseVisualStyleBackColor = true;
            registrate.Click += saveChanges_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.imag1;
            pictureBox1.ImageLocation = "";
            pictureBox1.Location = new Point(711, 68);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(226, 236);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.image2;
            pictureBox2.Location = new Point(36, 68);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(219, 224);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // btnAutoInput
            // 
            btnAutoInput.Location = new Point(77, 927);
            btnAutoInput.Name = "btnAutoInput";
            btnAutoInput.Size = new Size(257, 52);
            btnAutoInput.TabIndex = 13;
            btnAutoInput.Text = "Ввести автоматически";
            btnAutoInput.UseVisualStyleBackColor = true;
            btnAutoInput.Click += btnAutoInput_Click;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(989, 1260);
            Controls.Add(btnAutoInput);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(registrate);
            Controls.Add(label2);
            Controls.Add(lastName);
            Controls.Add(sizeValue);
            Controls.Add(weightValue);
            Controls.Add(heightValue);
            Controls.Add(ageValue);
            Controls.Add(characteristics);
            Controls.Add(label3);
            Controls.Add(firstName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(5, 6, 5, 6);
            Name = "Registration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registration";
            Load += Registration_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox lastName;
        private TextBox sizeValue;
        private TextBox weightValue;
        private TextBox heightValue;
        private TextBox ageValue;
        private Label characteristics;
        private Label label3;
        private TextBox firstName;
        private Label label2;
        private Button registrate;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button btnAutoInput;
    }
}
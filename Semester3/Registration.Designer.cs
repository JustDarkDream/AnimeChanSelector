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
            label1.Location = new Point(119, 62);
            label1.Name = "label1";
            label1.Size = new Size(347, 57);
            label1.TabIndex = 7;
            label1.Text = "Регистрация";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lastName
            // 
            lastName.Font = new Font("Segoe UI", 15F);
            lastName.Location = new Point(54, 226);
            lastName.MaxLength = 20;
            lastName.Name = "lastName";
            lastName.Size = new Size(493, 34);
            lastName.TabIndex = 1;
            lastName.Text = "label1";
            lastName.TextChanged += lastName_TextChanged;
            // 
            // sizeValue
            // 
            sizeValue.Font = new Font("Segoe UI", 12F);
            sizeValue.Location = new Point(112, 423);
            sizeValue.MaxLength = 4;
            sizeValue.Name = "sizeValue";
            sizeValue.Size = new Size(414, 29);
            sizeValue.TabIndex = 5;
            sizeValue.Text = "0";
            // 
            // weightValue
            // 
            weightValue.Font = new Font("Segoe UI", 12F);
            weightValue.Location = new Point(112, 382);
            weightValue.MaxLength = 4;
            weightValue.Name = "weightValue";
            weightValue.Size = new Size(414, 29);
            weightValue.TabIndex = 4;
            weightValue.Text = "0";
            // 
            // heightValue
            // 
            heightValue.Font = new Font("Segoe UI", 12F);
            heightValue.Location = new Point(112, 345);
            heightValue.MaxLength = 4;
            heightValue.Name = "heightValue";
            heightValue.Size = new Size(414, 29);
            heightValue.TabIndex = 3;
            heightValue.Text = "0";
            // 
            // ageValue
            // 
            ageValue.Font = new Font("Segoe UI", 12F);
            ageValue.Location = new Point(119, 309);
            ageValue.MaxLength = 4;
            ageValue.Name = "ageValue";
            ageValue.Size = new Size(414, 29);
            ageValue.TabIndex = 2;
            ageValue.Text = "0";
            // 
            // characteristics
            // 
            characteristics.Font = new Font("Segoe UI", 12F);
            characteristics.Location = new Point(45, 290);
            characteristics.Name = "characteristics";
            characteristics.Size = new Size(89, 172);
            characteristics.TabIndex = 10;
            characteristics.Text = "Возраст:\r\n\r\nРост:\r\n\r\nВес:\r\n\r\nРазмер:";
            characteristics.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(54, 258);
            label3.Name = "label3";
            label3.Size = new Size(493, 41);
            label3.TabIndex = 9;
            label3.Text = "Данные";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // firstName
            // 
            firstName.Font = new Font("Segoe UI", 15F);
            firstName.Location = new Point(54, 186);
            firstName.MaxLength = 15;
            firstName.Name = "firstName";
            firstName.Size = new Size(493, 34);
            firstName.TabIndex = 0;
            firstName.Text = "label1";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(54, 142);
            label2.Name = "label2";
            label2.Size = new Size(493, 41);
            label2.TabIndex = 8;
            label2.Text = "Имя-Фамилия";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // registrate
            // 
            registrate.Font = new Font("Segoe UI", 15F);
            registrate.Location = new Point(45, 543);
            registrate.Name = "registrate";
            registrate.Size = new Size(493, 75);
            registrate.TabIndex = 6;
            registrate.Text = "Зарегистрироваться";
            registrate.UseVisualStyleBackColor = true;
            registrate.Click += saveChanges_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.imag1;
            pictureBox1.ImageLocation = "";
            pictureBox1.Location = new Point(415, 34);
            pictureBox1.Margin = new Padding(2, 2, 2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(132, 118);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.image2;
            pictureBox2.Location = new Point(21, 34);
            pictureBox2.Margin = new Padding(2, 2, 2, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(128, 112);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // btnAutoInput
            // 
            btnAutoInput.Location = new Point(45, 464);
            btnAutoInput.Margin = new Padding(2, 2, 2, 2);
            btnAutoInput.Name = "btnAutoInput";
            btnAutoInput.Size = new Size(150, 26);
            btnAutoInput.TabIndex = 13;
            btnAutoInput.Text = "Ввести автоматически";
            btnAutoInput.UseVisualStyleBackColor = true;
            btnAutoInput.Click += btnAutoInput_Click;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(577, 644);
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
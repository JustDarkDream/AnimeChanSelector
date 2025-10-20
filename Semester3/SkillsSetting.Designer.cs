namespace ViewForms
{
    partial class SkillsSetting
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
            skillsComboBox = new ComboBox();
            label1 = new Label();
            skillsView = new ListView();
            label2 = new Label();
            addButton = new Button();
            deleteButton = new Button();
            saveButton = new Button();
            SuspendLayout();
            // 
            // skillsComboBox
            // 
            skillsComboBox.FormattingEnabled = true;
            skillsComboBox.Location = new Point(84, 86);
            skillsComboBox.Margin = new Padding(5, 6, 5, 6);
            skillsComboBox.Name = "skillsComboBox";
            skillsComboBox.Size = new Size(916, 38);
            skillsComboBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(125, -2);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(845, 82);
            label1.TabIndex = 2;
            label1.Text = "Выбери Навык";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // skillsView
            // 
            skillsView.Location = new Point(125, 252);
            skillsView.Margin = new Padding(5, 6, 5, 6);
            skillsView.Name = "skillsView";
            skillsView.Size = new Size(842, 254);
            skillsView.TabIndex = 6;
            skillsView.UseCompatibleStateImageBehavior = false;
            skillsView.View = View.List;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(125, 156);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(845, 90);
            label2.TabIndex = 5;
            label2.Text = "Навыки";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addButton
            // 
            addButton.Location = new Point(21, 626);
            addButton.Margin = new Padding(5, 6, 5, 6);
            addButton.Name = "addButton";
            addButton.Size = new Size(240, 132);
            addButton.TabIndex = 7;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(429, 626);
            deleteButton.Margin = new Padding(5, 6, 5, 6);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(240, 132);
            deleteButton.TabIndex = 8;
            deleteButton.Text = "Удалить";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(828, 626);
            saveButton.Margin = new Padding(5, 6, 5, 6);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(240, 132);
            saveButton.TabIndex = 9;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // SkillsSetting
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1089, 782);
            Controls.Add(saveButton);
            Controls.Add(deleteButton);
            Controls.Add(addButton);
            Controls.Add(skillsView);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(skillsComboBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(5, 6, 5, 6);
            Name = "SkillsSetting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SkillsSetting";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox skillsComboBox;
        private Label label1;
        private ListView skillsView;
        private Label label2;
        private Button addButton;
        private Button deleteButton;
        private Button saveButton;
    }
}
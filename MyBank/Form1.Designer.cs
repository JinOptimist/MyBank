namespace MyBank
{
    partial class Form1
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
            if (disposing && (components != null)) {
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
            this.DoGood = new System.Windows.Forms.Button();
            this.SpendingGroupList = new System.Windows.Forms.ComboBox();
            this.ReportTree = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddItemToGroupBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.MainPathLabel = new System.Windows.Forms.Label();
            this.SaveSettingsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DoGood
            // 
            this.DoGood.BackColor = System.Drawing.Color.LightCoral;
            this.DoGood.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DoGood.Location = new System.Drawing.Point(493, 12);
            this.DoGood.Name = "DoGood";
            this.DoGood.Size = new System.Drawing.Size(75, 23);
            this.DoGood.TabIndex = 0;
            this.DoGood.Text = "Посчитать";
            this.DoGood.UseVisualStyleBackColor = false;
            this.DoGood.Click += new System.EventHandler(this.DoGood_Click);
            // 
            // SpendingGroupList
            // 
            this.SpendingGroupList.FormattingEnabled = true;
            this.SpendingGroupList.Location = new System.Drawing.Point(12, 589);
            this.SpendingGroupList.Name = "SpendingGroupList";
            this.SpendingGroupList.Size = new System.Drawing.Size(121, 21);
            this.SpendingGroupList.TabIndex = 1;
            this.SpendingGroupList.SelectedValueChanged += new System.EventHandler(this.SpendingGroupList_SelectedValueChanged);
            // 
            // ReportTree
            // 
            this.ReportTree.Location = new System.Drawing.Point(12, 41);
            this.ReportTree.Name = "ReportTree";
            this.ReportTree.Size = new System.Drawing.Size(556, 529);
            this.ReportTree.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 573);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Поместить выбранный элемент в группу";
            // 
            // AddItemToGroupBtn
            // 
            this.AddItemToGroupBtn.Location = new System.Drawing.Point(139, 587);
            this.AddItemToGroupBtn.Name = "AddItemToGroupBtn";
            this.AddItemToGroupBtn.Size = new System.Drawing.Size(75, 23);
            this.AddItemToGroupBtn.TabIndex = 5;
            this.AddItemToGroupBtn.Text = "Поместить";
            this.AddItemToGroupBtn.UseVisualStyleBackColor = true;
            this.AddItemToGroupBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(57, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Изменить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainPathLabel
            // 
            this.MainPathLabel.AutoSize = true;
            this.MainPathLabel.Location = new System.Drawing.Point(138, 17);
            this.MainPathLabel.Name = "MainPathLabel";
            this.MainPathLabel.Size = new System.Drawing.Size(35, 13);
            this.MainPathLabel.TabIndex = 7;
            this.MainPathLabel.Text = "label3";
            // 
            // SaveSettingsBtn
            // 
            this.SaveSettingsBtn.Location = new System.Drawing.Point(434, 576);
            this.SaveSettingsBtn.Name = "SaveSettingsBtn";
            this.SaveSettingsBtn.Size = new System.Drawing.Size(134, 23);
            this.SaveSettingsBtn.TabIndex = 8;
            this.SaveSettingsBtn.Text = "Сохранить настйроки";
            this.SaveSettingsBtn.UseVisualStyleBackColor = true;
            this.SaveSettingsBtn.Click += new System.EventHandler(this.SaveSettingsBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 660);
            this.Controls.Add(this.SaveSettingsBtn);
            this.Controls.Add(this.MainPathLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AddItemToGroupBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReportTree);
            this.Controls.Add(this.SpendingGroupList);
            this.Controls.Add(this.DoGood);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoGood;
        private System.Windows.Forms.ComboBox SpendingGroupList;
        private System.Windows.Forms.TreeView ReportTree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddItemToGroupBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label MainPathLabel;
        private System.Windows.Forms.Button SaveSettingsBtn;
    }
}


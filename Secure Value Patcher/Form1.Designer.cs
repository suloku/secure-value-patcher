namespace Pokemon_Shuffle_Hack
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
        	this.button1 = new System.Windows.Forms.Button();
        	this.savegamename1 = new System.Windows.Forms.TextBox();
        	this.savegamename2 = new System.Windows.Forms.TextBox();
        	this.button2 = new System.Windows.Forms.Button();
        	this.button3 = new System.Windows.Forms.Button();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.groupBox2 = new System.Windows.Forms.GroupBox();
        	this.securevaluename = new System.Windows.Forms.TextBox();
        	this.button4 = new System.Windows.Forms.Button();
        	this.groupBox3 = new System.Windows.Forms.GroupBox();
        	this.GameName = new System.Windows.Forms.TextBox();
        	this.groupBox5 = new System.Windows.Forms.GroupBox();
        	this.Gameselect = new System.Windows.Forms.ComboBox();
        	this.ShowValue = new System.Windows.Forms.TextBox();
        	this.groupBox6 = new System.Windows.Forms.GroupBox();
        	this.Backupcheck = new System.Windows.Forms.CheckBox();
        	this.groupBox1.SuspendLayout();
        	this.groupBox2.SuspendLayout();
        	this.groupBox3.SuspendLayout();
        	this.groupBox5.SuspendLayout();
        	this.groupBox6.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(6, 19);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(160, 23);
        	this.button1.TabIndex = 0;
        	this.button1.Text = "Open";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// savegamename1
        	// 
        	this.savegamename1.Location = new System.Drawing.Point(6, 48);
        	this.savegamename1.Name = "savegamename1";
        	this.savegamename1.Size = new System.Drawing.Size(160, 20);
        	this.savegamename1.TabIndex = 1;
        	this.savegamename1.TextChanged += new System.EventHandler(this.Savegamename1TextChanged);
        	// 
        	// savegamename2
        	// 
        	this.savegamename2.Location = new System.Drawing.Point(6, 48);
        	this.savegamename2.Name = "savegamename2";
        	this.savegamename2.Size = new System.Drawing.Size(160, 20);
        	this.savegamename2.TabIndex = 2;
        	this.savegamename2.TextChanged += new System.EventHandler(this.Savegamename2TextChanged);
        	// 
        	// button2
        	// 
        	this.button2.Location = new System.Drawing.Point(12, 307);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(350, 23);
        	this.button2.TabIndex = 3;
        	this.button2.Text = "Fix";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.button2_Click);
        	// 
        	// button3
        	// 
        	this.button3.Location = new System.Drawing.Point(6, 19);
        	this.button3.Name = "button3";
        	this.button3.Size = new System.Drawing.Size(160, 23);
        	this.button3.TabIndex = 4;
        	this.button3.Text = "Open";
        	this.button3.UseVisualStyleBackColor = true;
        	this.button3.Click += new System.EventHandler(this.button3_Click);
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.savegamename1);
        	this.groupBox1.Controls.Add(this.button1);
        	this.groupBox1.Location = new System.Drawing.Point(12, 12);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(172, 79);
        	this.groupBox1.TabIndex = 5;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "[Corrupt \"Old\" Save]";
        	// 
        	// groupBox2
        	// 
        	this.groupBox2.Controls.Add(this.savegamename2);
        	this.groupBox2.Controls.Add(this.button3);
        	this.groupBox2.Location = new System.Drawing.Point(190, 12);
        	this.groupBox2.Name = "groupBox2";
        	this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        	this.groupBox2.Size = new System.Drawing.Size(172, 79);
        	this.groupBox2.TabIndex = 6;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "[Good \"Latest\" Save]";
        	// 
        	// securevaluename
        	// 
        	this.securevaluename.Location = new System.Drawing.Point(47, 54);
        	this.securevaluename.Name = "securevaluename";
        	this.securevaluename.Size = new System.Drawing.Size(160, 20);
        	this.securevaluename.TabIndex = 1;
        	this.securevaluename.TextChanged += new System.EventHandler(this.SecurevaluenameTextChanged);
        	// 
        	// button4
        	// 
        	this.button4.Location = new System.Drawing.Point(47, 25);
        	this.button4.Name = "button4";
        	this.button4.Size = new System.Drawing.Size(160, 23);
        	this.button4.TabIndex = 0;
        	this.button4.Text = "Open";
        	this.button4.UseVisualStyleBackColor = true;
        	this.button4.Click += new System.EventHandler(this.Button4Click);
        	// 
        	// groupBox3
        	// 
        	this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
        	this.groupBox3.Controls.Add(this.GameName);
        	this.groupBox3.Controls.Add(this.securevaluename);
        	this.groupBox3.Controls.Add(this.button4);
        	this.groupBox3.Location = new System.Drawing.Point(18, 191);
        	this.groupBox3.Name = "groupBox3";
        	this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        	this.groupBox3.Size = new System.Drawing.Size(257, 110);
        	this.groupBox3.TabIndex = 7;
        	this.groupBox3.TabStop = false;
        	this.groupBox3.Text = "[Secure Value Location File]";
        	// 
        	// GameName
        	// 
        	this.GameName.Location = new System.Drawing.Point(6, 80);
        	this.GameName.Name = "GameName";
        	this.GameName.ReadOnly = true;
        	this.GameName.Size = new System.Drawing.Size(245, 20);
        	this.GameName.TabIndex = 8;
        	this.GameName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        	this.GameName.TextChanged += new System.EventHandler(this.GameNameTextChanged);
        	// 
        	// groupBox5
        	// 
        	this.groupBox5.Controls.Add(this.Gameselect);
        	this.groupBox5.Location = new System.Drawing.Point(12, 131);
        	this.groupBox5.Name = "groupBox5";
        	this.groupBox5.Size = new System.Drawing.Size(350, 44);
        	this.groupBox5.TabIndex = 11;
        	this.groupBox5.TabStop = false;
        	this.groupBox5.Text = "Select Game Secure Value";
        	// 
        	// Gameselect
        	// 
        	this.Gameselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.Gameselect.FormattingEnabled = true;
        	this.Gameselect.Location = new System.Drawing.Point(6, 17);
        	this.Gameselect.Name = "Gameselect";
        	this.Gameselect.Size = new System.Drawing.Size(338, 21);
        	this.Gameselect.TabIndex = 0;
        	this.Gameselect.SelectedIndexChanged += new System.EventHandler(this.GameselectSelectedIndexChanged);
        	// 
        	// ShowValue
        	// 
        	this.ShowValue.Location = new System.Drawing.Point(6, 14);
        	this.ShowValue.Name = "ShowValue";
        	this.ShowValue.ReadOnly = true;
        	this.ShowValue.Size = new System.Drawing.Size(63, 20);
        	this.ShowValue.TabIndex = 12;
        	this.ShowValue.TextChanged += new System.EventHandler(this.ShowValueTextChanged);
        	// 
        	// groupBox6
        	// 
        	this.groupBox6.Controls.Add(this.ShowValue);
        	this.groupBox6.Location = new System.Drawing.Point(281, 199);
        	this.groupBox6.Name = "groupBox6";
        	this.groupBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        	this.groupBox6.Size = new System.Drawing.Size(74, 40);
        	this.groupBox6.TabIndex = 13;
        	this.groupBox6.TabStop = false;
        	this.groupBox6.Text = "Offset";
        	// 
        	// Backupcheck
        	// 
        	this.Backupcheck.Checked = true;
        	this.Backupcheck.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.Backupcheck.Location = new System.Drawing.Point(18, 98);
        	this.Backupcheck.Name = "Backupcheck";
        	this.Backupcheck.Size = new System.Drawing.Size(160, 24);
        	this.Backupcheck.TabIndex = 14;
        	this.Backupcheck.Text = "Backup \"Old\" save";
        	this.Backupcheck.UseVisualStyleBackColor = true;
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(373, 339);
        	this.Controls.Add(this.Backupcheck);
        	this.Controls.Add(this.groupBox6);
        	this.Controls.Add(this.groupBox3);
        	this.Controls.Add(this.groupBox2);
        	this.Controls.Add(this.groupBox1);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.groupBox5);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        	this.Name = "Form1";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Secure Value Patcher 0.2c";
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	this.groupBox2.ResumeLayout(false);
        	this.groupBox2.PerformLayout();
        	this.groupBox3.ResumeLayout(false);
        	this.groupBox3.PerformLayout();
        	this.groupBox5.ResumeLayout(false);
        	this.groupBox6.ResumeLayout(false);
        	this.groupBox6.PerformLayout();
        	this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox savegamename1;
        private System.Windows.Forms.TextBox savegamename2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox securevaluename;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox GameName;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox Gameselect;
        private System.Windows.Forms.TextBox ShowValue;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox Backupcheck;
    }
}
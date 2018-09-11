namespace voteManager
{
    partial class LoginForm
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
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.checkBoxHideShowLogin = new System.Windows.Forms.CheckBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.linkLabelContactAdmin = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(51, 83);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(326, 20);
            this.textBoxLogin.TabIndex = 2;
            this.textBoxLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxLogin_KeyDown);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(236, 173);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(141, 23);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelPassword);
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Controls.Add(this.buttonLogin);
            this.groupBox1.Controls.Add(this.checkBoxHideShowLogin);
            this.groupBox1.Controls.Add(this.labelLogin);
            this.groupBox1.Controls.Add(this.textBoxLogin);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(48, 116);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(51, 132);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(326, 20);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // checkBoxHideShowLogin
            // 
            this.checkBoxHideShowLogin.AutoSize = true;
            this.checkBoxHideShowLogin.Checked = true;
            this.checkBoxHideShowLogin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHideShowLogin.Location = new System.Drawing.Point(268, 60);
            this.checkBoxHideShowLogin.Name = "checkBoxHideShowLogin";
            this.checkBoxHideShowLogin.Size = new System.Drawing.Size(109, 17);
            this.checkBoxHideShowLogin.TabIndex = 1;
            this.checkBoxHideShowLogin.Text = "Hide/Show Login\r\n";
            this.checkBoxHideShowLogin.UseVisualStyleBackColor = true;
            this.checkBoxHideShowLogin.CheckedChanged += new System.EventHandler(this.checkBoxHideShowLogin_CheckedChanged);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(48, 67);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(36, 13);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Login:";
            // 
            // linkLabelContactAdmin
            // 
            this.linkLabelContactAdmin.AutoSize = true;
            this.linkLabelContactAdmin.Location = new System.Drawing.Point(12, 231);
            this.linkLabelContactAdmin.Name = "linkLabelContactAdmin";
            this.linkLabelContactAdmin.Size = new System.Drawing.Size(228, 13);
            this.linkLabelContactAdmin.TabIndex = 1;
            this.linkLabelContactAdmin.TabStop = true;
            this.linkLabelContactAdmin.Text = "To create new account, please contact admin!";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 250);
            this.Controls.Add(this.linkLabelContactAdmin);
            this.Controls.Add(this.groupBox1);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.CheckBox checkBoxHideShowLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.LinkLabel linkLabelContactAdmin;
    }
}
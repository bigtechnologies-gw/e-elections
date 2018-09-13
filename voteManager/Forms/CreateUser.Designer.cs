namespace voteManager.Forms
{
    partial class CreateUser
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
            this.groupBoxCreateUser = new System.Windows.Forms.GroupBox();
            this.buttonCreateUser = new System.Windows.Forms.Button();
            this.labelUserName = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.comboBoxAdminProvince = new System.Windows.Forms.ComboBox();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelProvinceAdmin = new System.Windows.Forms.Label();
            this.groupBoxCreateUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCreateUser
            // 
            this.groupBoxCreateUser.Controls.Add(this.labelProvinceAdmin);
            this.groupBoxCreateUser.Controls.Add(this.buttonCreateUser);
            this.groupBoxCreateUser.Controls.Add(this.labelUserName);
            this.groupBoxCreateUser.Controls.Add(this.textBoxUserName);
            this.groupBoxCreateUser.Controls.Add(this.labelConfirmPassword);
            this.groupBoxCreateUser.Controls.Add(this.labelPassword);
            this.groupBoxCreateUser.Controls.Add(this.labelFullName);
            this.groupBoxCreateUser.Controls.Add(this.textBoxFullName);
            this.groupBoxCreateUser.Controls.Add(this.comboBoxAdminProvince);
            this.groupBoxCreateUser.Controls.Add(this.textBoxConfirmPassword);
            this.groupBoxCreateUser.Controls.Add(this.textBoxPassword);
            this.groupBoxCreateUser.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCreateUser.Name = "groupBoxCreateUser";
            this.groupBoxCreateUser.Size = new System.Drawing.Size(501, 272);
            this.groupBoxCreateUser.TabIndex = 0;
            this.groupBoxCreateUser.TabStop = false;
            this.groupBoxCreateUser.Text = "New user";
            // 
            // buttonCreateUser
            // 
            this.buttonCreateUser.Location = new System.Drawing.Point(309, 227);
            this.buttonCreateUser.Name = "buttonCreateUser";
            this.buttonCreateUser.Size = new System.Drawing.Size(110, 23);
            this.buttonCreateUser.TabIndex = 10;
            this.buttonCreateUser.Text = "Create";
            this.buttonCreateUser.UseVisualStyleBackColor = true;
            this.buttonCreateUser.Click += new System.EventHandler(this.buttonCreateUser_Click);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(75, 28);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(58, 13);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "Username:";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(78, 44);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(168, 20);
            this.textBoxUserName.TabIndex = 1;
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Location = new System.Drawing.Point(75, 163);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new System.Drawing.Size(93, 13);
            this.labelConfirmPassword.TabIndex = 6;
            this.labelConfirmPassword.Text = "Confirm password:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(75, 117);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password:";
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(75, 74);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(57, 13);
            this.labelFullName.TabIndex = 2;
            this.labelFullName.Text = "Full-Name:";
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(78, 90);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(341, 20);
            this.textBoxFullName.TabIndex = 3;
            // 
            // comboBoxAdminProvince
            // 
            this.comboBoxAdminProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdminProvince.FormattingEnabled = true;
            this.comboBoxAdminProvince.Location = new System.Drawing.Point(78, 229);
            this.comboBoxAdminProvince.Name = "comboBoxAdminProvince";
            this.comboBoxAdminProvince.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAdminProvince.TabIndex = 9;
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(78, 179);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(341, 20);
            this.textBoxConfirmPassword.TabIndex = 7;
            this.textBoxConfirmPassword.UseSystemPasswordChar = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(78, 133);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(341, 20);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelProvinceAdmin
            // 
            this.labelProvinceAdmin.AutoSize = true;
            this.labelProvinceAdmin.Location = new System.Drawing.Point(75, 213);
            this.labelProvinceAdmin.Name = "labelProvinceAdmin";
            this.labelProvinceAdmin.Size = new System.Drawing.Size(83, 13);
            this.labelProvinceAdmin.TabIndex = 8;
            this.labelProvinceAdmin.Text = "Province admin;";
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 301);
            this.Controls.Add(this.groupBoxCreateUser);
            this.Name = "CreateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateUser";
            this.groupBoxCreateUser.ResumeLayout(false);
            this.groupBoxCreateUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCreateUser;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.ComboBox comboBoxAdminProvince;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Button buttonCreateUser;
        private System.Windows.Forms.Label labelProvinceAdmin;
    }
}
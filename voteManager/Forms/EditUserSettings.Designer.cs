namespace VoteManager.Forms
{
    partial class EditUserSettings
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
            this.groupBoxManageUser = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonUpdateUser = new System.Windows.Forms.Button();
            this.checkBoxEnableEditUser = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxEditPasswowrd = new System.Windows.Forms.TextBox();
            this.textBoxEditFullName = new System.Windows.Forms.TextBox();
            this.textBoxEditLogin = new System.Windows.Forms.TextBox();
            this.buttonRemoveUser = new System.Windows.Forms.Button();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.groupBoxAddUser = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxProvince = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxTypeUser = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxManageUser.SuspendLayout();
            this.groupBoxAddUser.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxManageUser
            // 
            this.groupBoxManageUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxManageUser.Controls.Add(this.label13);
            this.groupBoxManageUser.Controls.Add(this.buttonUpdateUser);
            this.groupBoxManageUser.Controls.Add(this.checkBoxEnableEditUser);
            this.groupBoxManageUser.Controls.Add(this.label17);
            this.groupBoxManageUser.Controls.Add(this.label15);
            this.groupBoxManageUser.Controls.Add(this.label14);
            this.groupBoxManageUser.Controls.Add(this.textBoxEditPasswowrd);
            this.groupBoxManageUser.Controls.Add(this.textBoxEditFullName);
            this.groupBoxManageUser.Controls.Add(this.textBoxEditLogin);
            this.groupBoxManageUser.Controls.Add(this.buttonRemoveUser);
            this.groupBoxManageUser.Controls.Add(this.listBoxUsers);
            this.groupBoxManageUser.Location = new System.Drawing.Point(19, 34);
            this.groupBoxManageUser.Name = "groupBoxManageUser";
            this.groupBoxManageUser.Size = new System.Drawing.Size(409, 402);
            this.groupBoxManageUser.TabIndex = 10;
            this.groupBoxManageUser.TabStop = false;
            this.groupBoxManageUser.Text = "Modify user:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(210, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Login:";
            // 
            // buttonUpdateUser
            // 
            this.buttonUpdateUser.Location = new System.Drawing.Point(210, 229);
            this.buttonUpdateUser.Name = "buttonUpdateUser";
            this.buttonUpdateUser.Size = new System.Drawing.Size(169, 23);
            this.buttonUpdateUser.TabIndex = 16;
            this.buttonUpdateUser.Text = "Update";
            this.buttonUpdateUser.UseVisualStyleBackColor = true;
            this.buttonUpdateUser.Click += new System.EventHandler(this.buttonUpdateUser_Click);
            // 
            // checkBoxEnableEditUser
            // 
            this.checkBoxEnableEditUser.AutoSize = true;
            this.checkBoxEnableEditUser.Location = new System.Drawing.Point(308, 175);
            this.checkBoxEnableEditUser.Name = "checkBoxEnableEditUser";
            this.checkBoxEnableEditUser.Size = new System.Drawing.Size(71, 17);
            this.checkBoxEnableEditUser.TabIndex = 15;
            this.checkBoxEnableEditUser.Text = "Enabled?";
            this.checkBoxEnableEditUser.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(207, 129);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 9;
            this.label17.Text = "Password:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(207, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Full name:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(207, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 13);
            this.label14.TabIndex = 6;
            // 
            // textBoxEditPasswowrd
            // 
            this.textBoxEditPasswowrd.Location = new System.Drawing.Point(210, 143);
            this.textBoxEditPasswowrd.Name = "textBoxEditPasswowrd";
            this.textBoxEditPasswowrd.Size = new System.Drawing.Size(169, 20);
            this.textBoxEditPasswowrd.TabIndex = 5;
            this.textBoxEditPasswowrd.UseSystemPasswordChar = true;
            // 
            // textBoxEditFullName
            // 
            this.textBoxEditFullName.Location = new System.Drawing.Point(210, 97);
            this.textBoxEditFullName.Name = "textBoxEditFullName";
            this.textBoxEditFullName.Size = new System.Drawing.Size(169, 20);
            this.textBoxEditFullName.TabIndex = 4;
            // 
            // textBoxEditLogin
            // 
            this.textBoxEditLogin.Location = new System.Drawing.Point(210, 51);
            this.textBoxEditLogin.Name = "textBoxEditLogin";
            this.textBoxEditLogin.Size = new System.Drawing.Size(169, 20);
            this.textBoxEditLogin.TabIndex = 3;
            // 
            // buttonRemoveUser
            // 
            this.buttonRemoveUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveUser.Location = new System.Drawing.Point(25, 362);
            this.buttonRemoveUser.Name = "buttonRemoveUser";
            this.buttonRemoveUser.Size = new System.Drawing.Size(158, 23);
            this.buttonRemoveUser.TabIndex = 2;
            this.buttonRemoveUser.Text = "Remove";
            this.buttonRemoveUser.UseVisualStyleBackColor = true;
            this.buttonRemoveUser.Click += new System.EventHandler(this.buttonRemoveUser_Click);
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.ItemHeight = 16;
            this.listBoxUsers.Location = new System.Drawing.Point(25, 34);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(158, 308);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.ListBoxUsers_SelectedIndexChanged);
            // 
            // groupBoxAddUser
            // 
            this.groupBoxAddUser.Controls.Add(this.label2);
            this.groupBoxAddUser.Controls.Add(this.comboBoxTypeUser);
            this.groupBoxAddUser.Controls.Add(this.label1);
            this.groupBoxAddUser.Controls.Add(this.comboBoxProvince);
            this.groupBoxAddUser.Controls.Add(this.label11);
            this.groupBoxAddUser.Controls.Add(this.textBoxUserName);
            this.groupBoxAddUser.Controls.Add(this.label10);
            this.groupBoxAddUser.Controls.Add(this.label9);
            this.groupBoxAddUser.Controls.Add(this.label8);
            this.groupBoxAddUser.Controls.Add(this.textBoxFullName);
            this.groupBoxAddUser.Controls.Add(this.textBoxConfirmPassword);
            this.groupBoxAddUser.Controls.Add(this.textBoxPassword);
            this.groupBoxAddUser.Controls.Add(this.buttonAddUser);
            this.groupBoxAddUser.Location = new System.Drawing.Point(448, 34);
            this.groupBoxAddUser.Name = "groupBoxAddUser";
            this.groupBoxAddUser.Size = new System.Drawing.Size(325, 402);
            this.groupBoxAddUser.TabIndex = 11;
            this.groupBoxAddUser.TabStop = false;
            this.groupBoxAddUser.Text = "Add users";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Province:";
            // 
            // comboBoxProvince
            // 
            this.comboBoxProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProvince.FormattingEnabled = true;
            this.comboBoxProvince.Location = new System.Drawing.Point(53, 237);
            this.comboBoxProvince.Name = "comboBoxProvince";
            this.comboBoxProvince.Size = new System.Drawing.Size(121, 21);
            this.comboBoxProvince.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(50, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Login:";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(53, 52);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(153, 20);
            this.textBoxUserName.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(50, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Full-Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Confirm password:";
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(53, 99);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(221, 20);
            this.textBoxFullName.TabIndex = 6;
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(53, 191);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(221, 20);
            this.textBoxConfirmPassword.TabIndex = 4;
            this.textBoxConfirmPassword.UseSystemPasswordChar = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(53, 145);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(221, 20);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddUser.Location = new System.Drawing.Point(168, 319);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(106, 23);
            this.buttonAddUser.TabIndex = 1;
            this.buttonAddUser.Text = "Add";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxManageUser);
            this.groupBox1.Controls.Add(this.groupBoxAddUser);
            this.groupBox1.Location = new System.Drawing.Point(17, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 471);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User:";
            // 
            // comboBoxTypeUser
            // 
            this.comboBoxTypeUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeUser.FormattingEnabled = true;
            this.comboBoxTypeUser.Location = new System.Drawing.Point(53, 289);
            this.comboBoxTypeUser.Name = "comboBoxTypeUser";
            this.comboBoxTypeUser.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTypeUser.TabIndex = 15;
            this.comboBoxTypeUser.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeUser_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Typs user:";
            // 
            // EditUserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 496);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditUserSettings";
            this.Text = "Settings";
            this.groupBoxManageUser.ResumeLayout(false);
            this.groupBoxManageUser.PerformLayout();
            this.groupBoxAddUser.ResumeLayout(false);
            this.groupBoxAddUser.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxManageUser;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonUpdateUser;
        private System.Windows.Forms.CheckBox checkBoxEnableEditUser;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxEditPasswowrd;
        private System.Windows.Forms.TextBox textBoxEditFullName;
        private System.Windows.Forms.TextBox textBoxEditLogin;
        private System.Windows.Forms.Button buttonRemoveUser;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.GroupBox groupBoxAddUser;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxProvince;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTypeUser;
    }
}
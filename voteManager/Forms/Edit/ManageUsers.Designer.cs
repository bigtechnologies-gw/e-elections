namespace EElections.Forms
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.buttonOK = new System.Windows.Forms.Button();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBoxAddUser = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTypeUser = new System.Windows.Forms.ComboBox();
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
            this.groupBoxManageUser.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxAddUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkLabel1.Location = new System.Drawing.Point(20, 564);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(186, 16);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Powered by: Big technologies";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(753, 552);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(141, 28);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
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
            this.groupBoxManageUser.Location = new System.Drawing.Point(14, 14);
            this.groupBoxManageUser.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxManageUser.Name = "groupBoxManageUser";
            this.groupBoxManageUser.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxManageUser.Size = new System.Drawing.Size(835, 451);
            this.groupBoxManageUser.TabIndex = 1;
            this.groupBoxManageUser.TabStop = false;
            this.groupBoxManageUser.Text = "Modificar Usuário:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(280, 74);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "Login:";
            // 
            // buttonUpdateUser
            // 
            this.buttonUpdateUser.Location = new System.Drawing.Point(279, 317);
            this.buttonUpdateUser.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUpdateUser.Name = "buttonUpdateUser";
            this.buttonUpdateUser.Size = new System.Drawing.Size(225, 28);
            this.buttonUpdateUser.TabIndex = 8;
            this.buttonUpdateUser.Text = "Atualizar";
            this.buttonUpdateUser.UseVisualStyleBackColor = true;
            this.buttonUpdateUser.Click += new System.EventHandler(this.ButtonUpdateUser_Click);
            // 
            // checkBoxEnableEditUser
            // 
            this.checkBoxEnableEditUser.AutoSize = true;
            this.checkBoxEnableEditUser.Location = new System.Drawing.Point(279, 250);
            this.checkBoxEnableEditUser.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxEnableEditUser.Name = "checkBoxEnableEditUser";
            this.checkBoxEnableEditUser.Size = new System.Drawing.Size(87, 20);
            this.checkBoxEnableEditUser.TabIndex = 7;
            this.checkBoxEnableEditUser.Text = "Activado?";
            this.checkBoxEnableEditUser.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(276, 194);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 16);
            this.label17.TabIndex = 5;
            this.label17.Text = "Palavra-passe:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(276, 135);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 16);
            this.label15.TabIndex = 3;
            this.label15.Text = "Nome Completo:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(276, 42);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 16);
            this.label14.TabIndex = 6;
            // 
            // textBoxEditPasswowrd
            // 
            this.textBoxEditPasswowrd.Location = new System.Drawing.Point(280, 211);
            this.textBoxEditPasswowrd.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxEditPasswowrd.Name = "textBoxEditPasswowrd";
            this.textBoxEditPasswowrd.Size = new System.Drawing.Size(224, 22);
            this.textBoxEditPasswowrd.TabIndex = 6;
            this.textBoxEditPasswowrd.UseSystemPasswordChar = true;
            // 
            // textBoxEditFullName
            // 
            this.textBoxEditFullName.Location = new System.Drawing.Point(280, 154);
            this.textBoxEditFullName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxEditFullName.Name = "textBoxEditFullName";
            this.textBoxEditFullName.Size = new System.Drawing.Size(224, 22);
            this.textBoxEditFullName.TabIndex = 4;
            // 
            // textBoxEditLogin
            // 
            this.textBoxEditLogin.Location = new System.Drawing.Point(280, 98);
            this.textBoxEditLogin.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxEditLogin.Name = "textBoxEditLogin";
            this.textBoxEditLogin.Size = new System.Drawing.Size(224, 22);
            this.textBoxEditLogin.TabIndex = 2;
            // 
            // buttonRemoveUser
            // 
            this.buttonRemoveUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveUser.Location = new System.Drawing.Point(279, 348);
            this.buttonRemoveUser.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRemoveUser.Name = "buttonRemoveUser";
            this.buttonRemoveUser.Size = new System.Drawing.Size(225, 28);
            this.buttonRemoveUser.TabIndex = 9;
            this.buttonRemoveUser.Text = "Remover";
            this.buttonRemoveUser.UseVisualStyleBackColor = true;
            this.buttonRemoveUser.Click += new System.EventHandler(this.buttonRemoveUser_Click);
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.ItemHeight = 25;
            this.listBoxUsers.Location = new System.Drawing.Point(33, 36);
            this.listBoxUsers.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(209, 379);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.ListBoxUsers_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(871, 507);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxManageUser);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(863, 478);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Editar Usuário";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBoxAddUser);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(863, 478);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Adicionar novo usuário";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.groupBoxAddUser.Location = new System.Drawing.Point(14, 11);
            this.groupBoxAddUser.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxAddUser.Name = "groupBoxAddUser";
            this.groupBoxAddUser.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxAddUser.Size = new System.Drawing.Size(835, 456);
            this.groupBoxAddUser.TabIndex = 3;
            this.groupBoxAddUser.TabStop = false;
            this.groupBoxAddUser.Text = "Adicionar Usuário:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 352);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tipo de usuário:";
            // 
            // comboBoxTypeUser
            // 
            this.comboBoxTypeUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeUser.FormattingEnabled = true;
            this.comboBoxTypeUser.Location = new System.Drawing.Point(71, 372);
            this.comboBoxTypeUser.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTypeUser.Name = "comboBoxTypeUser";
            this.comboBoxTypeUser.Size = new System.Drawing.Size(160, 24);
            this.comboBoxTypeUser.TabIndex = 11;
            this.comboBoxTypeUser.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTypeUser_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 288);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Provincía:";
            // 
            // comboBoxProvince
            // 
            this.comboBoxProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProvince.Enabled = false;
            this.comboBoxProvince.FormattingEnabled = true;
            this.comboBoxProvince.Location = new System.Drawing.Point(71, 308);
            this.comboBoxProvince.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxProvince.Name = "comboBoxProvince";
            this.comboBoxProvince.Size = new System.Drawing.Size(160, 24);
            this.comboBoxProvince.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(67, 60);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Login:";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(71, 80);
            this.textBoxUserName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(203, 22);
            this.textBoxUserName.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(67, 175);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Palavra-passe:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(67, 118);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Nome Completo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 231);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Confirmar palavra-passe:";
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(71, 138);
            this.textBoxFullName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(293, 22);
            this.textBoxFullName.TabIndex = 3;
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(71, 251);
            this.textBoxConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(293, 22);
            this.textBoxConfirmPassword.TabIndex = 7;
            this.textBoxConfirmPassword.UseSystemPasswordChar = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(71, 194);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(293, 22);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddUser.Location = new System.Drawing.Point(239, 369);
            this.buttonAddUser.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(141, 28);
            this.buttonAddUser.TabIndex = 12;
            this.buttonAddUser.Text = "Adicionar";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // EditUserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 610);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.linkLabel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditUserSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Gestão de utilizadores";
            this.groupBoxManageUser.ResumeLayout(false);
            this.groupBoxManageUser.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBoxAddUser.ResumeLayout(false);
            this.groupBoxAddUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button buttonOK;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBoxAddUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTypeUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxProvince;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonAddUser;
    }
}
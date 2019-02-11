namespace EElections.Forms
{
    partial class EditPartidos
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.checkedListBoxPartidos = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.pictureBoxPartidoLogo = new System.Windows.Forms.PictureBox();
            this.buttonAddModify = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPartidoLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(470, 473);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(108, 22);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // checkedListBoxPartidos
            // 
            this.checkedListBoxPartidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxPartidos.FormattingEnabled = true;
            this.checkedListBoxPartidos.Location = new System.Drawing.Point(32, 33);
            this.checkedListBoxPartidos.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBoxPartidos.Name = "checkedListBoxPartidos";
            this.checkedListBoxPartidos.Size = new System.Drawing.Size(225, 420);
            this.checkedListBoxPartidos.TabIndex = 10;
            this.checkedListBoxPartidos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBoxPartidos_ItemCheck);
            this.checkedListBoxPartidos.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxPartidos_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.buttonBrowse);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxName);
            this.groupBox2.Controls.Add(this.pictureBoxPartidoLogo);
            this.groupBox2.Controls.Add(this.buttonAddModify);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(283, 33);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(295, 436);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info de Partido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Logo de partido:";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(159, 334);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(100, 28);
            this.buttonBrowse.TabIndex = 14;
            this.buttonBrowse.Text = "Selecionar";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nome:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(36, 74);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(223, 22);
            this.textBoxName.TabIndex = 7;
            // 
            // pictureBoxPartidoLogo
            // 
            this.pictureBoxPartidoLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPartidoLogo.Location = new System.Drawing.Point(35, 132);
            this.pictureBoxPartidoLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxPartidoLogo.Name = "pictureBoxPartidoLogo";
            this.pictureBoxPartidoLogo.Size = new System.Drawing.Size(223, 189);
            this.pictureBoxPartidoLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPartidoLogo.TabIndex = 4;
            this.pictureBoxPartidoLogo.TabStop = false;
            this.pictureBoxPartidoLogo.Click += new System.EventHandler(this.PictureBoxPartidoLogo_Click);
            // 
            // buttonAddModify
            // 
            this.buttonAddModify.Location = new System.Drawing.Point(36, 382);
            this.buttonAddModify.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddModify.Name = "buttonAddModify";
            this.buttonAddModify.Size = new System.Drawing.Size(223, 28);
            this.buttonAddModify.TabIndex = 9;
            this.buttonAddModify.Text = "Adicionar/Modificar";
            this.buttonAddModify.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkLabel1.Location = new System.Drawing.Point(29, 477);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(186, 16);
            this.linkLabel1.TabIndex = 40;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Powered by: Big technologies";
            // 
            // EditPartidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 521);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.checkedListBoxPartidos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPartidos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestor de partidos";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPartidoLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckedListBox checkedListBoxPartidos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.PictureBox pictureBoxPartidoLogo;
        private System.Windows.Forms.Button buttonAddModify;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
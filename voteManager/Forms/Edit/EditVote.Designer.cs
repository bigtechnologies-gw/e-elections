namespace EElections.Forms
{
    partial class EditVote
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
            this.buttonAddVote = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxVote = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSectors = new System.Windows.Forms.ComboBox();
            this.comboBoxVotingTable = new System.Windows.Forms.ComboBox();
            this.comboBoxRegions = new System.Windows.Forms.ComboBox();
            this.comboBoxCE = new System.Windows.Forms.ComboBox();
            this.comboBoxPartidos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAddVote
            // 
            this.buttonAddVote.Location = new System.Drawing.Point(443, 236);
            this.buttonAddVote.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddVote.Name = "buttonAddVote";
            this.buttonAddVote.Size = new System.Drawing.Size(113, 27);
            this.buttonAddVote.TabIndex = 25;
            this.buttonAddVote.Text = "Actualizar";
            this.buttonAddVote.UseVisualStyleBackColor = true;
            this.buttonAddVote.Click += new System.EventHandler(this.ButtonAddVote_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(564, 236);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(113, 27);
            this.buttonCancel.TabIndex = 38;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkLabel1.Location = new System.Drawing.Point(13, 247);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(186, 16);
            this.linkLabel1.TabIndex = 39;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Powered by: Big technologies";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "Partido:";
            // 
            // textBoxVote
            // 
            this.textBoxVote.Location = new System.Drawing.Point(465, 160);
            this.textBoxVote.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxVote.Name = "textBoxVote";
            this.textBoxVote.Size = new System.Drawing.Size(160, 22);
            this.textBoxVote.TabIndex = 51;
            this.textBoxVote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 140);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 16);
            this.label6.TabIndex = 50;
            this.label6.Text = "CE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "Sector:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 71);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 49;
            this.label5.Text = "Mesa de voto:";
            // 
            // comboBoxSectors
            // 
            this.comboBoxSectors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSectors.FormattingEnabled = true;
            this.comboBoxSectors.Location = new System.Drawing.Point(265, 91);
            this.comboBoxSectors.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSectors.Name = "comboBoxSectors";
            this.comboBoxSectors.Size = new System.Drawing.Size(160, 24);
            this.comboBoxSectors.TabIndex = 41;
            // 
            // comboBoxVotingTable
            // 
            this.comboBoxVotingTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVotingTable.FormattingEnabled = true;
            this.comboBoxVotingTable.Location = new System.Drawing.Point(465, 91);
            this.comboBoxVotingTable.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxVotingTable.Name = "comboBoxVotingTable";
            this.comboBoxVotingTable.Size = new System.Drawing.Size(160, 24);
            this.comboBoxVotingTable.TabIndex = 48;
            // 
            // comboBoxRegions
            // 
            this.comboBoxRegions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegions.FormattingEnabled = true;
            this.comboBoxRegions.Location = new System.Drawing.Point(71, 160);
            this.comboBoxRegions.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxRegions.Name = "comboBoxRegions";
            this.comboBoxRegions.Size = new System.Drawing.Size(160, 24);
            this.comboBoxRegions.TabIndex = 40;
            // 
            // comboBoxCE
            // 
            this.comboBoxCE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCE.FormattingEnabled = true;
            this.comboBoxCE.Location = new System.Drawing.Point(268, 159);
            this.comboBoxCE.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCE.Name = "comboBoxCE";
            this.comboBoxCE.Size = new System.Drawing.Size(160, 24);
            this.comboBoxCE.TabIndex = 47;
            // 
            // comboBoxPartidos
            // 
            this.comboBoxPartidos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPartidos.FormattingEnabled = true;
            this.comboBoxPartidos.Location = new System.Drawing.Point(71, 91);
            this.comboBoxPartidos.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPartidos.Name = "comboBoxPartidos";
            this.comboBoxPartidos.Size = new System.Drawing.Size(160, 24);
            this.comboBoxPartidos.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "Voto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "Região:";
            // 
            // EditVote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 289);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxVote);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxSectors);
            this.Controls.Add(this.comboBoxVotingTable);
            this.Controls.Add(this.comboBoxRegions);
            this.Controls.Add(this.comboBoxCE);
            this.Controls.Add(this.comboBoxPartidos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAddVote);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditVote";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Editar voto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonAddVote;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxVote;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSectors;
        private System.Windows.Forms.ComboBox comboBoxVotingTable;
        private System.Windows.Forms.ComboBox comboBoxRegions;
        private System.Windows.Forms.ComboBox comboBoxCE;
        private System.Windows.Forms.ComboBox comboBoxPartidos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}
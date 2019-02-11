namespace EElections.Forms
{
    partial class EditVotingTable
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBoxRegistedVoters = new System.Windows.Forms.TextBox();
            this.textBoxInvalidVotes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxSector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.textBoxVotingTableName = new System.Windows.Forms.TextBox();
            this.listBoxVotingTable = new System.Windows.Forms.ListBox();
            this.buttonAddModify = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCE = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(385, 490);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(139, 28);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkLabel1.Location = new System.Drawing.Point(16, 502);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(186, 16);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Powered by: Big technologies";
            // 
            // textBoxRegistedVoters
            // 
            this.textBoxRegistedVoters.Location = new System.Drawing.Point(323, 405);
            this.textBoxRegistedVoters.Name = "textBoxRegistedVoters";
            this.textBoxRegistedVoters.Size = new System.Drawing.Size(160, 22);
            this.textBoxRegistedVoters.TabIndex = 32;
            // 
            // textBoxInvalidVotes
            // 
            this.textBoxInvalidVotes.Location = new System.Drawing.Point(323, 350);
            this.textBoxInvalidVotes.Name = "textBoxInvalidVotes";
            this.textBoxInvalidVotes.Size = new System.Drawing.Size(160, 22);
            this.textBoxInvalidVotes.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 16);
            this.label6.TabIndex = 30;
            this.label6.Text = "Registar Votos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Votos Inválidos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 153);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Sector:";
            // 
            // comboBoxSector
            // 
            this.comboBoxSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSector.FormattingEnabled = true;
            this.comboBoxSector.Location = new System.Drawing.Point(324, 176);
            this.comboBoxSector.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSector.Name = "comboBoxSector";
            this.comboBoxSector.Size = new System.Drawing.Size(160, 24);
            this.comboBoxSector.TabIndex = 27;
            this.comboBoxSector.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSector_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Região:";
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(324, 114);
            this.comboBoxRegion.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(160, 24);
            this.comboBoxRegion.TabIndex = 25;
            this.comboBoxRegion.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRegion_SelectedIndexChanged);
            // 
            // textBoxVotingTableName
            // 
            this.textBoxVotingTableName.Location = new System.Drawing.Point(324, 295);
            this.textBoxVotingTableName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxVotingTableName.Name = "textBoxVotingTableName";
            this.textBoxVotingTableName.Size = new System.Drawing.Size(160, 22);
            this.textBoxVotingTableName.TabIndex = 23;
            // 
            // listBoxVotingTable
            // 
            this.listBoxVotingTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxVotingTable.FormattingEnabled = true;
            this.listBoxVotingTable.ItemHeight = 25;
            this.listBoxVotingTable.Location = new System.Drawing.Point(59, 88);
            this.listBoxVotingTable.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxVotingTable.Name = "listBoxVotingTable";
            this.listBoxVotingTable.Size = new System.Drawing.Size(233, 379);
            this.listBoxVotingTable.TabIndex = 24;
            // 
            // buttonAddModify
            // 
            this.buttonAddModify.Location = new System.Drawing.Point(323, 439);
            this.buttonAddModify.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddModify.Name = "buttonAddModify";
            this.buttonAddModify.Size = new System.Drawing.Size(161, 28);
            this.buttonAddModify.TabIndex = 20;
            this.buttonAddModify.Text = "Adicionar/Modificar";
            this.buttonAddModify.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 213);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "CE:";
            // 
            // comboBoxCE
            // 
            this.comboBoxCE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCE.FormattingEnabled = true;
            this.comboBoxCE.Location = new System.Drawing.Point(324, 236);
            this.comboBoxCE.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCE.Name = "comboBoxCE";
            this.comboBoxCE.Size = new System.Drawing.Size(160, 24);
            this.comboBoxCE.TabIndex = 19;
            this.comboBoxCE.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCE_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 275);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nome:";
            // 
            // EditVotingTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 554);
            this.Controls.Add(this.textBoxRegistedVoters);
            this.Controls.Add(this.textBoxInvalidVotes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxSector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxRegion);
            this.Controls.Add(this.textBoxVotingTableName);
            this.Controls.Add(this.listBoxVotingTable);
            this.Controls.Add(this.buttonAddModify);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxCE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.buttonOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditVotingTable";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar mesas de voto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textBoxRegistedVoters;
        private System.Windows.Forms.TextBox textBoxInvalidVotes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.TextBox textBoxVotingTableName;
        private System.Windows.Forms.ListBox listBoxVotingTable;
        private System.Windows.Forms.Button buttonAddModify;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCE;
        private System.Windows.Forms.Label label1;
    }
}
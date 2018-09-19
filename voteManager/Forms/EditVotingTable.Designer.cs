namespace VoteManager.Forms
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
            this.groupBoxEditVoting = new System.Windows.Forms.GroupBox();
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBoxEditVoting.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEditVoting
            // 
            this.groupBoxEditVoting.Controls.Add(this.label4);
            this.groupBoxEditVoting.Controls.Add(this.comboBoxSector);
            this.groupBoxEditVoting.Controls.Add(this.label2);
            this.groupBoxEditVoting.Controls.Add(this.comboBoxRegion);
            this.groupBoxEditVoting.Controls.Add(this.textBoxVotingTableName);
            this.groupBoxEditVoting.Controls.Add(this.listBoxVotingTable);
            this.groupBoxEditVoting.Controls.Add(this.buttonAddModify);
            this.groupBoxEditVoting.Controls.Add(this.label3);
            this.groupBoxEditVoting.Controls.Add(this.comboBoxCE);
            this.groupBoxEditVoting.Controls.Add(this.label1);
            this.groupBoxEditVoting.Location = new System.Drawing.Point(25, 19);
            this.groupBoxEditVoting.Name = "groupBoxEditVoting";
            this.groupBoxEditVoting.Size = new System.Drawing.Size(356, 390);
            this.groupBoxEditVoting.TabIndex = 3;
            this.groupBoxEditVoting.TabStop = false;
            this.groupBoxEditVoting.Text = "Edit voting:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sector:";
            // 
            // comboBoxSector
            // 
            this.comboBoxSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSector.FormattingEnabled = true;
            this.comboBoxSector.Location = new System.Drawing.Point(197, 114);
            this.comboBoxSector.Name = "comboBoxSector";
            this.comboBoxSector.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSector.TabIndex = 11;
            this.comboBoxSector.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSector_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Region:";
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(197, 59);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRegion.TabIndex = 9;
            this.comboBoxRegion.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRegion_SelectedIndexChanged);
            // 
            // textBoxVotingTableName
            // 
            this.textBoxVotingTableName.Location = new System.Drawing.Point(197, 216);
            this.textBoxVotingTableName.Name = "textBoxVotingTableName";
            this.textBoxVotingTableName.Size = new System.Drawing.Size(121, 20);
            this.textBoxVotingTableName.TabIndex = 8;
            // 
            // listBoxVotingTable
            // 
            this.listBoxVotingTable.FormattingEnabled = true;
            this.listBoxVotingTable.Location = new System.Drawing.Point(27, 38);
            this.listBoxVotingTable.Name = "listBoxVotingTable";
            this.listBoxVotingTable.Size = new System.Drawing.Size(147, 316);
            this.listBoxVotingTable.TabIndex = 8;
            this.listBoxVotingTable.SelectedIndexChanged += new System.EventHandler(this.ListBoxVotingTable_SelectedIndexChanged);
            // 
            // buttonAddModify
            // 
            this.buttonAddModify.Location = new System.Drawing.Point(197, 257);
            this.buttonAddModify.Name = "buttonAddModify";
            this.buttonAddModify.Size = new System.Drawing.Size(121, 23);
            this.buttonAddModify.TabIndex = 4;
            this.buttonAddModify.Text = "Add/Modify";
            this.buttonAddModify.UseVisualStyleBackColor = true;
            this.buttonAddModify.Click += new System.EventHandler(this.ButtonAddModify_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "CE:";
            // 
            // comboBoxCE
            // 
            this.comboBoxCE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCE.FormattingEnabled = true;
            this.comboBoxCE.Location = new System.Drawing.Point(197, 165);
            this.comboBoxCE.Name = "comboBoxCE";
            this.comboBoxCE.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCE.TabIndex = 3;
            this.comboBoxCE.SelectedIndexChanged += new System.EventHandler(this.comboBoxCE_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Voting table:";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(277, 415);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(104, 23);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // EditVotingTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 450);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxEditVoting);
            this.Name = "EditVotingTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditVotingTable";
            this.groupBoxEditVoting.ResumeLayout(false);
            this.groupBoxEditVoting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxEditVoting;
        private System.Windows.Forms.TextBox textBoxVotingTableName;
        private System.Windows.Forms.ListBox listBoxVotingTable;
        private System.Windows.Forms.Button buttonAddModify;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSector;
    }
}
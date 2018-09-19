namespace VoteManager.Forms
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
            this.linkLabelPoweredByBigTech = new System.Windows.Forms.LinkLabel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPartidoLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(319, 396);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(114, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // checkedListBoxPartidos
            // 
            this.checkedListBoxPartidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxPartidos.FormattingEnabled = true;
            this.checkedListBoxPartidos.Location = new System.Drawing.Point(24, 27);
            this.checkedListBoxPartidos.Name = "checkedListBoxPartidos";
            this.checkedListBoxPartidos.Size = new System.Drawing.Size(170, 364);
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
            this.groupBox2.Location = new System.Drawing.Point(212, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 364);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Partido infos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Partido logo:";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(119, 271);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 14;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(27, 60);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(168, 20);
            this.textBoxName.TabIndex = 7;
            // 
            // pictureBoxPartidoLogo
            // 
            this.pictureBoxPartidoLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPartidoLogo.Location = new System.Drawing.Point(26, 107);
            this.pictureBoxPartidoLogo.Name = "pictureBoxPartidoLogo";
            this.pictureBoxPartidoLogo.Size = new System.Drawing.Size(168, 154);
            this.pictureBoxPartidoLogo.TabIndex = 4;
            this.pictureBoxPartidoLogo.TabStop = false;
            // 
            // buttonAddModify
            // 
            this.buttonAddModify.Location = new System.Drawing.Point(27, 310);
            this.buttonAddModify.Name = "buttonAddModify";
            this.buttonAddModify.Size = new System.Drawing.Size(167, 23);
            this.buttonAddModify.TabIndex = 9;
            this.buttonAddModify.Text = "Add/Modify";
            this.buttonAddModify.UseVisualStyleBackColor = true;
            // 
            // linkLabelPoweredByBigTech
            // 
            this.linkLabelPoweredByBigTech.AutoSize = true;
            this.linkLabelPoweredByBigTech.Location = new System.Drawing.Point(21, 401);
            this.linkLabelPoweredByBigTech.Name = "linkLabelPoweredByBigTech";
            this.linkLabelPoweredByBigTech.Size = new System.Drawing.Size(151, 13);
            this.linkLabelPoweredByBigTech.TabIndex = 11;
            this.linkLabelPoweredByBigTech.TabStop = true;
            this.linkLabelPoweredByBigTech.Text = "Powered by: Big-Technologies";
            // 
            // EditPartidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 423);
            this.Controls.Add(this.linkLabelPoweredByBigTech);
            this.Controls.Add(this.checkedListBoxPartidos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonOK);
            this.Name = "EditPartidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ManagePredefinedData";
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
        private System.Windows.Forms.LinkLabel linkLabelPoweredByBigTech;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label2;
    }
}
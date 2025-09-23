namespace EchoPlayManager
{
    partial class ApksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApksForm));
            dataGridView1 = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            download = new DataGridViewButtonColumn();
            versionLbl = new Label();
            statusLabel = new Label();
            versionTxtBox = new TextBox();
            statusTxtBox = new TextBox();
            fileLbl = new Label();
            selectFileBttn = new Button();
            uploadBttn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { name, download });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(220, 309);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            name.HeaderText = "Nombre";
            name.Name = "name";
            name.Width = 76;
            // 
            // download
            // 
            download.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            download.HeaderText = "Descargar";
            download.Name = "download";
            download.Width = 65;
            // 
            // versionLbl
            // 
            versionLbl.AutoSize = true;
            versionLbl.Location = new Point(285, 132);
            versionLbl.Name = "versionLbl";
            versionLbl.Size = new Size(48, 15);
            versionLbl.TabIndex = 1;
            versionLbl.Text = "Versión:";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(12, 369);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(45, 15);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "Estado:";
            // 
            // versionTxtBox
            // 
            versionTxtBox.Location = new Point(339, 129);
            versionTxtBox.Name = "versionTxtBox";
            versionTxtBox.Size = new Size(100, 23);
            versionTxtBox.TabIndex = 3;
            // 
            // statusTxtBox
            // 
            statusTxtBox.Location = new Point(56, 353);
            statusTxtBox.Multiline = true;
            statusTxtBox.Name = "statusTxtBox";
            statusTxtBox.ReadOnly = true;
            statusTxtBox.Size = new Size(383, 45);
            statusTxtBox.TabIndex = 4;
            // 
            // fileLbl
            // 
            fileLbl.AutoSize = true;
            fileLbl.Location = new Point(306, 205);
            fileLbl.Name = "fileLbl";
            fileLbl.Size = new Size(0, 15);
            fileLbl.TabIndex = 5;
            // 
            // selectFileBttn
            // 
            selectFileBttn.Location = new Point(295, 168);
            selectFileBttn.Name = "selectFileBttn";
            selectFileBttn.Size = new Size(124, 23);
            selectFileBttn.TabIndex = 6;
            selectFileBttn.Text = "Seleccionar Archivo";
            selectFileBttn.UseVisualStyleBackColor = true;
            selectFileBttn.Click += selectFileBttn_Click;
            // 
            // uploadBttn
            // 
            uploadBttn.Location = new Point(295, 235);
            uploadBttn.Name = "uploadBttn";
            uploadBttn.Size = new Size(124, 23);
            uploadBttn.TabIndex = 7;
            uploadBttn.Text = "Subir APK";
            uploadBttn.UseVisualStyleBackColor = true;
            uploadBttn.Click += uploadBttn_Click;
            // 
            // ApksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 410);
            Controls.Add(uploadBttn);
            Controls.Add(selectFileBttn);
            Controls.Add(fileLbl);
            Controls.Add(statusTxtBox);
            Controls.Add(versionTxtBox);
            Controls.Add(statusLabel);
            Controls.Add(versionLbl);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ApksForm";
            Text = "EchoPlayManager - APKs";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label versionLbl;
        private Label statusLabel;
        private TextBox versionTxtBox;
        private TextBox statusTxtBox;
        private Label fileLbl;
        private Button selectFileBttn;
        private Button uploadBttn;
        private DataGridViewTextBoxColumn name;
        private DataGridViewButtonColumn download;
    }
}
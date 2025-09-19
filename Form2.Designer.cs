namespace EchoPlayManager
{
    partial class SongsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongsForm));
            songsDataGridView = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            Artist = new DataGridViewTextBoxColumn();
            Cover = new DataGridViewTextBoxColumn();
            File = new DataGridViewTextBoxColumn();
            statusTextBox = new TextBox();
            statusLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)songsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // songsDataGridView
            // 
            songsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            songsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            songsDataGridView.Columns.AddRange(new DataGridViewColumn[] { Id, Title, Artist, Cover, File });
            songsDataGridView.Location = new Point(12, 12);
            songsDataGridView.Name = "songsDataGridView";
            songsDataGridView.Size = new Size(543, 359);
            songsDataGridView.TabIndex = 0;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // Title
            // 
            Title.HeaderText = "Titulo";
            Title.Name = "Title";
            Title.ReadOnly = true;
            // 
            // Artist
            // 
            Artist.HeaderText = "Artista";
            Artist.Name = "Artist";
            Artist.ReadOnly = true;
            // 
            // Cover
            // 
            Cover.HeaderText = "Carátula";
            Cover.Name = "Cover";
            Cover.ReadOnly = true;
            // 
            // File
            // 
            File.HeaderText = "Archivo";
            File.Name = "File";
            File.ReadOnly = true;
            // 
            // statusTextBox
            // 
            statusTextBox.Location = new Point(64, 377);
            statusTextBox.Multiline = true;
            statusTextBox.Name = "statusTextBox";
            statusTextBox.Size = new Size(491, 61);
            statusTextBox.TabIndex = 8;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(13, 399);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(45, 15);
            statusLabel.TabIndex = 7;
            statusLabel.Text = "Estado:";
            // 
            // SongsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(566, 450);
            Controls.Add(statusTextBox);
            Controls.Add(statusLabel);
            Controls.Add(songsDataGridView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SongsForm";
            Text = "EchoPlayManager - Songs";
            ((System.ComponentModel.ISupportInitialize)songsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView songsDataGridView;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Artist;
        private DataGridViewTextBoxColumn Cover;
        private DataGridViewTextBoxColumn File;
        private TextBox statusTextBox;
        private Label statusLabel;
    }
}
namespace EchoPlayManager
{
    partial class UsersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersForm));
            usersDataGridView = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            image = new DataGridViewTextBoxColumn();
            userDataGrpBox = new GroupBox();
            changeImageBttn = new Button();
            userPictureBox = new PictureBox();
            imageLabel = new Label();
            nameTextBox = new TextBox();
            idTextBox = new TextBox();
            nameLabel = new Label();
            idLabel = new Label();
            statusTextBox = new TextBox();
            statusLabel = new Label();
            modifyBttn = new Button();
            addUserBttn = new Button();
            deleteBttn = new Button();
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).BeginInit();
            userDataGrpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)userPictureBox).BeginInit();
            SuspendLayout();
            // 
            // usersDataGridView
            // 
            usersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersDataGridView.Columns.AddRange(new DataGridViewColumn[] { Id, name, image });
            usersDataGridView.Location = new Point(12, 12);
            usersDataGridView.Name = "usersDataGridView";
            usersDataGridView.Size = new Size(343, 454);
            usersDataGridView.TabIndex = 0;
            usersDataGridView.SelectionChanged += UsersDataGridView_SelectionChanged;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // name
            // 
            name.HeaderText = "Nombre";
            name.Name = "name";
            // 
            // image
            // 
            image.HeaderText = "Imagen";
            image.Name = "image";
            // 
            // userDataGrpBox
            // 
            userDataGrpBox.Controls.Add(changeImageBttn);
            userDataGrpBox.Controls.Add(userPictureBox);
            userDataGrpBox.Controls.Add(imageLabel);
            userDataGrpBox.Controls.Add(nameTextBox);
            userDataGrpBox.Controls.Add(idTextBox);
            userDataGrpBox.Controls.Add(nameLabel);
            userDataGrpBox.Controls.Add(idLabel);
            userDataGrpBox.Location = new Point(454, 12);
            userDataGrpBox.Name = "userDataGrpBox";
            userDataGrpBox.Size = new Size(243, 328);
            userDataGrpBox.TabIndex = 1;
            userDataGrpBox.TabStop = false;
            userDataGrpBox.Text = "Datos del usuario";
            // 
            // changeImageBttn
            // 
            changeImageBttn.Location = new Point(129, 289);
            changeImageBttn.Name = "changeImageBttn";
            changeImageBttn.Size = new Size(108, 23);
            changeImageBttn.TabIndex = 7;
            changeImageBttn.Text = "Cambiar Imagen";
            changeImageBttn.UseVisualStyleBackColor = true;
            // 
            // userPictureBox
            // 
            userPictureBox.Location = new Point(95, 143);
            userPictureBox.Name = "userPictureBox";
            userPictureBox.Size = new Size(142, 130);
            userPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            userPictureBox.TabIndex = 5;
            userPictureBox.TabStop = false;
            // 
            // imageLabel
            // 
            imageLabel.AutoSize = true;
            imageLabel.Location = new Point(24, 199);
            imageLabel.Name = "imageLabel";
            imageLabel.Size = new Size(50, 15);
            imageLabel.TabIndex = 4;
            imageLabel.Text = "Imagen:";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(121, 83);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(100, 23);
            nameTextBox.TabIndex = 3;
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(121, 41);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(100, 23);
            idTextBox.TabIndex = 2;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(24, 86);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(54, 15);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Nombre:";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(24, 44);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(20, 15);
            idLabel.TabIndex = 0;
            idLabel.Text = "Id:";
            // 
            // statusTextBox
            // 
            statusTextBox.Location = new Point(432, 405);
            statusTextBox.Multiline = true;
            statusTextBox.Name = "statusTextBox";
            statusTextBox.Size = new Size(280, 61);
            statusTextBox.TabIndex = 5;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(381, 427);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(45, 15);
            statusLabel.TabIndex = 4;
            statusLabel.Text = "Estado:";
            // 
            // modifyBttn
            // 
            modifyBttn.Location = new Point(533, 358);
            modifyBttn.Name = "modifyBttn";
            modifyBttn.Size = new Size(86, 23);
            modifyBttn.TabIndex = 8;
            modifyBttn.Text = "Modificar";
            modifyBttn.UseVisualStyleBackColor = true;
            modifyBttn.Click += modifyBttn_Click;
            // 
            // addUserBttn
            // 
            addUserBttn.Location = new Point(441, 358);
            addUserBttn.Name = "addUserBttn";
            addUserBttn.Size = new Size(86, 23);
            addUserBttn.TabIndex = 9;
            addUserBttn.Text = "Crear";
            addUserBttn.UseVisualStyleBackColor = true;
            addUserBttn.Click += addUserBttn_Click;
            // 
            // deleteBttn
            // 
            deleteBttn.Location = new Point(625, 358);
            deleteBttn.Name = "deleteBttn";
            deleteBttn.Size = new Size(86, 23);
            deleteBttn.TabIndex = 10;
            deleteBttn.Text = "Eliminar";
            deleteBttn.UseVisualStyleBackColor = true;
            deleteBttn.Click += deleteBttn_Click;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 478);
            Controls.Add(deleteBttn);
            Controls.Add(addUserBttn);
            Controls.Add(modifyBttn);
            Controls.Add(statusTextBox);
            Controls.Add(userDataGrpBox);
            Controls.Add(statusLabel);
            Controls.Add(usersDataGridView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UsersForm";
            Text = "EchoPlayManager - Users";
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).EndInit();
            userDataGrpBox.ResumeLayout(false);
            userDataGrpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)userPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView usersDataGridView;
        private GroupBox userDataGrpBox;
        private Label nameLabel;
        private Label idLabel;
        private PictureBox userPictureBox;
        private Label imageLabel;
        private TextBox nameTextBox;
        private TextBox idTextBox;
        private TextBox statusTextBox;
        private Label statusLabel;
        private Button changeImageBttn;
        private Button modifyBttn;
        private Button addUserBttn;
        private Button deleteBttn;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn image;
    }
}
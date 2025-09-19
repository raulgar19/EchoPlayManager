namespace EchoPlayManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            usersManageBttn = new Button();
            songsManageBttn = new Button();
            pictureBox1 = new PictureBox();
            optionsGrpBox = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            optionsGrpBox.SuspendLayout();
            SuspendLayout();
            // 
            // usersManageBttn
            // 
            usersManageBttn.Location = new Point(35, 97);
            usersManageBttn.Name = "usersManageBttn";
            usersManageBttn.Size = new Size(128, 23);
            usersManageBttn.TabIndex = 1;
            usersManageBttn.Text = "Gestión de usuarios";
            usersManageBttn.UseVisualStyleBackColor = true;
            usersManageBttn.Click += usersManageBttn_Click;
            // 
            // songsManageBttn
            // 
            songsManageBttn.Location = new Point(35, 42);
            songsManageBttn.Name = "songsManageBttn";
            songsManageBttn.Size = new Size(128, 23);
            songsManageBttn.TabIndex = 0;
            songsManageBttn.Text = "Gestión de canciones";
            songsManageBttn.UseVisualStyleBackColor = true;
            songsManageBttn.Click += songsManageBttn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.ChatGPT_Image_17_sept_2025__23_20_20;
            pictureBox1.Location = new Point(29, 236);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(271, 265);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // optionsGrpBox
            // 
            optionsGrpBox.Controls.Add(songsManageBttn);
            optionsGrpBox.Controls.Add(usersManageBttn);
            optionsGrpBox.Location = new Point(63, 42);
            optionsGrpBox.Name = "optionsGrpBox";
            optionsGrpBox.Size = new Size(200, 151);
            optionsGrpBox.TabIndex = 5;
            optionsGrpBox.TabStop = false;
            optionsGrpBox.Text = "Opciones";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 527);
            Controls.Add(optionsGrpBox);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "EchoPlayManager - Main";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            optionsGrpBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button songsManageBttn;
        private PictureBox pictureBox1;
        private Button usersManageBttn;
        private GroupBox optionsGrpBox;
    }
}

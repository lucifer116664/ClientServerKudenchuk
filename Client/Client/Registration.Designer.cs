namespace Client
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            this.CreateAccountButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.QuitButton = new System.Windows.Forms.Button();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.AuthoriseButton = new System.Windows.Forms.Button();
            this.ShowPictureBox = new System.Windows.Forms.PictureBox();
            this.HidePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HidePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateAccountButton
            // 
            this.CreateAccountButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.CreateAccountButton.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateAccountButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CreateAccountButton.Location = new System.Drawing.Point(309, 268);
            this.CreateAccountButton.Name = "CreateAccountButton";
            this.CreateAccountButton.Size = new System.Drawing.Size(182, 53);
            this.CreateAccountButton.TabIndex = 12;
            this.CreateAccountButton.Text = "Create";
            this.CreateAccountButton.UseVisualStyleBackColor = false;
            this.CreateAccountButton.Click += new System.EventHandler(this.CreateAccountButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Modern No. 20", 18F);
            this.PasswordTextBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.PasswordTextBox.Location = new System.Drawing.Point(309, 209);
            this.PasswordTextBox.Multiline = true;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(182, 53);
            this.PasswordTextBox.TabIndex = 11;
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.QuitButton.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.QuitButton.Location = new System.Drawing.Point(703, 12);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(85, 42);
            this.QuitButton.TabIndex = 10;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Font = new System.Drawing.Font("Modern No. 20", 18F);
            this.LoginTextBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LoginTextBox.Location = new System.Drawing.Point(309, 150);
            this.LoginTextBox.Multiline = true;
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(182, 53);
            this.LoginTextBox.TabIndex = 9;
            // 
            // AuthoriseButton
            // 
            this.AuthoriseButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.AuthoriseButton.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthoriseButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AuthoriseButton.Location = new System.Drawing.Point(12, 355);
            this.AuthoriseButton.Name = "AuthoriseButton";
            this.AuthoriseButton.Size = new System.Drawing.Size(192, 83);
            this.AuthoriseButton.TabIndex = 8;
            this.AuthoriseButton.Text = "I already have account";
            this.AuthoriseButton.UseVisualStyleBackColor = false;
            this.AuthoriseButton.Click += new System.EventHandler(this.AuthoriseButton_Click);
            // 
            // ShowPictureBox
            // 
            this.ShowPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ShowPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ShowPictureBox.Image")));
            this.ShowPictureBox.Location = new System.Drawing.Point(497, 209);
            this.ShowPictureBox.Name = "ShowPictureBox";
            this.ShowPictureBox.Size = new System.Drawing.Size(53, 53);
            this.ShowPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPictureBox.TabIndex = 13;
            this.ShowPictureBox.TabStop = false;
            this.ShowPictureBox.Click += new System.EventHandler(this.ShowPictureBox_Click);
            // 
            // HidePictureBox
            // 
            this.HidePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.HidePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("HidePictureBox.Image")));
            this.HidePictureBox.Location = new System.Drawing.Point(497, 209);
            this.HidePictureBox.Name = "HidePictureBox";
            this.HidePictureBox.Size = new System.Drawing.Size(53, 53);
            this.HidePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HidePictureBox.TabIndex = 14;
            this.HidePictureBox.TabStop = false;
            this.HidePictureBox.Click += new System.EventHandler(this.HidePictureBox_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShowPictureBox);
            this.Controls.Add(this.HidePictureBox);
            this.Controls.Add(this.CreateAccountButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.AuthoriseButton);
            this.Name = "Registration";
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.Registration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ShowPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HidePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateAccountButton;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Button AuthoriseButton;
        private System.Windows.Forms.PictureBox ShowPictureBox;
        private System.Windows.Forms.PictureBox HidePictureBox;
    }
}
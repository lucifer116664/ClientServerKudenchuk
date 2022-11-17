namespace Client
{
    partial class Authorisation
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorisation));
            this.CreateAccButton = new System.Windows.Forms.Button();
            this.LoginTextbox = new System.Windows.Forms.TextBox();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.QuitButton = new System.Windows.Forms.Button();
            this.LogInButton = new System.Windows.Forms.Button();
            this.ShowPictureBox = new System.Windows.Forms.PictureBox();
            this.HidePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HidePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateAccButton
            // 
            this.CreateAccButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.CreateAccButton.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateAccButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CreateAccButton.Location = new System.Drawing.Point(12, 396);
            this.CreateAccButton.Name = "CreateAccButton";
            this.CreateAccButton.Size = new System.Drawing.Size(240, 42);
            this.CreateAccButton.TabIndex = 2;
            this.CreateAccButton.Text = "I have no account";
            this.CreateAccButton.UseVisualStyleBackColor = false;
            this.CreateAccButton.Click += new System.EventHandler(this.CreateAccButton_Click);
            // 
            // LoginTextbox
            // 
            this.LoginTextbox.Font = new System.Drawing.Font("Modern No. 20", 18F);
            this.LoginTextbox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LoginTextbox.Location = new System.Drawing.Point(305, 151);
            this.LoginTextbox.Multiline = true;
            this.LoginTextbox.Name = "LoginTextbox";
            this.LoginTextbox.Size = new System.Drawing.Size(182, 53);
            this.LoginTextbox.TabIndex = 4;
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Font = new System.Drawing.Font("Modern No. 20", 18F);
            this.PasswordTextbox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.PasswordTextbox.Location = new System.Drawing.Point(305, 210);
            this.PasswordTextbox.Multiline = true;
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(182, 53);
            this.PasswordTextbox.TabIndex = 6;
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.QuitButton.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.QuitButton.Location = new System.Drawing.Point(703, 12);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(85, 42);
            this.QuitButton.TabIndex = 8;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // LogInButton
            // 
            this.LogInButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.LogInButton.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogInButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LogInButton.Location = new System.Drawing.Point(305, 269);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(182, 53);
            this.LogInButton.TabIndex = 10;
            this.LogInButton.Text = "Log in";
            this.LogInButton.UseVisualStyleBackColor = false;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // ShowPictureBox
            // 
            this.ShowPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ShowPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ShowPictureBox.Image")));
            this.ShowPictureBox.Location = new System.Drawing.Point(493, 269);
            this.ShowPictureBox.Name = "ShowPictureBox";
            this.ShowPictureBox.Size = new System.Drawing.Size(53, 53);
            this.ShowPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPictureBox.TabIndex = 11;
            this.ShowPictureBox.TabStop = false;
            this.ShowPictureBox.Click += new System.EventHandler(this.ShowPictureBox_Click);
            // 
            // HidePictureBox
            // 
            this.HidePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.HidePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("HidePictureBox.Image")));
            this.HidePictureBox.Location = new System.Drawing.Point(493, 269);
            this.HidePictureBox.Name = "HidePictureBox";
            this.HidePictureBox.Size = new System.Drawing.Size(53, 53);
            this.HidePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HidePictureBox.TabIndex = 12;
            this.HidePictureBox.TabStop = false;
            this.HidePictureBox.Click += new System.EventHandler(this.HidePictureBox_Click);
            // 
            // Authorisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShowPictureBox);
            this.Controls.Add(this.HidePictureBox);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.LoginTextbox);
            this.Controls.Add(this.CreateAccButton);
            this.Name = "Authorisation";
            this.Text = "Authorisation";
            this.Load += new System.EventHandler(this.Authorisation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ShowPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HidePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateAccButton;
        private System.Windows.Forms.TextBox LoginTextbox;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.PictureBox ShowPictureBox;
        private System.Windows.Forms.PictureBox HidePictureBox;
    }
}


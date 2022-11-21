namespace Client
{
    partial class FindDoctor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindDoctor));
            this.BackButton = new System.Windows.Forms.Button();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.DoctorNameTextBox = new System.Windows.Forms.TextBox();
            this.FindDoctorButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.BackButton.Font = new System.Drawing.Font("Modern No. 20", 20F);
            this.BackButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BackButton.Location = new System.Drawing.Point(12, 11);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(50, 50);
            this.BackButton.TabIndex = 28;
            this.BackButton.Text = "<";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Modern No. 20", 20F);
            this.LoginLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LoginLabel.Location = new System.Drawing.Point(12, 405);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(97, 35);
            this.LoginLabel.TabIndex = 22;
            this.LoginLabel.Text = "Login";
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.QuitButton.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.QuitButton.Location = new System.Drawing.Point(703, 11);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(85, 50);
            this.QuitButton.TabIndex = 21;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // DoctorNameTextBox
            // 
            this.DoctorNameTextBox.Font = new System.Drawing.Font("Modern No. 20", 18F);
            this.DoctorNameTextBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.DoctorNameTextBox.Location = new System.Drawing.Point(306, 188);
            this.DoctorNameTextBox.Multiline = true;
            this.DoctorNameTextBox.Name = "DoctorNameTextBox";
            this.DoctorNameTextBox.Size = new System.Drawing.Size(182, 53);
            this.DoctorNameTextBox.TabIndex = 29;
            // 
            // FindDoctorButton
            // 
            this.FindDoctorButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.FindDoctorButton.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindDoctorButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FindDoctorButton.Location = new System.Drawing.Point(306, 247);
            this.FindDoctorButton.Name = "FindDoctorButton";
            this.FindDoctorButton.Size = new System.Drawing.Size(182, 53);
            this.FindDoctorButton.TabIndex = 30;
            this.FindDoctorButton.Text = "Find";
            this.FindDoctorButton.UseVisualStyleBackColor = false;
            this.FindDoctorButton.Click += new System.EventHandler(this.FindDoctorButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 20F);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(268, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 35);
            this.label1.TabIndex = 31;
            this.label1.Text = "Doctor`s surname:";
            // 
            // FindDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FindDoctorButton);
            this.Controls.Add(this.DoctorNameTextBox);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.QuitButton);
            this.Name = "FindDoctor";
            this.Text = "When the Doctor is busy";
            this.Load += new System.EventHandler(this.FindDoctor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.TextBox DoctorNameTextBox;
        private System.Windows.Forms.Button FindDoctorButton;
        private System.Windows.Forms.Label label1;
    }
}
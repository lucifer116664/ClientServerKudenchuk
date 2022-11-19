namespace Client
{
    partial class Cabinet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cabinet));
            this.LoginLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.FindDoctorButton = new System.Windows.Forms.Button();
            this.RegisterVisitButton = new System.Windows.Forms.Button();
            this.CancelVisitButton = new System.Windows.Forms.Button();
            this.MedicalHistoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Modern No. 20", 20F);
            this.LoginLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LoginLabel.Location = new System.Drawing.Point(12, 406);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(97, 35);
            this.LoginLabel.TabIndex = 1;
            this.LoginLabel.Text = "Login";
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.QuitButton.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.QuitButton.Location = new System.Drawing.Point(703, 12);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(85, 42);
            this.QuitButton.TabIndex = 11;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // FindDoctorButton
            // 
            this.FindDoctorButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.FindDoctorButton.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindDoctorButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FindDoctorButton.Location = new System.Drawing.Point(80, 127);
            this.FindDoctorButton.Name = "FindDoctorButton";
            this.FindDoctorButton.Size = new System.Drawing.Size(246, 81);
            this.FindDoctorButton.TabIndex = 12;
            this.FindDoctorButton.Text = "Find the doctor";
            this.FindDoctorButton.UseVisualStyleBackColor = false;
            this.FindDoctorButton.Click += new System.EventHandler(this.FindDoctorButton_Click);
            // 
            // RegisterVisitButton
            // 
            this.RegisterVisitButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.RegisterVisitButton.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterVisitButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.RegisterVisitButton.Location = new System.Drawing.Point(444, 127);
            this.RegisterVisitButton.Name = "RegisterVisitButton";
            this.RegisterVisitButton.Size = new System.Drawing.Size(246, 81);
            this.RegisterVisitButton.TabIndex = 13;
            this.RegisterVisitButton.Text = "Register to a visit";
            this.RegisterVisitButton.UseVisualStyleBackColor = false;
            this.RegisterVisitButton.Click += new System.EventHandler(this.RegisterVisitButton_Click);
            // 
            // CancelVisitButton
            // 
            this.CancelVisitButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.CancelVisitButton.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelVisitButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelVisitButton.Location = new System.Drawing.Point(444, 270);
            this.CancelVisitButton.Name = "CancelVisitButton";
            this.CancelVisitButton.Size = new System.Drawing.Size(246, 81);
            this.CancelVisitButton.TabIndex = 14;
            this.CancelVisitButton.Text = "Cancel the visit";
            this.CancelVisitButton.UseVisualStyleBackColor = false;
            this.CancelVisitButton.Click += new System.EventHandler(this.CancelVisitButton_Click);
            // 
            // MedicalHistoryButton
            // 
            this.MedicalHistoryButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.MedicalHistoryButton.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MedicalHistoryButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MedicalHistoryButton.Location = new System.Drawing.Point(80, 270);
            this.MedicalHistoryButton.Name = "MedicalHistoryButton";
            this.MedicalHistoryButton.Size = new System.Drawing.Size(246, 81);
            this.MedicalHistoryButton.TabIndex = 15;
            this.MedicalHistoryButton.Text = "My medical history";
            this.MedicalHistoryButton.UseVisualStyleBackColor = false;
            this.MedicalHistoryButton.Click += new System.EventHandler(this.MedicalHistoryButton_Click);
            // 
            // Cabinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MedicalHistoryButton);
            this.Controls.Add(this.CancelVisitButton);
            this.Controls.Add(this.RegisterVisitButton);
            this.Controls.Add(this.FindDoctorButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.LoginLabel);
            this.Name = "Cabinet";
            this.Text = "Cabinet";
            this.Load += new System.EventHandler(this.Cabinet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button FindDoctorButton;
        private System.Windows.Forms.Button RegisterVisitButton;
        private System.Windows.Forms.Button CancelVisitButton;
        private System.Windows.Forms.Button MedicalHistoryButton;
    }
}
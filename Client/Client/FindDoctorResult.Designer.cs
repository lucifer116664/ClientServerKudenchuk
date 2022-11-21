namespace Client
{
    partial class FindDoctorResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindDoctorResult));
            this.DoctorTextBox = new System.Windows.Forms.TextBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DoctorTextBox
            // 
            this.DoctorTextBox.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoctorTextBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.DoctorTextBox.Location = new System.Drawing.Point(55, 95);
            this.DoctorTextBox.Multiline = true;
            this.DoctorTextBox.Name = "DoctorTextBox";
            this.DoctorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DoctorTextBox.Size = new System.Drawing.Size(696, 281);
            this.DoctorTextBox.TabIndex = 34;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.BackButton.Font = new System.Drawing.Font("Modern No. 20", 20F);
            this.BackButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BackButton.Location = new System.Drawing.Point(12, 11);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(50, 50);
            this.BackButton.TabIndex = 33;
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
            this.LoginLabel.TabIndex = 32;
            this.LoginLabel.Text = "Login";
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.QuitButton.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.QuitButton.Location = new System.Drawing.Point(703, 12);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(85, 50);
            this.QuitButton.TabIndex = 35;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(68, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 30);
            this.label1.TabIndex = 36;
            this.label1.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(317, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 30);
            this.label3.TabIndex = 38;
            this.label3.Text = "Date and time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(197, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 30);
            this.label2.TabIndex = 40;
            this.label2.Text = "Cabinet";
            // 
            // FindDoctorResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.DoctorTextBox);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.LoginLabel);
            this.Name = "FindDoctorResult";
            this.Text = "When the doctor is busy";
            this.Load += new System.EventHandler(this.FindDoctorResult_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox DoctorTextBox;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
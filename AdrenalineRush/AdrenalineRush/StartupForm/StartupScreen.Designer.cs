namespace AdrenalineRush
{
    partial class StartupScreen
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
            this.grpResolution = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboSupportedResolutions = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkAntiAlias = new System.Windows.Forms.CheckBox();
            this.chkVSync = new System.Windows.Forms.CheckBox();
            this.chkFullscreen = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAspectRatio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpResolution.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpResolution
            // 
            this.grpResolution.Controls.Add(this.label1);
            this.grpResolution.Controls.Add(this.comboSupportedResolutions);
            this.grpResolution.Location = new System.Drawing.Point(6, 110);
            this.grpResolution.Name = "grpResolution";
            this.grpResolution.Size = new System.Drawing.Size(180, 35);
            this.grpResolution.TabIndex = 1;
            this.grpResolution.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Resolution:";
            // 
            // comboSupportedResolutions
            // 
            this.comboSupportedResolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSupportedResolutions.FormattingEnabled = true;
            this.comboSupportedResolutions.Location = new System.Drawing.Point(72, 8);
            this.comboSupportedResolutions.Name = "comboSupportedResolutions";
            this.comboSupportedResolutions.Size = new System.Drawing.Size(102, 21);
            this.comboSupportedResolutions.TabIndex = 7;
            this.comboSupportedResolutions.SelectedValueChanged += new System.EventHandler(this.comboSupportedResolutions_SelectedValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkAntiAlias);
            this.groupBox3.Controls.Add(this.chkVSync);
            this.groupBox3.Controls.Add(this.chkFullscreen);
            this.groupBox3.Location = new System.Drawing.Point(5, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(291, 35);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // chkAntiAlias
            // 
            this.chkAntiAlias.AutoSize = true;
            this.chkAntiAlias.Location = new System.Drawing.Point(187, 12);
            this.chkAntiAlias.Name = "chkAntiAlias";
            this.chkAntiAlias.Size = new System.Drawing.Size(69, 17);
            this.chkAntiAlias.TabIndex = 2;
            this.chkAntiAlias.Text = "Anti Alias";
            this.chkAntiAlias.UseVisualStyleBackColor = true;
            // 
            // chkVSync
            // 
            this.chkVSync.AutoSize = true;
            this.chkVSync.Location = new System.Drawing.Point(97, 12);
            this.chkVSync.Name = "chkVSync";
            this.chkVSync.Size = new System.Drawing.Size(57, 17);
            this.chkVSync.TabIndex = 1;
            this.chkVSync.Text = "VSync";
            this.chkVSync.UseVisualStyleBackColor = true;
            // 
            // chkFullscreen
            // 
            this.chkFullscreen.AutoSize = true;
            this.chkFullscreen.Location = new System.Drawing.Point(7, 12);
            this.chkFullscreen.Name = "chkFullscreen";
            this.chkFullscreen.Size = new System.Drawing.Size(74, 17);
            this.chkFullscreen.TabIndex = 0;
            this.chkFullscreen.Text = "Fullscreen";
            this.chkFullscreen.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(5, 186);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Go!";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(221, 186);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AdrenalineRush.StartupForm.ResourceForm.StartupLogo1;
            this.pictureBox1.Location = new System.Drawing.Point(6, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.grpResolution);
            this.groupBox2.Controls.Add(this.btnOK);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(5, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 216);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAspectRatio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(192, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 35);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lblAspectRatio
            // 
            this.lblAspectRatio.AutoSize = true;
            this.lblAspectRatio.Location = new System.Drawing.Point(73, 13);
            this.lblAspectRatio.Name = "lblAspectRatio";
            this.lblAspectRatio.Size = new System.Drawing.Size(16, 13);
            this.lblAspectRatio.TabIndex = 1;
            this.lblAspectRatio.Text = "   ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Aspect Ratio:";
            // 
            // StartupScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 225);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartupScreen";
            this.ShowIcon = false;
            this.Text = "Starglazers 2011";
            this.Load += new System.EventHandler(this.StartupScreen_Load);
            this.grpResolution.ResumeLayout(false);
            this.grpResolution.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grpResolution;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkAntiAlias;
        private System.Windows.Forms.CheckBox chkVSync;
        private System.Windows.Forms.CheckBox chkFullscreen;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboSupportedResolutions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAspectRatio;
    }
}
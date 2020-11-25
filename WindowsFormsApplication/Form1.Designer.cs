namespace WindowsFormsApplication
{
    partial class Form1
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
            this.pictureBox_Main = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_Pencil = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar_Scale = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar_Contrast = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_AdjustColors = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar_Brightness = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar_Rotate = new System.Windows.Forms.TrackBar();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.openImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveImageFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxImagePreview = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox_Main)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar_Scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar_Contrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar_AdjustColors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar_Brightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar_Rotate)).BeginInit();
            this.groupBoxImagePreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_Main
            // 
            this.pictureBox_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Main.Location = new System.Drawing.Point(3, 18);
            this.pictureBox_Main.Name = "pictureBox_Main";
            this.pictureBox_Main.Size = new System.Drawing.Size(777, 604);
            this.pictureBox_Main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_Main.TabIndex = 0;
            this.pictureBox_Main.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBox_Pencil);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.trackBar_Scale);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.trackBar_Contrast);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.trackBar_AdjustColors);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.trackBar_Brightness);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.trackBar_Rotate);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Location = new System.Drawing.Point(801, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 625);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit";
            // 
            // checkBox_Pencil
            // 
            this.checkBox_Pencil.Location = new System.Drawing.Point(12, 547);
            this.checkBox_Pencil.Name = "checkBox_Pencil";
            this.checkBox_Pencil.Size = new System.Drawing.Size(104, 24);
            this.checkBox_Pencil.TabIndex = 12;
            this.checkBox_Pencil.Text = "Pencil";
            this.checkBox_Pencil.UseVisualStyleBackColor = true;
            this.checkBox_Pencil.CheckedChanged += new System.EventHandler(this.checkBox_Pencil_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 430);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(182, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Scale";
            // 
            // trackBar_Scale
            // 
            this.trackBar_Scale.Location = new System.Drawing.Point(6, 456);
            this.trackBar_Scale.Maximum = 20;
            this.trackBar_Scale.Minimum = 5;
            this.trackBar_Scale.Name = "trackBar_Scale";
            this.trackBar_Scale.Size = new System.Drawing.Size(188, 56);
            this.trackBar_Scale.TabIndex = 10;
            this.trackBar_Scale.Tag = "";
            this.trackBar_Scale.Value = 10;
            this.trackBar_Scale.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_Scale_MouseUp);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 345);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(182, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Contrast";
            // 
            // trackBar_Contrast
            // 
            this.trackBar_Contrast.Location = new System.Drawing.Point(6, 371);
            this.trackBar_Contrast.Maximum = 100;
            this.trackBar_Contrast.Minimum = -100;
            this.trackBar_Contrast.Name = "trackBar_Contrast";
            this.trackBar_Contrast.Size = new System.Drawing.Size(188, 56);
            this.trackBar_Contrast.TabIndex = 8;
            this.trackBar_Contrast.Tag = "";
            this.trackBar_Contrast.TickFrequency = 10;
            this.trackBar_Contrast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_Contrast_MouseUp);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 260);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(182, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Adjust image colors";
            // 
            // trackBar_AdjustColors
            // 
            this.trackBar_AdjustColors.Location = new System.Drawing.Point(6, 286);
            this.trackBar_AdjustColors.Maximum = 360;
            this.trackBar_AdjustColors.Name = "trackBar_AdjustColors";
            this.trackBar_AdjustColors.Size = new System.Drawing.Size(188, 56);
            this.trackBar_AdjustColors.TabIndex = 6;
            this.trackBar_AdjustColors.Tag = "";
            this.trackBar_AdjustColors.TickFrequency = 10;
            this.trackBar_AdjustColors.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_AdjustColors_MouseUp);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 175);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(182, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Brightness";
            // 
            // trackBar_Brightness
            // 
            this.trackBar_Brightness.Location = new System.Drawing.Point(6, 201);
            this.trackBar_Brightness.Maximum = 200;
            this.trackBar_Brightness.Minimum = -200;
            this.trackBar_Brightness.Name = "trackBar_Brightness";
            this.trackBar_Brightness.Size = new System.Drawing.Size(188, 56);
            this.trackBar_Brightness.SmallChange = 10;
            this.trackBar_Brightness.TabIndex = 4;
            this.trackBar_Brightness.Tag = "";
            this.trackBar_Brightness.TickFrequency = 5;
            this.trackBar_Brightness.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_Brightness_MouseUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(182, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rotate image";
            // 
            // trackBar_Rotate
            // 
            this.trackBar_Rotate.Location = new System.Drawing.Point(6, 116);
            this.trackBar_Rotate.Maximum = 180;
            this.trackBar_Rotate.Minimum = -180;
            this.trackBar_Rotate.Name = "trackBar_Rotate";
            this.trackBar_Rotate.Size = new System.Drawing.Size(188, 56);
            this.trackBar_Rotate.TabIndex = 2;
            this.trackBar_Rotate.Tag = "";
            this.trackBar_Rotate.TickFrequency = 15;
            this.trackBar_Rotate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_Rotate_MouseUp);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 53);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(188, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(6, 21);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(188, 26);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // openImageFileDialog
            // 
            this.openImageFileDialog.Filter = "Image files(*.png)|*.png|All files(*.*)|*.*";
            // 
            // saveImageFileDialog
            // 
            this.saveImageFileDialog.Filter = "Image files(*.png)|*.png|All files(*.*)|*.*";
            // 
            // groupBoxImagePreview
            // 
            this.groupBoxImagePreview.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxImagePreview.Controls.Add(this.pictureBox_Main);
            this.groupBoxImagePreview.Location = new System.Drawing.Point(12, 12);
            this.groupBoxImagePreview.Name = "groupBoxImagePreview";
            this.groupBoxImagePreview.Size = new System.Drawing.Size(783, 625);
            this.groupBoxImagePreview.TabIndex = 2;
            this.groupBoxImagePreview.TabStop = false;
            this.groupBoxImagePreview.Text = "Image preview";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1013, 648);
            this.Controls.Add(this.groupBoxImagePreview);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox_Main)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar_Scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar_Contrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar_AdjustColors)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar_Brightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar_Rotate)).EndInit();
            this.groupBoxImagePreview.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TrackBar trackBar_Scale;

        private System.Windows.Forms.GroupBox groupBoxImagePreview;

        private System.Windows.Forms.OpenFileDialog openImageFileDialog;
        private System.Windows.Forms.SaveFileDialog saveImageFileDialog;

        private System.Windows.Forms.CheckBox checkBox_Pencil;
        private System.Windows.Forms.PictureBox pictureBox_Main;
        private System.Windows.Forms.TrackBar trackBar_AdjustColors;
        private System.Windows.Forms.TrackBar trackBar_Brightness;
        private System.Windows.Forms.TrackBar trackBar_Contrast;

        private System.Windows.Forms.TrackBar trackBar_Rotate;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;

        private System.Windows.Forms.GroupBox groupBox1;

        #endregion
    }
}
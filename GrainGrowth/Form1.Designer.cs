namespace GrainGrowth
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.XSizeBox = new System.Windows.Forms.TextBox();
            this.YSizeBox = new System.Windows.Forms.TextBox();
            this.XSizeLabel = new System.Windows.Forms.Label();
            this.YSizeLabel = new System.Windows.Forms.Label();
            this.NucleonAmountBox = new System.Windows.Forms.NumericUpDown();
            this.NAmountLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microstructureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Neighbornhood = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inclusionsInput = new System.Windows.Forms.TextBox();
            this.inclusions = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.boundaries = new System.Windows.Forms.Button();
            this.inclusionsSize = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NucleonAmountBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inclusionsSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox.Location = new System.Drawing.Point(62, 80);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(600, 460);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // XSizeBox
            // 
            this.XSizeBox.Location = new System.Drawing.Point(693, 80);
            this.XSizeBox.Name = "XSizeBox";
            this.XSizeBox.Size = new System.Drawing.Size(100, 20);
            this.XSizeBox.TabIndex = 1;
            this.XSizeBox.TextChanged += new System.EventHandler(this.XSizeBox_TextChanged);
            // 
            // YSizeBox
            // 
            this.YSizeBox.Location = new System.Drawing.Point(813, 80);
            this.YSizeBox.Name = "YSizeBox";
            this.YSizeBox.Size = new System.Drawing.Size(100, 20);
            this.YSizeBox.TabIndex = 2;
            this.YSizeBox.TextChanged += new System.EventHandler(this.YSizeBox_TextChanged);
            // 
            // XSizeLabel
            // 
            this.XSizeLabel.AutoSize = true;
            this.XSizeLabel.Location = new System.Drawing.Point(722, 51);
            this.XSizeLabel.Name = "XSizeLabel";
            this.XSizeLabel.Size = new System.Drawing.Size(37, 13);
            this.XSizeLabel.TabIndex = 3;
            this.XSizeLabel.Text = "X Size";
            // 
            // YSizeLabel
            // 
            this.YSizeLabel.AutoSize = true;
            this.YSizeLabel.Location = new System.Drawing.Point(876, 51);
            this.YSizeLabel.Name = "YSizeLabel";
            this.YSizeLabel.Size = new System.Drawing.Size(37, 13);
            this.YSizeLabel.TabIndex = 4;
            this.YSizeLabel.Text = "Y Size";
            // 
            // NucleonAmountBox
            // 
            this.NucleonAmountBox.Location = new System.Drawing.Point(794, 123);
            this.NucleonAmountBox.Name = "NucleonAmountBox";
            this.NucleonAmountBox.Size = new System.Drawing.Size(120, 20);
            this.NucleonAmountBox.TabIndex = 5;
            this.NucleonAmountBox.ValueChanged += new System.EventHandler(this.NucleonAmountBox_ValueChanged);
            // 
            // NAmountLabel
            // 
            this.NAmountLabel.AutoSize = true;
            this.NAmountLabel.Location = new System.Drawing.Point(690, 123);
            this.NAmountLabel.Name = "NAmountLabel";
            this.NAmountLabel.Size = new System.Drawing.Size(86, 13);
            this.NAmountLabel.TabIndex = 6;
            this.NAmountLabel.Text = "Nucleon Amount";
            this.NAmountLabel.Click += new System.EventHandler(this.NAmountLabel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1120, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.microstructureToolStripMenuItem,
            this.bitmapToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // microstructureToolStripMenuItem
            // 
            this.microstructureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.microstructureToolStripMenuItem.Name = "microstructureToolStripMenuItem";
            this.microstructureToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.microstructureToolStripMenuItem.Text = "Microstructure";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // bitmapToolStripMenuItem
            // 
            this.bitmapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem1,
            this.exportToolStripMenuItem1});
            this.bitmapToolStripMenuItem.Name = "bitmapToolStripMenuItem";
            this.bitmapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bitmapToolStripMenuItem.Text = "Bitmap";
            // 
            // importToolStripMenuItem1
            // 
            this.importToolStripMenuItem1.Name = "importToolStripMenuItem1";
            this.importToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem1.Text = "Import";
            this.importToolStripMenuItem1.Click += new System.EventHandler(this.importToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem1.Text = "Export";
            this.exportToolStripMenuItem1.Click += new System.EventHandler(this.exportToolStripMenuItem1_Click);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(718, 257);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateButton.TabIndex = 8;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(838, 257);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 9;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Neighbornhood
            // 
            this.Neighbornhood.FormattingEnabled = true;
            this.Neighbornhood.Items.AddRange(new object[] {
            "Moore",
            "von Neumann"});
            this.Neighbornhood.Location = new System.Drawing.Point(770, 210);
            this.Neighbornhood.Name = "Neighbornhood";
            this.Neighbornhood.Size = new System.Drawing.Size(121, 21);
            this.Neighbornhood.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(791, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Neighborhood";
            // 
            // inclusionsInput
            // 
            this.inclusionsInput.Location = new System.Drawing.Point(725, 398);
            this.inclusionsInput.Name = "inclusionsInput";
            this.inclusionsInput.Size = new System.Drawing.Size(100, 20);
            this.inclusionsInput.TabIndex = 14;
            // 
            // inclusions
            // 
            this.inclusions.Location = new System.Drawing.Point(863, 395);
            this.inclusions.Name = "inclusions";
            this.inclusions.Size = new System.Drawing.Size(75, 23);
            this.inclusions.TabIndex = 15;
            this.inclusions.Text = "Inclusions";
            this.inclusions.UseVisualStyleBackColor = true;
            this.inclusions.Click += new System.EventHandler(this.inclusions_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(863, 445);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 16;
            this.clearButton.Text = "Clear Grains";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // boundaries
            // 
            this.boundaries.Location = new System.Drawing.Point(717, 445);
            this.boundaries.Name = "boundaries";
            this.boundaries.Size = new System.Drawing.Size(112, 23);
            this.boundaries.TabIndex = 17;
            this.boundaries.Text = "Add Boundaries";
            this.boundaries.UseVisualStyleBackColor = true;
            this.boundaries.Click += new System.EventHandler(this.boundaries_Click);
            // 
            // inclusionsSize
            // 
            this.inclusionsSize.Location = new System.Drawing.Point(725, 325);
            this.inclusionsSize.Name = "inclusionsSize";
            this.inclusionsSize.Size = new System.Drawing.Size(104, 45);
            this.inclusionsSize.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(860, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Inclusion Size";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 749);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inclusionsSize);
            this.Controls.Add(this.boundaries);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.inclusions);
            this.Controls.Add(this.inclusionsInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Neighbornhood);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.NAmountLabel);
            this.Controls.Add(this.NucleonAmountBox);
            this.Controls.Add(this.YSizeLabel);
            this.Controls.Add(this.XSizeLabel);
            this.Controls.Add(this.YSizeBox);
            this.Controls.Add(this.XSizeBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Grain Growth";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NucleonAmountBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inclusionsSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox XSizeBox;
        private System.Windows.Forms.TextBox YSizeBox;
        private System.Windows.Forms.Label XSizeLabel;
        private System.Windows.Forms.Label YSizeLabel;
        private System.Windows.Forms.NumericUpDown NucleonAmountBox;
        private System.Windows.Forms.Label NAmountLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem microstructureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.ToolStripMenuItem bitmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox Neighbornhood;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inclusionsInput;
        private System.Windows.Forms.Button inclusions;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button boundaries;
        private System.Windows.Forms.TrackBar inclusionsSize;
        private System.Windows.Forms.Label label2;
    }
}


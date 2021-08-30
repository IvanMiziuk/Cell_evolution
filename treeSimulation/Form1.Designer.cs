
namespace treeSimulation
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label8 = new System.Windows.Forms.Label();
            this.lBots = new System.Windows.Forms.Label();
            this.cbCamera = new System.Windows.Forms.CheckBox();
            this.cbGravity = new System.Windows.Forms.CheckBox();
            this.butHistoryAge = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudMaxValueGen = new System.Windows.Forms.NumericUpDown();
            this.nudGenLength = new System.Windows.Forms.NumericUpDown();
            this.lColorMode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lMinaAge = new System.Windows.Forms.Label();
            this.lMaxAge = new System.Windows.Forms.Label();
            this.butColor = new System.Windows.Forms.Button();
            this.butLoadWorld = new System.Windows.Forms.Button();
            this.butSaveImage = new System.Windows.Forms.Button();
            this.butStop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.butSave = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.butStart = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxValueGen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGenLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.lBots);
            this.splitContainer1.Panel1.Controls.Add(this.cbCamera);
            this.splitContainer1.Panel1.Controls.Add(this.cbGravity);
            this.splitContainer1.Panel1.Controls.Add(this.butHistoryAge);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.nudMaxValueGen);
            this.splitContainer1.Panel1.Controls.Add(this.nudGenLength);
            this.splitContainer1.Panel1.Controls.Add(this.lColorMode);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lMinaAge);
            this.splitContainer1.Panel1.Controls.Add(this.lMaxAge);
            this.splitContainer1.Panel1.Controls.Add(this.butColor);
            this.splitContainer1.Panel1.Controls.Add(this.butLoadWorld);
            this.splitContainer1.Panel1.Controls.Add(this.butSaveImage);
            this.splitContainer1.Panel1.Controls.Add(this.butStop);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.nudHeight);
            this.splitContainer1.Panel1.Controls.Add(this.nudWidth);
            this.splitContainer1.Panel1.Controls.Add(this.butSave);
            this.splitContainer1.Panel1.Controls.Add(this.label);
            this.splitContainer1.Panel1.Controls.Add(this.butStart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(591, 505);
            this.splitContainer1.SplitterDistance = 132;
            this.splitContainer1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "bots";
            // 
            // lBots
            // 
            this.lBots.AutoSize = true;
            this.lBots.Location = new System.Drawing.Point(90, 226);
            this.lBots.Name = "lBots";
            this.lBots.Size = new System.Drawing.Size(13, 13);
            this.lBots.TabIndex = 27;
            this.lBots.Text = "0";
            // 
            // cbCamera
            // 
            this.cbCamera.AutoSize = true;
            this.cbCamera.Checked = true;
            this.cbCamera.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCamera.Location = new System.Drawing.Point(15, 334);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(62, 17);
            this.cbCamera.TabIndex = 26;
            this.cbCamera.Text = "Camera";
            this.cbCamera.UseVisualStyleBackColor = true;
            // 
            // cbGravity
            // 
            this.cbGravity.AutoSize = true;
            this.cbGravity.Checked = true;
            this.cbGravity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGravity.Location = new System.Drawing.Point(15, 311);
            this.cbGravity.Name = "cbGravity";
            this.cbGravity.Size = new System.Drawing.Size(59, 17);
            this.cbGravity.TabIndex = 25;
            this.cbGravity.Text = "Gravity";
            this.cbGravity.UseVisualStyleBackColor = true;
            // 
            // butHistoryAge
            // 
            this.butHistoryAge.Location = new System.Drawing.Point(23, 282);
            this.butHistoryAge.Name = "butHistoryAge";
            this.butHistoryAge.Size = new System.Drawing.Size(75, 23);
            this.butHistoryAge.TabIndex = 23;
            this.butHistoryAge.Text = "Save Age";
            this.butHistoryAge.UseVisualStyleBackColor = true;
            this.butHistoryAge.Click += new System.EventHandler(this.butHistoryAge_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 396);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "max value gen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "genome length";
            // 
            // nudMaxValueGen
            // 
            this.nudMaxValueGen.Location = new System.Drawing.Point(80, 394);
            this.nudMaxValueGen.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMaxValueGen.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudMaxValueGen.Name = "nudMaxValueGen";
            this.nudMaxValueGen.Size = new System.Drawing.Size(50, 20);
            this.nudMaxValueGen.TabIndex = 20;
            this.nudMaxValueGen.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // nudGenLength
            // 
            this.nudGenLength.Location = new System.Drawing.Point(80, 368);
            this.nudGenLength.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudGenLength.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudGenLength.Name = "nudGenLength";
            this.nudGenLength.Size = new System.Drawing.Size(50, 20);
            this.nudGenLength.TabIndex = 19;
            this.nudGenLength.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // lColorMode
            // 
            this.lColorMode.AutoSize = true;
            this.lColorMode.Location = new System.Drawing.Point(47, 109);
            this.lColorMode.Name = "lColorMode";
            this.lColorMode.Size = new System.Drawing.Size(82, 13);
            this.lColorMode.TabIndex = 18;
            this.lColorMode.Text = "Bot take energy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Color:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "middle age";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "max age";
            // 
            // lMinaAge
            // 
            this.lMinaAge.AutoSize = true;
            this.lMinaAge.Location = new System.Drawing.Point(91, 266);
            this.lMinaAge.Name = "lMinaAge";
            this.lMinaAge.Size = new System.Drawing.Size(13, 13);
            this.lMinaAge.TabIndex = 13;
            this.lMinaAge.Text = "0";
            // 
            // lMaxAge
            // 
            this.lMaxAge.AutoSize = true;
            this.lMaxAge.Location = new System.Drawing.Point(91, 243);
            this.lMaxAge.Name = "lMaxAge";
            this.lMaxAge.Size = new System.Drawing.Size(13, 13);
            this.lMaxAge.TabIndex = 12;
            this.lMaxAge.Text = "0";
            // 
            // butColor
            // 
            this.butColor.Location = new System.Drawing.Point(23, 83);
            this.butColor.Name = "butColor";
            this.butColor.Size = new System.Drawing.Size(75, 23);
            this.butColor.TabIndex = 11;
            this.butColor.Text = "Next color";
            this.butColor.UseVisualStyleBackColor = true;
            this.butColor.Click += new System.EventHandler(this.butColor_Click);
            // 
            // butLoadWorld
            // 
            this.butLoadWorld.Location = new System.Drawing.Point(62, 189);
            this.butLoadWorld.Name = "butLoadWorld";
            this.butLoadWorld.Size = new System.Drawing.Size(61, 23);
            this.butLoadWorld.TabIndex = 10;
            this.butLoadWorld.Text = "Load";
            this.butLoadWorld.UseVisualStyleBackColor = true;
            this.butLoadWorld.Visible = false;
            this.butLoadWorld.Click += new System.EventHandler(this.butLoadWorld_Click_1);
            // 
            // butSaveImage
            // 
            this.butSaveImage.Location = new System.Drawing.Point(23, 54);
            this.butSaveImage.Name = "butSaveImage";
            this.butSaveImage.Size = new System.Drawing.Size(75, 23);
            this.butSaveImage.TabIndex = 9;
            this.butSaveImage.Text = "Save Image";
            this.butSaveImage.UseVisualStyleBackColor = true;
            this.butSaveImage.Click += new System.EventHandler(this.butSaveImage_Click);
            // 
            // butStop
            // 
            this.butStop.Location = new System.Drawing.Point(64, 12);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(55, 23);
            this.butStop.TabIndex = 7;
            this.butStop.Text = "Stop";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "heigth";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "width";
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(56, 163);
            this.nudHeight.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(73, 20);
            this.nudHeight.TabIndex = 4;
            this.nudHeight.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(56, 137);
            this.nudWidth.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(73, 20);
            this.nudWidth.TabIndex = 3;
            this.nudWidth.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(12, 189);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(50, 23);
            this.butSave.TabIndex = 2;
            this.butSave.Text = "Save";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Visible = false;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(47, 38);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(33, 13);
            this.label.TabIndex = 1;
            this.label.Text = "frame";
            // 
            // butStart
            // 
            this.butStart.Location = new System.Drawing.Point(12, 12);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(55, 23);
            this.butStart.TabIndex = 0;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(256, 256);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(591, 505);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Evolution";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxValueGen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGenLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.Button butSaveImage;
        private System.Windows.Forms.Button butLoadWorld;
        private System.Windows.Forms.Button butColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lMinaAge;
        private System.Windows.Forms.Label lMaxAge;
        private System.Windows.Forms.Label lColorMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudGenLength;
        private System.Windows.Forms.NumericUpDown nudMaxValueGen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butHistoryAge;
        private System.Windows.Forms.CheckBox cbGravity;
        private System.Windows.Forms.CheckBox cbCamera;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lBots;
    }
}


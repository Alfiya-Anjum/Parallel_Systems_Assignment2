namespace CirclePaintingSimulation
{
    partial class Form1
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
            lblWorkers = new TextBox();
            cbWorkerCount = new ComboBox();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblWorkers
            // 
            lblWorkers.Location = new Point(21, 12);
            lblWorkers.Name = "lblWorkers";
            lblWorkers.Size = new Size(212, 31);
            lblWorkers.TabIndex = 0;
            lblWorkers.Text = "Please add no. of workers";
            lblWorkers.TextChanged += lblWorkers_TextChanged;
            // 
            // cbWorkerCount
            // 
            cbWorkerCount.FormattingEnabled = true;
            cbWorkerCount.Location = new Point(265, 10);
            cbWorkerCount.Name = "cbWorkerCount";
            cbWorkerCount.Size = new Size(50, 33);
            cbWorkerCount.TabIndex = 1;
            cbWorkerCount.SelectedIndexChanged += cbWorkerCount_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(455, 12);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 2;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(44, 70);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1162, 411);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1278, 493);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(cbWorkerCount);
            Controls.Add(lblWorkers);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox lblWorkers;
        private ComboBox cbWorkerCount;
        private Button button1;
        private PictureBox pictureBox1;
    }
}

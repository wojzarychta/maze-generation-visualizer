namespace Maze
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
            this.components = new System.ComponentModel.Container();
            this.createButton = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.solveButton = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.slideBar = new System.Windows.Forms.TrackBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelMinimumValue = new System.Windows.Forms.Label();
            this.labelMaximumValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.slideBar)).BeginInit();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(246, 774);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(126, 46);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "Create maze";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(141, 135);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(600, 600);
            this.panel.TabIndex = 1;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // solveButton
            // 
            this.solveButton.Enabled = false;
            this.solveButton.Location = new System.Drawing.Point(523, 774);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(126, 46);
            this.solveButton.TabIndex = 3;
            this.solveButton.Text = "Solve maze";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label.Location = new System.Drawing.Point(141, 44);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(191, 47);
            this.label.TabIndex = 4;
            this.label.Text = "Size: 29x29";
            // 
            // slideBar
            // 
            this.slideBar.Location = new System.Drawing.Point(391, 46);
            this.slideBar.Maximum = 49;
            this.slideBar.Minimum = 9;
            this.slideBar.Name = "slideBar";
            this.slideBar.Size = new System.Drawing.Size(350, 45);
            this.slideBar.SmallChange = 2;
            this.slideBar.TabIndex = 5;
            this.slideBar.TickFrequency = 2;
            this.slideBar.Value = 29;
            this.slideBar.ValueChanged += new System.EventHandler(this.slideBar_ValueChanged);
            // 
            // timer
            // 
            this.timer.Interval = 30;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labelMinimumValue
            // 
            this.labelMinimumValue.AutoSize = true;
            this.labelMinimumValue.Location = new System.Drawing.Point(391, 76);
            this.labelMinimumValue.Name = "labelMinimumValue";
            this.labelMinimumValue.Size = new System.Drawing.Size(13, 15);
            this.labelMinimumValue.TabIndex = 6;
            this.labelMinimumValue.Text = "9";
            // 
            // labelMaximumValue
            // 
            this.labelMaximumValue.AutoSize = true;
            this.labelMaximumValue.Location = new System.Drawing.Point(722, 76);
            this.labelMaximumValue.Name = "labelMaximumValue";
            this.labelMaximumValue.Size = new System.Drawing.Size(19, 15);
            this.labelMaximumValue.TabIndex = 7;
            this.labelMaximumValue.Text = "49";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(884, 861);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.labelMaximumValue);
            this.Controls.Add(this.labelMinimumValue);
            this.Controls.Add(this.slideBar);
            this.Controls.Add(this.label);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.slideBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button createButton;
        private Panel panel;
        private Button solveButton;
        private Label label;
        private TrackBar slideBar;
        private System.Windows.Forms.Timer timer;
        private Label labelMinimumValue;
        private Label labelMaximumValue;
    }
}
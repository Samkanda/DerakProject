
namespace DurakClient
{
    partial class Launcher
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
            this.btnStart = new System.Windows.Forms.Button();
            this.numComputers = new System.Windows.Forms.NumericUpDown();
            this.numHumans = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numComputers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHumans)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(440, 233);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(64, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // numComputers
            // 
            this.numComputers.Location = new System.Drawing.Point(440, 193);
            this.numComputers.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numComputers.Name = "numComputers";
            this.numComputers.Size = new System.Drawing.Size(64, 20);
            this.numComputers.TabIndex = 1;
            this.numComputers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numHumans
            // 
            this.numHumans.Location = new System.Drawing.Point(440, 152);
            this.numHumans.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numHumans.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHumans.Name = "numHumans";
            this.numHumans.Size = new System.Drawing.Size(64, 20);
            this.numHumans.TabIndex = 2;
            this.numHumans.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 273);
            this.Controls.Add(this.numHumans);
            this.Controls.Add(this.numComputers);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(544, 312);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(544, 312);
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            ((System.ComponentModel.ISupportInitialize)(this.numComputers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHumans)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown numComputers;
        private System.Windows.Forms.NumericUpDown numHumans;
    }
}
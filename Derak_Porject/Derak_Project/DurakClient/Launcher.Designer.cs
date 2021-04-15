
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
            this.lblGameTitle = new System.Windows.Forms.Label();
            this.lblHumanPlayers = new System.Windows.Forms.Label();
            this.lblComputerPlayers = new System.Windows.Forms.Label();
            this.cbPerevodnoyRule = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numComputers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHumans)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Neo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(33, 203);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(457, 43);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // numComputers
            // 
            this.numComputers.Font = new System.Drawing.Font("Neo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numComputers.Location = new System.Drawing.Point(344, 140);
            this.numComputers.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numComputers.Name = "numComputers";
            this.numComputers.Size = new System.Drawing.Size(146, 27);
            this.numComputers.TabIndex = 1;
            this.numComputers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numHumans
            // 
            this.numHumans.Font = new System.Drawing.Font("Neo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHumans.Location = new System.Drawing.Point(344, 100);
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
            this.numHumans.Size = new System.Drawing.Size(146, 27);
            this.numHumans.TabIndex = 2;
            this.numHumans.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblGameTitle
            // 
            this.lblGameTitle.AutoSize = true;
            this.lblGameTitle.Font = new System.Drawing.Font("Neo Sans", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameTitle.Location = new System.Drawing.Point(23, 23);
            this.lblGameTitle.Name = "lblGameTitle";
            this.lblGameTitle.Size = new System.Drawing.Size(485, 59);
            this.lblGameTitle.TabIndex = 3;
            this.lblGameTitle.Text = "Durak Game Launcher";
            this.lblGameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblHumanPlayers
            // 
            this.lblHumanPlayers.AutoSize = true;
            this.lblHumanPlayers.Font = new System.Drawing.Font("Neo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHumanPlayers.Location = new System.Drawing.Point(29, 102);
            this.lblHumanPlayers.Name = "lblHumanPlayers";
            this.lblHumanPlayers.Size = new System.Drawing.Size(255, 20);
            this.lblHumanPlayers.TabIndex = 4;
            this.lblHumanPlayers.Text = "Number of human players desired: ";
            // 
            // lblComputerPlayers
            // 
            this.lblComputerPlayers.AutoSize = true;
            this.lblComputerPlayers.Font = new System.Drawing.Font("Neo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComputerPlayers.Location = new System.Drawing.Point(29, 142);
            this.lblComputerPlayers.Name = "lblComputerPlayers";
            this.lblComputerPlayers.Size = new System.Drawing.Size(274, 20);
            this.lblComputerPlayers.TabIndex = 5;
            this.lblComputerPlayers.Text = "Number of computer players desired: ";
            // 
            // cbPerevodnoyRule
            // 
            this.cbPerevodnoyRule.AutoSize = true;
            this.cbPerevodnoyRule.Font = new System.Drawing.Font("Neo Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPerevodnoyRule.Location = new System.Drawing.Point(373, 173);
            this.cbPerevodnoyRule.Name = "cbPerevodnoyRule";
            this.cbPerevodnoyRule.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbPerevodnoyRule.Size = new System.Drawing.Size(117, 24);
            this.cbPerevodnoyRule.TabIndex = 6;
            this.cbPerevodnoyRule.Text = "Perevodnoy ";
            this.cbPerevodnoyRule.UseVisualStyleBackColor = true;
            this.cbPerevodnoyRule.CheckedChanged += new System.EventHandler(this.cbPerevodnoyRule_CheckedChanged);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 273);
            this.Controls.Add(this.cbPerevodnoyRule);
            this.Controls.Add(this.lblComputerPlayers);
            this.Controls.Add(this.lblHumanPlayers);
            this.Controls.Add(this.lblGameTitle);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown numComputers;
        private System.Windows.Forms.NumericUpDown numHumans;
        private System.Windows.Forms.Label lblGameTitle;
        private System.Windows.Forms.Label lblHumanPlayers;
        private System.Windows.Forms.Label lblComputerPlayers;
        private System.Windows.Forms.CheckBox cbPerevodnoyRule;
    }
}
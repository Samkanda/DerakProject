
namespace Derak_Project
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
            this.backgroundPictureBox = new System.Windows.Forms.PictureBox();
            this.button_play = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundPictureBox
            // 
            this.backgroundPictureBox.Image = global::Derak_Project.Properties.Resources.Durak_Background;
            this.backgroundPictureBox.Location = new System.Drawing.Point(0, 1);
            this.backgroundPictureBox.Name = "backgroundPictureBox";
            this.backgroundPictureBox.Size = new System.Drawing.Size(801, 444);
            this.backgroundPictureBox.TabIndex = 0;
            this.backgroundPictureBox.TabStop = false;
            // 
            // button_play
            // 
            this.button_play.Location = new System.Drawing.Point(329, 265);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(123, 49);
            this.button_play.TabIndex = 1;
            this.button_play.Text = "Play";
            this.button_play.UseVisualStyleBackColor = true;
            this.button_play.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_play);
            this.Controls.Add(this.backgroundPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox backgroundPictureBox;
        private System.Windows.Forms.Button button_play;
    }
}


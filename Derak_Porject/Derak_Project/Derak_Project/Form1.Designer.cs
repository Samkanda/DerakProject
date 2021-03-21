
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbBackground = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pbCardDisplay = new System.Windows.Forms.PictureBox();
            this.btnDealCards = new System.Windows.Forms.Button();
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.btnFirstCardTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBackground
            // 
            this.pbBackground.Image = ((System.Drawing.Image)(resources.GetObject("pbBackground.Image")));
            this.pbBackground.Location = new System.Drawing.Point(0, 1);
            this.pbBackground.Name = "pbBackground";
            this.pbBackground.Size = new System.Drawing.Size(801, 444);
            this.pbBackground.TabIndex = 0;
            this.pbBackground.TabStop = false;
            this.pbBackground.Visible = false;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(329, 265);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(123, 49);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // pbCardDisplay
            // 
            this.pbCardDisplay.Image = ((System.Drawing.Image)(resources.GetObject("pbCardDisplay.Image")));
            this.pbCardDisplay.Location = new System.Drawing.Point(12, 97);
            this.pbCardDisplay.Name = "pbCardDisplay";
            this.pbCardDisplay.Size = new System.Drawing.Size(84, 114);
            this.pbCardDisplay.TabIndex = 2;
            this.pbCardDisplay.TabStop = false;
            this.pbCardDisplay.Visible = false;
            // 
            // btnDealCards
            // 
            this.btnDealCards.Location = new System.Drawing.Point(12, 249);
            this.btnDealCards.Name = "btnDealCards";
            this.btnDealCards.Size = new System.Drawing.Size(123, 49);
            this.btnDealCards.TabIndex = 3;
            this.btnDealCards.Text = "Deal Cards";
            this.btnDealCards.UseVisualStyleBackColor = true;
            this.btnDealCards.Click += new System.EventHandler(this.btnDealCards_Click);
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Location = new System.Drawing.Point(679, 284);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(109, 83);
            this.btnEndTurn.TabIndex = 4;
            this.btnEndTurn.Text = "End turn";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            this.btnEndTurn.Visible = false;
            this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
            // 
            // btnFirstCardTest
            // 
            this.btnFirstCardTest.Location = new System.Drawing.Point(559, 284);
            this.btnFirstCardTest.Name = "btnFirstCardTest";
            this.btnFirstCardTest.Size = new System.Drawing.Size(101, 83);
            this.btnFirstCardTest.TabIndex = 5;
            this.btnFirstCardTest.Text = "play First card Test";
            this.btnFirstCardTest.UseVisualStyleBackColor = true;
            this.btnFirstCardTest.Visible = false;
            this.btnFirstCardTest.Click += new System.EventHandler(this.btnFirstCardTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFirstCardTest);
            this.Controls.Add(this.btnEndTurn);
            this.Controls.Add(this.btnDealCards);
            this.Controls.Add(this.pbCardDisplay);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pbBackground);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBackground;
        private System.Windows.Forms.Button btnPlay;

        private System.Windows.Forms.PictureBox pbCardDisplay;
        private System.Windows.Forms.Button btnDealCards;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.Button btnFirstCardTest;
    }
}


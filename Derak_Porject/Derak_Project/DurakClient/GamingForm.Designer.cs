
namespace DurakClient
{
    partial class GamingForm
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
            Derak_Project.Card card1 = new Derak_Project.Card();
            this.pbMyPictureBox = new System.Windows.Forms.PictureBox();
            this.pnlPlay = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlCardHome = new System.Windows.Forms.Panel();
            this.pbDeck = new CardBox1.CardBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMyPictureBox
            // 
            this.pbMyPictureBox.Location = new System.Drawing.Point(22, 176);
            this.pbMyPictureBox.Name = "pbMyPictureBox";
            this.pbMyPictureBox.Size = new System.Drawing.Size(68, 101);
            this.pbMyPictureBox.TabIndex = 0;
            this.pbMyPictureBox.TabStop = false;
            // 
            // pnlPlay
            // 
            this.pnlPlay.Location = new System.Drawing.Point(130, 39);
            this.pnlPlay.Name = "pnlPlay";
            this.pnlPlay.Size = new System.Drawing.Size(542, 100);
            this.pnlPlay.TabIndex = 2;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Location = new System.Drawing.Point(130, 176);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(542, 100);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(701, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlCardHome
            // 
            this.pnlCardHome.AllowDrop = true;
            this.pnlCardHome.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlCardHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardHome.Location = new System.Drawing.Point(130, 304);
            this.pnlCardHome.Name = "pnlCardHome";
            this.pnlCardHome.Size = new System.Drawing.Size(542, 119);
            this.pnlCardHome.TabIndex = 11;
            // 
            // pbDeck
            // 
            card1.FaceUp = false;
            card1.rank = Derak_Project.Rank.Eight;
            card1.suit = Derak_Project.Suit.Diamond;
            this.pbDeck.Card = card1;
            this.pbDeck.CardOrientation = System.Windows.Forms.Orientation.Vertical;
            this.pbDeck.FaceUp = false;
            this.pbDeck.Location = new System.Drawing.Point(22, 39);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Rank = Derak_Project.Rank.Eight;
            this.pbDeck.Size = new System.Drawing.Size(75, 107);
            this.pbDeck.Suit = Derak_Project.Suit.Diamond;
            this.pbDeck.TabIndex = 12;
            // 
            // GamingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbDeck);
            this.Controls.Add(this.pnlCardHome);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.pnlPlay);
            this.Controls.Add(this.pbMyPictureBox);
            this.Name = "GamingForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbMyPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMyPictureBox;
        private System.Windows.Forms.FlowLayoutPanel pnlPlay;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlCardHome;
        private CardBox1.CardBox pbDeck;
    }
}


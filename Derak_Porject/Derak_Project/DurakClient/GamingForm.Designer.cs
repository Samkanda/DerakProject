
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
            Derak_Project.Card card7 = new Derak_Project.Card();
            Derak_Project.Card card8 = new Derak_Project.Card();
            this.btnDebug = new System.Windows.Forms.Button();
            this.pnlCardHome = new System.Windows.Forms.Panel();
            this.pnlCardDefend = new System.Windows.Forms.Panel();
            this.pnlCardAttack = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtOpponent = new System.Windows.Forms.TextBox();
            this.txtDiscard = new System.Windows.Forms.TextBox();
            this.txtDeck = new System.Windows.Forms.TextBox();
            this.cardBox1 = new CardBox1.CardBox();
            this.pbDeck = new CardBox1.CardBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(701, 400);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 5;
            this.btnDebug.Text = "Debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlCardHome
            // 
            this.pnlCardHome.AllowDrop = true;
            this.pnlCardHome.BackColor = System.Drawing.Color.Green;
            this.pnlCardHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardHome.Location = new System.Drawing.Point(130, 319);
            this.pnlCardHome.Name = "pnlCardHome";
            this.pnlCardHome.Size = new System.Drawing.Size(542, 119);
            this.pnlCardHome.TabIndex = 11;
            // 
            // pnlCardDefend
            // 
            this.pnlCardDefend.AllowDrop = true;
            this.pnlCardDefend.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlCardDefend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardDefend.Location = new System.Drawing.Point(130, 176);
            this.pnlCardDefend.Name = "pnlCardDefend";
            this.pnlCardDefend.Size = new System.Drawing.Size(542, 119);
            this.pnlCardDefend.TabIndex = 12;
            this.pnlCardDefend.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pnlCardAttack
            // 
            this.pnlCardAttack.AllowDrop = true;
            this.pnlCardAttack.BackColor = System.Drawing.Color.Gold;
            this.pnlCardAttack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardAttack.Location = new System.Drawing.Point(130, 39);
            this.pnlCardAttack.Name = "pnlCardAttack";
            this.pnlCardAttack.Size = new System.Drawing.Size(542, 119);
            this.pnlCardAttack.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(701, 356);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "End Turn";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DurakClient.Properties.Resources.Red_back;
            this.pictureBox1.Location = new System.Drawing.Point(701, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // txtOpponent
            // 
            this.txtOpponent.Location = new System.Drawing.Point(678, 213);
            this.txtOpponent.Name = "txtOpponent";
            this.txtOpponent.Size = new System.Drawing.Size(119, 20);
            this.txtOpponent.TabIndex = 17;
            this.txtOpponent.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtDiscard
            // 
            this.txtDiscard.Location = new System.Drawing.Point(12, 213);
            this.txtDiscard.Name = "txtDiscard";
            this.txtDiscard.Size = new System.Drawing.Size(100, 20);
            this.txtDiscard.TabIndex = 18;
            // 
            // txtDeck
            // 
            this.txtDeck.Location = new System.Drawing.Point(12, 39);
            this.txtDeck.Name = "txtDeck";
            this.txtDeck.Size = new System.Drawing.Size(100, 20);
            this.txtDeck.TabIndex = 19;
            // 
            // cardBox1
            // 
            card7.FaceUp = false;
            card7.rank = Derak_Project.Rank.Eight;
            card7.suit = Derak_Project.Suit.Diamond;
            this.cardBox1.Card = card7;
            this.cardBox1.CardOrientation = System.Windows.Forms.Orientation.Vertical;
            this.cardBox1.FaceUp = false;
            this.cardBox1.Location = new System.Drawing.Point(22, 248);
            this.cardBox1.Name = "cardBox1";
            this.cardBox1.Rank = Derak_Project.Rank.Eight;
            this.cardBox1.Size = new System.Drawing.Size(75, 107);
            this.cardBox1.Suit = Derak_Project.Suit.Diamond;
            this.cardBox1.TabIndex = 15;
            // 
            // pbDeck
            // 
            card8.FaceUp = false;
            card8.rank = Derak_Project.Rank.Eight;
            card8.suit = Derak_Project.Suit.Diamond;
            this.pbDeck.Card = card8;
            this.pbDeck.CardOrientation = System.Windows.Forms.Orientation.Vertical;
            this.pbDeck.FaceUp = false;
            this.pbDeck.Location = new System.Drawing.Point(22, 75);
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
            this.Controls.Add(this.txtDeck);
            this.Controls.Add(this.txtDiscard);
            this.Controls.Add(this.txtOpponent);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cardBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pnlCardAttack);
            this.Controls.Add(this.pnlCardDefend);
            this.Controls.Add(this.pbDeck);
            this.Controls.Add(this.pnlCardHome);
            this.Controls.Add(this.btnDebug);
            this.Name = "GamingForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.Panel pnlCardHome;
        private System.Windows.Forms.Panel pnlCardDefend;
        private System.Windows.Forms.Panel pnlCardAttack;
        private System.Windows.Forms.Button button2;
        private CardBox1.CardBox pbDeck;
        private CardBox1.CardBox cardBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtOpponent;
        private System.Windows.Forms.TextBox txtDiscard;
        private System.Windows.Forms.TextBox txtDeck;
    }
}


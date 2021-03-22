
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
            Derak_Project.Card card2 = new Derak_Project.Card();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlCardHome = new System.Windows.Forms.Panel();
            this.pnlCardDefend = new System.Windows.Forms.Panel();
            this.pnlCardAttack = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.pbDeck = new CardBox1.CardBox();
            this.cbTalon = new CardBox1.CardBox();
            this.SuspendLayout();
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
            // cbTalon
            // 
            card2.FaceUp = false;
            card2.rank = Derak_Project.Rank.Eight;
            card2.suit = Derak_Project.Suit.Diamond;
            this.cbTalon.Card = card2;
            this.cbTalon.CardOrientation = System.Windows.Forms.Orientation.Vertical;
            this.cbTalon.FaceUp = false;
            this.cbTalon.Location = new System.Drawing.Point(22, 176);
            this.cbTalon.Name = "cbTalon";
            this.cbTalon.Rank = Derak_Project.Rank.Eight;
            this.cbTalon.Size = new System.Drawing.Size(75, 107);
            this.cbTalon.Suit = Derak_Project.Suit.Diamond;
            this.cbTalon.TabIndex = 14;
            this.cbTalon.MouseEnter += new System.EventHandler(this.CardBox_MouseEnter);
            this.cbTalon.MouseLeave += new System.EventHandler(this.CardBox_MouseLeave);
            // 
            // GamingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbTalon);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pnlCardAttack);
            this.Controls.Add(this.pnlCardDefend);
            this.Controls.Add(this.pbDeck);
            this.Controls.Add(this.pnlCardHome);
            this.Controls.Add(this.button1);
            this.Name = "GamingForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlCardHome;
        private CardBox1.CardBox pbDeck;
        private System.Windows.Forms.Panel pnlCardDefend;
        private System.Windows.Forms.Panel pnlCardAttack;
        private System.Windows.Forms.Button button2;
        private CardBox1.CardBox cbTalon;
    }
}


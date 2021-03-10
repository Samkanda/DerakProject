using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Derak_Project
{
    public partial class Form1 : Form
    {
        DurakGameController players = new DurakGameController();
        public Form1()
        {
            InitializeComponent();
            //original console test I had
            DurakDeck deck = new DurakDeck();
            
            players.Add(new DurakComputer());
            players.Add(new DurakComputer());
            players.Add(new DurakComputer());
            players.Add(new DurakHuman());
            
            deck.Shuffle();

            foreach (DurakHand player in players)
            {
                player.DrawToMinimum(deck);
                Console.WriteLine(player.ToString());
            }
            Hand.TurnEnded += delegate () { players.PassTurn(); };
            players.PassTurn();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundPictureBox.Image = Image.FromFile("../../images/PlayingBackground.jpg");
            backgroundPictureBox.Refresh();
            backgroundPictureBox.Visible = true;
            button_play.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            (players[3] as DurakHuman).EndTurn();
        }
    }
}

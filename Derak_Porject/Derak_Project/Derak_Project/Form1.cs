using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



// NOTE: dont write any game logic in here, its bad, write it in the classes.
namespace Derak_Project
{
    public partial class Form1 : Form
    {
        DurakGameController players = new DurakGameController();
        public Form1()
        {
            InitializeComponent();

            players.Add(new DurakComputer());
            players.Add(new DurakComputer());
            players.Add(new DurakComputer());
            players.Add(new DurakHuman());
            players.NewTurn();
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

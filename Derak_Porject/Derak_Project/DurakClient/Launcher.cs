using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakClient
{
    public partial class Launcher : Form
    {

        private GamingForm game;
        public bool perevodnoyBool;

        public Launcher()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if( numHumans.Value > 0 && numHumans.Value < 7 && numComputers.Value < 6)
            {
                if (numHumans.Value + numComputers.Value < 7 && numHumans.Value + numComputers.Value >= 2)
                {
                    game = new GamingForm((int)numHumans.Value, (int)numComputers.Value, (bool)perevodnoyBool);
                    game.ShowDialog();
                    this.Close();
                } 
                else
                {
                    MessageBox.Show("you have added too many players");
                }
            } else
            {
                MessageBox.Show("invalid game players setup");
            }
            
        }

        private void cbPerevodnoyRule_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPerevodnoyRule.Checked == true)
            {
                perevodnoyBool = true;
            }
            else
            {
                perevodnoyBool = false;
            }
        }
    }
}

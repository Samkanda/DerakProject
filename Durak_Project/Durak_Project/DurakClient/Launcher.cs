///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            Launcher
///   Description:      Launcher GUI to launch game with parameters
///   Authors:          Shoaib Ali, Luke Richards, Navpreet Kanda, Mubashir Malik
///   Card Img Source:  http://acbl.mybigcommerce.com/52-playing-cards/  
///   Date:             April 14, 2021
///---------------------------------------------------------------------------------
///
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
                    if (rad20.Checked)
                    {
                        if(numHumans.Value + numComputers.Value < 4)
                        {
                            game = new GamingForm((int)numHumans.Value, (int)numComputers.Value, cbPerevodnoyRule.Checked, 10);
                            game.ShowDialog();
                            this.Close();
                        } 
                        else
                        {
                            MessageBox.Show("a 20 card deck is not large enough for this many players");
                        }
                    }
                    else if (rad36.Checked)
                    {
                        game = new GamingForm((int)numHumans.Value, (int)numComputers.Value, cbPerevodnoyRule.Checked, 6);
                        game.ShowDialog();
                        this.Close();
                    }
                    else if (rad52.Checked)
                    {
                        game = new GamingForm((int)numHumans.Value, (int)numComputers.Value, cbPerevodnoyRule.Checked, 2);
                        game.ShowDialog();
                        this.Close();
                    }
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
    }
}

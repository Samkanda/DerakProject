﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundPictureBox.Image = Image.FromFile("../../images/PlayingBackground.jpg");
            backgroundPictureBox.Refresh();
            backgroundPictureBox.Visible = true;
            button_play.Visible = false;
        }
    }
}
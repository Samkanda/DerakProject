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
        public Form1()
        {
            InitializeComponent();
            pictures = new PictureBox[32];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundPictureBox.Image = Image.FromFile("../../images/PlayingBackground.jpg");
            backgroundPictureBox.Refresh();
            backgroundPictureBox.Visible = true;
            button_play.Visible = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
           
        }

        private void backgroundPictureBox_Click(object sender, EventArgs e)
        {

        }

        private PictureBox[] pictures;
        public const string imagePath = @"../../images/";
        private void btnDealCards_Click(object sender, EventArgs e)
        {
            CreateControls();
            DisplayControls();
        }

        private void CreateControls()
        {
            for (var counter = 0; counter < 6; counter++)
            {
                var newPictureBox = new PictureBox();
                newPictureBox.Width = 75;
                newPictureBox.Height = 100;
                pictures[counter] = SizeImage(newPictureBox, counter + 2);
            }
        }

        private PictureBox SizeImage(PictureBox pb, int i)
        {
            Image img = Image.FromFile(imagePath + i.ToString() + "C.jpg");
            pb.Image = img;
            pb.SizeMode = PictureBoxSizeMode.CenterImage;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            //pb.MouseClick = //function 
            return pb;
        }

        private void DisplayControls()
        {
            for (var counter = 0; counter < 5; counter ++)
            {
                pictures[counter].Left = ( counter * 10) + 100;
                this.Controls.Add(pictures[counter]);
            }
        }
    }
}

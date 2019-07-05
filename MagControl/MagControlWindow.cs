using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MagControl
{
    public partial class MagControlWindow: UserControl
    {
        Image currentImage = null;
        Point mouseOffset;
        Point mouseLocation;
        bool mouseIsDown = false;

        public void SetImage(Image image) {
            // border, probably temporary
            currentImage = image;

            this.pictureBox.Image = image;
            this.pictureBox.InitialImage = null;

            //int x = 0 - (image.Size.Width / 2);
            //int y = 0 - (image.Size.Height / 2);
            int x = (image.Size.Width / 2);
            int y = (image.Size.Height / 2);
            this.pictureBox.Location = new System.Drawing.Point(x, y);
            this.pictureBox.Location = new System.Drawing.Point(-50, -50);

            // this.pictureBox.Size = new System.Drawing.Size(109, 111);

            // this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // pictureBox.Left = 0 - image.Size.Width / 2;
            // pictureBox.Top = 0 - image.Size.Height / 2;
        }

        public MagControlWindow()
        {
            InitializeComponent();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                mouseIsDown = true;
                // mouse position relative to image
                mouseOffset = e.Location;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                mouseIsDown = false;
                mouseOffset = new Point(0, 0);
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
            if(mouseIsDown == true) {
                mouseLocation = e.Location;
                pictureBox.Invalidate();
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e) {
            e.Graphics.Clear(Color.Black);
            Point newMouseLocation = mouseLocation;
            newMouseLocation.X -= mouseOffset.X;
            newMouseLocation.Y -= mouseOffset.Y;
            e.Graphics.DrawImage(currentImage, newMouseLocation);
        }
    }
}

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
        MagSmartWindow smartWindow = null;

        public void SetImage(Image image) {
            currentImage = image;

            this.pictureBox.Image = image;

            smartWindow = new MagSmartWindow(image, this);
        }

        public MagControlWindow()
        {
            InitializeComponent();
            if(smartWindow != null)
                smartWindow.Hide();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
            if (smartWindow.Visible == true)
                return;

            // cords here are relative to this window
            if(e.Location.X < this.Size.Width && e.Location.Y < this.Size.Height) {
                Console.WriteLine("Showing smartWindow - MagControlWindow " + e.X + " " + e.Y);

                smartWindow.Show();
                smartWindow.TopMost = true;
                smartWindow.Capture = true;
            }
        }
    }
}

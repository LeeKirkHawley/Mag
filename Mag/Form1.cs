using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mag {
    public partial class Form1 : Form {

        Image loadedImage = null;

        public Form1() {
            InitializeComponent();

            //LoadImage("C:\\Work\\Mag\\images\\Plant.jpg");
            //this.magControlWindow1.SetImage(loadedImage);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                LoadImage(openFileDialog1.FileName);
                this.magControlWindow1.SetImage(loadedImage);
            }
        }

        private void LoadImage(string imagePath) {
            loadedImage = Image.FromFile(imagePath);
        }
    }
}

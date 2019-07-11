using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MagControl {
    public partial class MagSmartWindow : Form, IMessageFilter {
        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pt);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);


        public Control parent { get; set; }

        public Image currentImage { get; set; }
        public Size currentImageSize { get; set; } // size of the image we're going to draw
        float scaleRatio { // original image / image as drawn
            get {
                if (currentImage == null || currentImageSize.Width == 0)
                    return 0;
                return currentImage.Size.Width / currentImageSize.Width;
            }
        }

        Point mouseDownLocation;  // relative to window
        bool mouseIsDown = false;
        Point currentImageOrigin = new Point();

        public MagSmartWindow(Image image, Control parent) {
            InitializeComponent();

            Application.AddMessageFilter(this);

            currentImage = image;
            currentImageSize = image.Size;
            currentImageOrigin = new Point(0, 0); // relative to window
        }

        public bool PreFilterMessage(ref Message m) {
            if (m.Msg == 0x20a) {
                // WM_MOUSEWHEEL, find the control at screen position m.LParam
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                IntPtr hWnd = WindowFromPoint(pos);
                if (hWnd != IntPtr.Zero && hWnd != m.HWnd && Control.FromHandle(hWnd) != null) {
                    SendMessage(hWnd, m.Msg, m.WParam, m.LParam);

                    if (Visible == true)
                        OnMouseWheel(ref m);

                    return true;
                }
            }

            return false;
        }


        void OnMouseWheel(ref Message m) {
            Point cursorPosition = System.Windows.Forms.Cursor.Position;

            int delta = m.WParam.ToInt32() >> 16;

            Size size = currentImageSize;
            if (delta < 0) {
                size.Width = (int)((float)size.Width * .9);
                size.Height = (int)((float)size.Height *  .9);
            }
            else {
                size.Width = (int)((float)size.Width * 1.1);
                size.Height = (int)((float)size.Height * 1.1);
            }

            currentImageSize = size;

            magSmartPictureBox.Invalidate();
        }


        Point ImageToWindowCoords(Point imageCoords) {
            Point coords = new Point();

            coords.X = (int)((float)coords.X / scaleRatio);
            coords.Y = (int)((float)coords.Y / scaleRatio);

            return coords;
        }

        Point WindowCoordsToImageCoords(Point windowCoords) {
            Point coords = new Point();

            coords.X = (int)((float)windowCoords.X * scaleRatio);
            coords.Y = (int)((float)windowCoords.Y * scaleRatio);

            return coords;
        }

        // magSmartPicture event handlers

        private void magSmartPictureBox_Paint(object sender, PaintEventArgs e) {
            //Console.WriteLine("Painting smartWindow - MagSmartWindow");

            // get center of window
            Point windowCenter = new Point(this.Size.Width / 2, this.Size.Height / 2);

            Bitmap bmp = new Bitmap(currentImage, currentImageSize);

            //Console.WriteLine("SmartWindow window origin " + currentImageOrigin.X + " " + currentImageOrigin.Y);

            e.Graphics.Clear(Color.Black);
            e.Graphics.DrawImage(bmp, currentImageOrigin);

        }

        private void MouseMoveHandler(object sender, MouseEventArgs e) {

            if (mouseIsDown == true) {  // move image
                int deltaX = mouseDownLocation.X - e.Location.X;
                int deltaY = mouseDownLocation.Y - e.Location.Y;

                currentImageOrigin.X -= deltaX;
                currentImageOrigin.Y -= deltaY;

                mouseDownLocation.X = e.X;
                mouseDownLocation.Y = e.Y;

                magSmartPictureBox.Invalidate();
            }
            else {   // we've moved cursor outside of smart window bounds - hide it.
                if (e.Location.X < 0 || e.Location.X > this.Size.Width || e.Location.Y < 0 || e.Location.Y > this.Size.Height) {
                        // mouse is outside window
                        this.HideMe();
                }
            }
        }

        void HideMe() {
            this.Capture = false;
            this.Hide();
        }

        private void MouseDownHandler(object sender, MouseEventArgs e) {
            this.Capture = true;

            Console.WriteLine("Mouse Down");
            mouseIsDown = true;

            // mouse position relative to image
            mouseDownLocation = e.Location;
        }

        private void MouseUpHandler(object sender, MouseEventArgs e) {
            this.Capture = true;

            Console.WriteLine("Mouse Up");
            mouseIsDown = false;
            mouseDownLocation = new Point(0, 0);
        }

        private void VisibleChangedHandler(object sender, EventArgs e) {
            if (Visible == true) {
                Console.WriteLine("Showing smartWindow - MagSmartWindow ");
                this.Capture = true;
            }
            else {
                Console.WriteLine("Hiding smartWindow - MagSmartWindow ");
                this.Capture = false;
            }
        }

        private void MouseLeaveHandler(object sender, EventArgs e) {
            this.HideMe();
        }
    }
}

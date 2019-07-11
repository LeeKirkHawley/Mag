namespace MagControl {
    partial class MagSmartWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.magSmartPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.magSmartPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // magSmartPictureBox
            // 
            this.magSmartPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.magSmartPictureBox.Location = new System.Drawing.Point(-2, -1);
            this.magSmartPictureBox.Name = "magSmartPictureBox";
            this.magSmartPictureBox.Size = new System.Drawing.Size(524, 223);
            this.magSmartPictureBox.TabIndex = 0;
            this.magSmartPictureBox.TabStop = false;
            this.magSmartPictureBox.VisibleChanged += new System.EventHandler(this.VisibleChangedHandler);
            this.magSmartPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.magSmartPictureBox_Paint);
            this.magSmartPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownHandler);
            this.magSmartPictureBox.MouseLeave += new System.EventHandler(this.MouseLeaveHandler);
            this.magSmartPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveHandler);
            this.magSmartPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpHandler);
            // 
            // MagSmartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 220);
            this.ControlBox = false;
            this.Controls.Add(this.magSmartPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MagSmartWindow";
            this.Text = "MagSmartWindow";
            this.VisibleChanged += new System.EventHandler(this.VisibleChangedHandler);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownHandler);
            this.MouseLeave += new System.EventHandler(this.MouseLeaveHandler);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveHandler);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpHandler);
            ((System.ComponentModel.ISupportInitialize)(this.magSmartPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox magSmartPictureBox;
    }
}
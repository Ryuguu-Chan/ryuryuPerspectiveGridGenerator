using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing; // for draing lines (obviously)
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ryuryuPerspectiveGridGenerator
{
    public partial class Form1 : Form
    {
        public static int canvasWidth = 100;
        public static int canvasHeight = 100;

        private int mousePosX, mousePosY;

        public static int quantityTemp = 0;

        private Bitmap futureImage;

        public Form1()
        {

            sizeForm sf = new sizeForm();
            sf.ShowDialog();
            futureImage = new Bitmap(canvasWidth, canvasHeight);

            InitializeComponent();
            pictureBox1.Image = futureImage;


            this.Text = "ryuryuPerspectiveGridGenerator (made by Ogan Özkul aka Ryuguu Chan): " + canvasWidth + ";" + canvasHeight;
        }


        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void horizontalLineToolStripMenuItem_Click(object sender, EventArgs e)
        {

            float percentPanel1X = ((float)mousePosX / (float)pictureBox1.Width);
            float percentPanel1Y = ((float)mousePosY / (float)pictureBox1.Height);

            // drawing a horizontal line to the bitmap image
            using (Graphics g = Graphics.FromImage(futureImage))
            {
                g.DrawLine
                (
                    new Pen(Brushes.Black, 1),
                    (0), (percentPanel1Y * futureImage.Height),
                    (futureImage.Width), (percentPanel1Y * futureImage.Height)
                );
            }

            // re-render the thing
            pictureBox1.Image = futureImage;
        }

        private void lineWidthToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void vanishingPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float percentPanel1X = ((float)mousePosX / (float)pictureBox1.Width);
            float percentPanel1Y = ((float)mousePosY / (float)pictureBox1.Height);

            // making the quantity form window appear
            quantityForm x = new quantityForm();
            x.ShowDialog();
            x.Dispose();

            if (quantityTemp != 0)
            {

                // drawing a horizontal line to the bitmap image
                using (Graphics g = Graphics.FromImage(futureImage))
                {
                    // 100 -> temp
                    int step = quantityTemp;

                    // going from 0° to 360*2° (aka from nothing to full circle)
                    for (int i = 0; i < 360 * 2; i += step)
                    {
                        g.DrawLine
                        (
                            new Pen(Brushes.Red, 0.1f),
                            (percentPanel1X * futureImage.Width), (percentPanel1Y * futureImage.Height),
                            (percentPanel1X * futureImage.Width + (float)(Math.Cos(i) * futureImage.Width)) * 10,
                            (percentPanel1Y * futureImage.Height + (float)(Math.Sin(i) * futureImage.Height)) * 10
                        );
                    }
                }
            }

            pictureBox1.Image = futureImage;
            
            // reset it!
            quantityTemp = 0;
        }

        private void bunchOfHorizontalLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // making the quantity form window appear
            quantityForm x = new quantityForm();
            x.ShowDialog();
            x.Dispose();

            if (quantityTemp != 0)
            {
                // temp
                int step = quantityTemp;

                using (Graphics g = Graphics.FromImage(futureImage))
                {
                    // going from 0° to 360*2° (aka from nothing to full circle)
                    for (int i = 0; i < futureImage.Height; i += step)
                    {
                        g.DrawLine
                        (
                            new Pen(Brushes.Red, 1),
                            (0), (i),
                            (futureImage.Width), (i)
                        );
                    }
                }
            }    
            pictureBox1.Image = futureImage;
        }

        private void bunchOfHorizontalLinesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Export the image as...";
            sfd.Filter = "PNG file (*.png)|*.png";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                futureImage.Save(sfd.FileName, ImageFormat.Png);
                MessageBox.Show("Image Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Name:\tryuryuPerspectiveGridGenerator\nAuthor:\tOgan Özkul aka Ryuguu Chan\nVersion:\tBeta");
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Show(new Point((this.Location.X + pictureBox1.Location.X + e.X), (this.Location.Y + pictureBox1.Location.Y + e.Y)));
            mousePosX = e.X;
            mousePosY = e.Y;
        }

        private void defineResolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("By doing so. All the progression will be lost. Wanna make a new one?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // defining the resolution
                sizeForm canvasSize = new sizeForm();
                canvasSize.StartPosition = FormStartPosition.CenterScreen;
                canvasSize.ShowDialog();

                if (futureImage != null) { futureImage.Dispose(); } // removing it from the memory if already present

                futureImage = new Bitmap(canvasWidth, canvasHeight);
                pictureBox1.Image = futureImage;

                this.Text = "ryuryuPerspectiveGridGenerator (made by Ogan Özkul aka Ryuguu Chan): " + canvasWidth + ";" + canvasHeight;
            }
        }
    }
}

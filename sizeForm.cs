using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ryuryuPerspectiveGridGenerator
{
    public partial class sizeForm : Form
    {
        public sizeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if
            (
                !string.IsNullOrEmpty(widthTextBox.Text) &&
                !string.IsNullOrEmpty(heightTextBox.Text)
            )
            {
                // making sure that only numbers are allowed
                Regex regex = new Regex("[0-9]");

                // if the text doesn't match the regex pattern -> ERROR
                // otherwise -> it's ok!
                if
                (
                    regex.IsMatch(widthTextBox.Text) &&
                    regex.IsMatch(heightTextBox.Text)
                )
                {
                    Form1.canvasWidth = int.Parse(widthTextBox.Text);
                    Form1.canvasHeight = int.Parse(heightTextBox.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ONLY NUMBERS ARE ALLOWED!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("BOTH THE WIDTH AND HEIGHT MUST HAVE VALUE!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxChanged(object sender, EventArgs e)
        {
            
        }
    }
}

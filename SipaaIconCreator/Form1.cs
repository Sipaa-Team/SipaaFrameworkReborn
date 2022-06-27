using SipaaFrameworkReborn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SipaaIconCreator
{
    public partial class Form1 : SForm
    {
        public Bitmap CreateIcon(Color c1, Color c2, Image icon, float a)
        {
            Bitmap bmp = new Bitmap(128, 128);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                int r = 64;
                Rectangle crect = new Rectangle(0, 0, 128,128);
                GraphicsPath path = new GraphicsPath();
                g.SmoothingMode = SmoothingMode.HighQuality;
                path.AddArc(new Rectangle(0, 0, r, r), 180, 90);
                path.AddArc(new Rectangle(crect.Width - r, 0, r, r), -90, 90);
                path.AddArc(new Rectangle(crect.Width - r, crect.Height - r, r, r), 0, 90);
                path.AddArc(new Rectangle(0, crect.Height - r, r, r), 90, 90);
                g.FillPath(new LinearGradientBrush(crect, c1, c2, a), path);
                g.DrawImage(icon, new Point(crect.Width / 2 - icon.Width / 2, crect.Height / 2 - icon.Height / 2));
            }
            return bmp;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void title1_Load(object sender, EventArgs e)
        {

        }

        private void sButton2_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = c.Color;
            }
        }

        private void sButton3_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                panel2.BackColor = c.Color;
            }
        }

        private void sButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG files|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void sButton5_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = CreateIcon(panel1.BackColor, panel2.BackColor, pictureBox1.Image, (float)numericUpDown1.Value);
        }

        private void sButton6_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Filter = "128px PNG icon|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(ofd.FileName);
            }
        }

        private void sButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sButton7_Click(object sender, EventArgs e)
        {

        }
    }
}

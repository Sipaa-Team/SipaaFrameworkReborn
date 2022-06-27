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

namespace SipaaFrameworkReborn
{
    public partial class SForm : Form
    {
        private int bra = 20;

        public int BorderRadius
        {
            get { return bra; }
            set { bra = value; this.Invalidate(); }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        public SForm()
        {
            InitializeComponent();
            this.KeyDown += SForm_KeyDown;
        }

        private void SForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) { this.Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // High quality smoothing mode 
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // Draw the button base
            if (WindowState == FormWindowState.Normal)
            {
                //e.Graphics.Clear(Parent.BackColor);
                GraphicsPath path = new GraphicsPath();
                path.AddArc(new Rectangle(0, 0, bra, bra), 180, 90);
                path.AddArc(new Rectangle(Width - bra, 0, bra, bra), -90, 90);
                path.AddArc(new Rectangle(Width - bra, Height - bra, bra, bra), 0, 90);
                path.AddArc(new Rectangle(0, Height - bra, bra, bra), 90, 90);
                this.Region = new Region(path);
            }
        }
    }
}

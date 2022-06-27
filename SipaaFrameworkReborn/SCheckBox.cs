using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SipaaFrameworkReborn
{
    public class SCheckBox : UserControl
    {
        public SCheckBox()
        {
            this.Size = new Size(32, 32);
            this.Click += SCheckBox_Click;
        }

        private void SCheckBox_Click(object sender, EventArgs e)
        {
            if (!check) { check = true; } else { check = false; }
            if (CheckStateChanged != null) { CheckStateChanged.Invoke(this, new EventArgs()); }
            this.Invalidate();
        }

        private bool check;
        private bool blackcheck;
        private int bra = 20;
        public int BorderRadius
        {
            get { return bra; }
            set { bra = value; this.Invalidate(); }
        }
        public event EventHandler CheckStateChanged;
        public bool Checked { get { return check; } set { check = value; } }
        public bool BlackCheck { get { return blackcheck; } set { blackcheck = value; Invalidate(); } }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //Clear the Windows button graphics
            e.Graphics.Clear(Parent.BackColor);
            // Draw the button base
            GraphicsPath path = new GraphicsPath();
            path.AddArc(new Rectangle(0, 0, bra, bra), 180, 90);
            path.AddArc(new Rectangle(Width - bra, 0, bra, bra), -90, 90);
            path.AddArc(new Rectangle(Width - bra, Height - bra, bra, bra), 0, 90);
            path.AddArc(new Rectangle(0, Height - bra, bra, bra), 90, 90);
            e.Graphics.FillPath(new SolidBrush(BackColor), path);
            if (check)
            {
                Image img;
                if (!blackcheck) { img = SipaaFrameworkReborn.Properties.Resources.icons8_done_24px; } else { img = SipaaFrameworkReborn.Properties.Resources.icons8_done_24px_black; }
                e.Graphics.DrawImage(img, new Point(this.Width / 2 - img.Width / 2, this.Height / 2 - img.Height / 2));
            }
        }
    }
}

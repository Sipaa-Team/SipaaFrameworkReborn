using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SipaaFrameworkReborn
{
    public class SGradientButton : Button
    {
        int bra = 20;
        float a = 45;
        Timer t = new Timer();
        Color sbc = Color.Blue;
        public int BorderRadius
        {
            get { return bra; }
            set { bra = value; this.Invalidate(); }
        }
        public float Angle { get { return a; } }
        public Color SecondBackColor { get { return sbc; } set { sbc = value; Invalidate(); } }
        public SGradientButton() { BackColor = Color.White; ForeColor = Color.Black; Font = new Font("Segoe UI", 13, FontStyle.Bold);
            DoubleBuffered = true; 
            t.Interval = 60;
            t.Start();
            t.Tick += (s, e) =>
            {
                a = a % 360 + 1;
                this.Invalidate();
            };
         }
        static int GetFontWidth(int textlength, Font font)
        {
            return textlength * (int)font.Size;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw default button
            base.OnPaint(e);
            // High quality smoothing mode 
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //Clear the Windows button graphics
            e.Graphics.Clear(Parent.BackColor);
            // Draw the button base
            GraphicsPath path = new GraphicsPath();
            path.AddArc(new Rectangle(0, 0, bra, bra), 180, 90);
            path.AddArc(new Rectangle(Width - bra, 0, bra, bra), -90, 90);
            path.AddArc(new Rectangle(Width - bra, Height - bra, bra, bra), 0, 90);
            path.AddArc(new Rectangle(0, Height-bra, bra, bra), 90, 90);
            e.Graphics.FillPath(new LinearGradientBrush(ClientRectangle, BackColor, sbc, a), path);
            // Draw text with his font
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor),ClientRectangle, new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center } );
        }
    }
}

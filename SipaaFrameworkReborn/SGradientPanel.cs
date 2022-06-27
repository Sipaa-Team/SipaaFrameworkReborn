using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SipaaFrameworkReborn
{
    public class SGradientPanel : Panel
    {
        private int borderRadius = 6;

        float a = 45;

        Timer t = new Timer();
        Color sbc = Color.Blue;

        public float Angle { get { return a; } }
        public Color SecondBackColor { get { return sbc; } set { sbc = value; Invalidate(); } }

        //Constructor
        public SGradientPanel()
        {
            this.Size = new Size(150, 40);
            this.BackColor = Color.White;
            this.Resize += new EventHandler(Panel_Resize);
            DoubleBuffered = true;
            t.Interval = 60;
            t.Start();
            t.Tick += (s, e) =>
            {
                a = a % 360 + 1;
                this.Invalidate();
            };
        }

        private void Panel_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                borderRadius = this.Height;
        }

        //Methods
        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Rectangle rectSurface = this.ClientRectangle;
            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
            using (LinearGradientBrush penSurface = new LinearGradientBrush(ClientRectangle, BackColor, sbc, a))
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                //Button surface
                this.Region = new Region(pathSurface);
                //Draw surface border for HD result
                pevent.Graphics.FillPath(penSurface, pathSurface);
            }
        }

        [Category("Sipaa")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                this.Invalidate();
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            //this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
         }
    }
}

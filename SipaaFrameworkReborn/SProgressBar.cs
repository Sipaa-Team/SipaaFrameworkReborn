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
    public class SProgressBar : ProgressBar
    {//Fields
        //-> Appearance
        private Color channelColor = Color.LightSteelBlue;
        private Color sliderColor1 = Color.RoyalBlue;
        private Color sliderColor2 = Color.LightSkyBlue;
        private Color foreBackColor = Color.RoyalBlue;
        private string symbolBefore = "";
        private string symbolAfter = "";
        private bool showMaximun = false;
        private float borderRadius = 6;

        public float BorderRadius { get { return borderRadius; } set { borderRadius = value; Invalidate(); } }

        //-> Others
        private bool paintedBack = false;
        private bool stopPainting = false;

        //Constructor
        public SProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.ForeColor = Color.White;
        }

        public Color ChannelColor
        {
            get { return channelColor; }
            set
            {
                channelColor = value;
                this.Invalidate();
            }
        }
        public Color SliderSecondColor
        {
            get { return sliderColor2; }
            set
            {
                sliderColor2 = value;
                this.Invalidate();
            }
        }
        public Color SliderFirstColor
        {
            get { return sliderColor1; }
            set
            {
                sliderColor1 = value;
                this.Invalidate();
            }
        }

        public Color ForeBackColor
        {
            get { return foreBackColor; }
            set
            {
                foreBackColor = value;
                this.Invalidate();
            }
        }

        public string SymbolBefore
        {
            get { return symbolBefore; }
            set
            {
                symbolBefore = value;
                this.Invalidate();
            }
        }

        public string SymbolAfter
        {
            get { return symbolAfter; }
            set
            {
                symbolAfter = value;
                this.Invalidate();
            }
        }

        public bool ShowMaximun
        {
            get { return showMaximun; }
            set
            {
                showMaximun = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
            }
        }

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
            }
        }

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

        //-> Paint the background & channel
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (stopPainting == false)
            {
                if (paintedBack == false)
                {
                    //Fields
                    Graphics graph = pevent.Graphics;
                    Rectangle rectChannel = new Rectangle(0, 0, this.Width, this.Height);
                    var brushChannel = new SolidBrush(channelColor);
                    if (borderRadius < 2)
                    {
                        graph.FillRectangle(brushChannel, rectChannel);
                    }
                    else
                    {
                        GraphicsPath path = GetFigurePath(rectChannel, borderRadius);
                        {


                            //Painting
                            graph.SmoothingMode = SmoothingMode.HighQuality;
                            graph.Clear(this.Parent.BackColor);//Surface
                            graph.FillPath(brushChannel, path);//Channel

                            //Stop painting the back & Channel
                            if (this.DesignMode == false)
                                paintedBack = true;
                        }
                    }
                }
                //Reset painting the back & channel
                if (this.Value == this.Maximum || this.Value == this.Minimum)
                    paintedBack = false;
            }
        }
        //-> Paint slider
        protected override void OnPaint(PaintEventArgs e)
        {
            if (stopPainting == false)
            {
                //Fields
                Graphics graph = e.Graphics;
                graph.SmoothingMode = SmoothingMode.HighQuality;
                double scaleFactor = (((double)this.Value - this.Minimum) / ((double)this.Maximum - this.Minimum));
                int sliderWidth = (int)(this.Width * scaleFactor);
                Rectangle rectSlider = new Rectangle(0, 0, sliderWidth, this.Height);
                float a = 0;
                if (borderRadius < 2)
                {
                    graph.FillRectangle(new LinearGradientBrush(ClientRectangle, SliderFirstColor, SliderSecondColor, a), rectSlider);
                }
                else
                {
                    GraphicsPath path = GetFigurePath(rectSlider, borderRadius);
                    //Painting
                    if (sliderWidth > 1) //Slider
                        graph.FillPath(new LinearGradientBrush(ClientRectangle, SliderFirstColor, SliderSecondColor, a), path);
                }
            }
            if (this.Value == this.Maximum) stopPainting = true;//Stop painting
            else stopPainting = false; //Keep painting)
        }
    }
}

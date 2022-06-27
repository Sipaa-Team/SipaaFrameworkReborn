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
                    using (var brushChannel = new SolidBrush(channelColor))
                    {
                        

                        //Painting
                        graph.Clear(this.Parent.BackColor);//Surface
                        graph.FillRectangle(brushChannel, rectChannel);//Channel

                        //Stop painting the back & Channel
                        if (this.DesignMode == false)
                            paintedBack = true;
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
                double scaleFactor = (((double)this.Value - this.Minimum) / ((double)this.Maximum - this.Minimum));
                int sliderWidth = (int)(this.Width * scaleFactor);
                Rectangle rectSlider = new Rectangle(0, 0, sliderWidth, this.Height);
                float a = 0;
                //Painting
                if (sliderWidth > 1) //Slider
                    graph.FillRectangle(new LinearGradientBrush(ClientRectangle, SliderFirstColor, SliderSecondColor, a), rectSlider);
            }
            if (this.Value == this.Maximum) stopPainting = true;//Stop painting
            else stopPainting = false; //Keep painting)
        }
    }
}

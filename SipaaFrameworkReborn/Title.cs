using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SipaaFrameworkReborn
{
    public partial class Title : UserControl
    {
        string text = "Title";
        StringAlignment ha = StringAlignment.Near;
        StringAlignment va = StringAlignment.Near;
        public StringAlignment HorizontalAlignment
        {
            get { return ha; }
            set { ha = value; Invalidate(); }
        }
        public StringAlignment VerticalAlignment
        {
            get { return va; }
            set { va = value; Invalidate(); }
        }
        public string TitleText
        {
            get { return text; }
            set { text = value; Invalidate(); }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            e.Graphics.DrawString(TitleText, Font, new SolidBrush(ForeColor), ClientRectangle, new StringFormat() { LineAlignment = ha, Alignment = va });
        }
        public Title()
        {
            InitializeComponent();
        }
    }
}

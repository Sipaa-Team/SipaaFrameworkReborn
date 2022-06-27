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
        public string TitleText
        {
            get { return text; }
            set { text = value; Invalidate(); }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawString(TitleText, Font, new SolidBrush(ForeColor), 0,0);
        }
        public Title()
        {
            InitializeComponent();
        }
    }
}

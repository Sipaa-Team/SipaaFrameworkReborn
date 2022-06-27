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
    public partial class TestInternalForm : SForm
    {
        public TestInternalForm()
        {
            InitializeComponent();
        }

        private void sButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Hello world!");
        }
    }
}

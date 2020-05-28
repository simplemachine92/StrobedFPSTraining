using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace _528test
{
    public partial class Form1 : Form


    {
        public Form1()
        {
            this.Opacity = 0.9999;
            this.TopMost = true;
            InitializeComponent();
            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        const int GWL_EXSTYLE = -20;
        const int WS_EX_LAYERED = 0x80000;
        const int WS_EX_TRANSPARENT = 0x20;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var style = GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, style | WS_EX_LAYERED | WS_EX_TRANSPARENT);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private int caseSwitch = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            caseSwitch++;
            switch (caseSwitch)
            {
                case 1:
                    this.BackColor = Color.DarkGray;
                    break;
                case 2:
                    this.BackColor = Color.Magenta;
                    break;
            }

            if (caseSwitch == 2) caseSwitch = 0;
        }
    }
}
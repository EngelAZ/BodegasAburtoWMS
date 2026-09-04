using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BodegasAburtoWMS.View
{
    public partial class Reportes : Form
    {
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        private const int DWMWA_CAPTION_COLOR = 35;

        public Reportes()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Reportes_Load);
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            int color = 0x008C4E1E;

            int resultado = DwmSetWindowAttribute(this.Handle, DWMWA_CAPTION_COLOR, ref color, sizeof(int));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingProgram
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


            Paint += (sender, e) => DrawRectangle();
        }

        private void DrawRectangle()
        {
            var myBrush = new SolidBrush(Color.Red);
            var formGraphics = CreateGraphics();
            formGraphics.Clear(Color.White);
            Text = "Red Rectangle Application";
            formGraphics.FillRectangle(myBrush, Width * 0.25f, Height * 0.25f, Width * 0.5f, Height * 0.5f);
            myBrush.Dispose();
            formGraphics.Dispose();
        }
    }
}

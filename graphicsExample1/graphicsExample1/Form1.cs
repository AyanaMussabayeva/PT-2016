using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphicsExample1
{
    public partial class Form1 : Form
    {
        Rectangle r = new Rectangle(0, 0, 40, 40);
        Timer t = new Timer();
        //Point p1 = new Point(0, 0);
        //Point p2 = new Point(10, 10);
        public Form1()
        {
            InitializeComponent();
            t.Interval = 30;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString("HH:mm:ss:fff");
            r.X += 10;
            r.Y += 3;
            int dx = 1;
            int dy = 1;
            //this.Refresh();
            if (r.X+dx*10>Width)
            {
                dx=-1;
            }
            if(r.Y+dy>Height)
            {
                dy = -1;
                
            }
            if (r.Y <=0 )
            {
                dy = 1;
                
            }
            if (r.X <= 0)
            {
                dx = 1;
            }
            this.Refresh();
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(Color.Magenta), r.X, r.Y, 40, 40);
            
            e.Graphics.DrawRectangle(new Pen(Color.YellowGreen), 0, 0, Width, Height);

        }
    }
}

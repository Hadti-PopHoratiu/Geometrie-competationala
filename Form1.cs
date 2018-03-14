using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_2_2_13._3
{
    public partial class Form1 : Form
    {
        Graphics grp;
        Bitmap bmp;
        int resx;
        int resy;
        PointF a, b, c;
        PointF ma, mb, mc;
        PointF cg;
        PointF ccc;

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ma = new PointF();
            ma.X = (b.X + c.X) / 2;
            ma.Y = (b.Y + c.Y) / 2;
            mb = new PointF();
            mb.X = (a.X + c.X) / 2;
            mb.Y = (a.Y + c.Y) / 2;
            mc = new PointF();
            mc.X = (a.X + b.X) / 2;
            mc.Y = (a.Y + b.Y) / 2;

            grp.DrawLine(Pens.Red, a, ma);
            grp.DrawLine(Pens.Red, b, mb);
            grp.DrawLine(Pens.Red, c, mc);

            cg = new PointF();
            cg.X = (a.X + b.X + c.X) / 3;
            cg.Y = (a.Y + b.Y + c.Y) / 3;
            grp.DrawEllipse(Pens.Black, cg.X - 1, cg.Y - 1, 3, 3);

            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ccc = new PointF();
            float d = 2*((a.X*(b.Y-c.Y))+(b.X*(c.Y-a.Y))+(c.X*(a.Y-b.Y)));
            ccc.X = (1.0f/ d) * ((a.X * a.X + a.Y * a.Y) * (b.Y - c.Y) + (b.X * b.X + b.Y * b.Y) * (c.Y - a.Y) + (c.X * c.X + c.Y * c.Y) * (a.Y - b.Y));
            ccc.Y = (1.0f / d) * ((a.X * a.X + a.Y * a.Y) * (c.X - b.X) + (b.X * b.X + b.Y * b.Y) * (a.X - c.X) + (c.X * c.X + c.Y * c.Y) * (b.X - a.X));
            grp.DrawEllipse(Pens.Black, ccc.X - 1, ccc.Y - 1, 10, 10);
            

            textBox7.Text = ccc.X.ToString();
            textBox8.Text = ccc.Y.ToString();

            float rccc = (float)Math.Sqrt((ccc.X - a.X) * (ccc.X - a.X) + (ccc.Y - a.Y) * (ccc.Y - a.Y));
            grp.DrawEllipse(Pens.Red, ccc.X - rccc, ccc.Y - rccc, 2 * rccc, 2 * rccc);

            pictureBox1.Image = bmp;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            a = new PointF();
            a.X = float.Parse(textBox1.Text);
            a.Y = float.Parse(textBox2.Text);
            b = new PointF();
            b.X = float.Parse(textBox3.Text);
            b.Y = float.Parse(textBox4.Text);
            c = new PointF();
            c.X = float.Parse(textBox5.Text);
            c.Y = float.Parse(textBox6.Text);

            grp.DrawEllipse(Pens.Red, a.X - 1, a.Y - 1, 3, 3);
            grp.DrawEllipse(Pens.Blue, b.X - 1, b.Y - 1, 3, 3);
            grp.DrawEllipse(Pens.Green, c.X - 1, c.Y - 1, 3, 3);

            grp.DrawLine(Pens.Black, a, b);
            grp.DrawLine(Pens.Black, b, c);
            grp.DrawLine(Pens.Black, a, c);

            


            pictureBox1.Image = bmp;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

            resx = pictureBox1.Width;
            resy = pictureBox1.Height;
            bmp = new Bitmap(resx, resy);
            grp = Graphics.FromImage(bmp);

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Polygon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointF[] dots = GetDotsFromTextBox(textBox1);
            
            if (dots != null)
            {
                PolygonArea polygon = new PolygonArea(dots);
                label2.Text = "S = " + polygon.Area.ToString();
            }
        }

        PointF[] GetDotsFromTextBox(TextBox textBox)
        {
            int n = textBox.Lines.Length;
            PointF[] dots = new PointF[n];

            try
            {
                for (int i = 0; i < n; i++)
                {
                    dots[i] = new PointF(textBox.Lines[i]);
                }
            }
            catch
            {
                MessageBox.Show("Неправильный формат данных");
                return null;
            }

            return dots;
        }
    }
}

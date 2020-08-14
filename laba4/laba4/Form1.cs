using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4
{
    public partial class Form1 : Form
    {
        Graphics drawArea;
        Pen p;
        SolidBrush b;

        int X1, Y1, X2, Y2, dx, dy, incrHorizont, incrVertical, incrDiagonal, delta;

        int X, Y, R;

        public Form1()
        {
            InitializeComponent();
            drawArea = pictureBox1.CreateGraphics();
        }

        private void Initialize()
        {
            X1 = Int32.Parse(textBox4.Text);
            Y1 = Int32.Parse(textBox3.Text);
            X2 = Int32.Parse(textBox2.Text);
            Y2 = Int32.Parse(textBox5.Text);
            X = Int32.Parse(textBox1.Text);
            Y = Int32.Parse(textBox6.Text);
            R = Int32.Parse(textBox7.Text);

            b = new SolidBrush(Color.White);
            drawArea.FillRectangle(b, 0, 0, pictureBox1.Width, pictureBox1.Height);

            p = new Pen(Brushes.Black);

            for (int i = 0; i <= pictureBox1.Height; i+=10)
            {
                drawArea.DrawLine(p, 0, i, pictureBox1.Width, i);
            }
            for (int i = 0; i <= pictureBox1.Width; i += 10)
            {
                drawArea.DrawLine(p, i, 0, i, pictureBox1.Height);
            }            
        }
        private void SetPixel(int x, int y)
        {
            b = new SolidBrush(Color.Gray);
            drawArea.FillRectangle(b, x, y, 10, 10);
            System.Threading.Thread.Sleep(10);
        }
        private void DrawRightUp(int x, int y)
        {
            delta = 2 * dy - dx;
            incrHorizont = 2 * dy;
            incrDiagonal = 2 * (dy - dx);
            for (int i = 0; i < dx; i++)
            {
                if (delta > 0)
                {
                    y++;
                    delta += incrDiagonal;
                }
                else
                    delta += incrHorizont;
                x++;

                SetPixel(x * 10 - 10, pictureBox1.Height - y * 10);
            }
        }
        private void DrawRightUpper(int x, int y)
        {
            delta = 2 * dx - dy;
            incrVertical = 2 * dx;
            incrDiagonal = 2 * (dx - dy);
            for (int i = 0; i < dy; i++)
            {
                if (delta > 0)
                {
                    x++;
                    delta += incrDiagonal;
                }
                else
                    delta += incrVertical;
                y++;

                SetPixel(x * 10 - 10, pictureBox1.Height - y * 10);
            }
        }
        private void DrawRightDown(int x, int y)
        {
            delta = 2 * dy - dx;
            incrHorizont = 2 * dy;
            incrDiagonal = 2 * (dy - dx);
            for (int i = 0; i < dx; i++)
            {
                if (delta > 0)
                {
                    y--;
                    delta += incrDiagonal;
                }
                else
                    delta += incrHorizont;
                x++;

                SetPixel(x * 10 - 10, pictureBox1.Height - y * 10);
            }
        }
        private void DrawRightDowner(int x, int y)
        {
            delta = 2 * dx - dy;
            incrVertical = 2 * dx;
            incrDiagonal = 2 * (dx - dy);
            for (int i = 0; i < dy; i++)
            {
                if (delta > 0)
                {
                    x++;
                    delta += incrDiagonal;
                }
                else
                    delta += incrVertical;
                y--;

                SetPixel(x * 10 - 10, pictureBox1.Height - y * 10);
            }
        }
        private void DrawCircle(int x, int y, int r)
        {
            if (r != 0)
            {
                SetPixel(X * 10 - 10, pictureBox1.Height - Y * 10 - R * 10);
                SetPixel(X * 10 + R * 10 - 10, pictureBox1.Height - Y * 10);
                SetPixel(X * 10 - 10, pictureBox1.Height - Y * 10 + R * 10);
                SetPixel(X * 10 - R * 10 - 10, pictureBox1.Height - Y * 10);

                x = 0;
                y = r;
                delta = 1 - r;
                incrVertical = 3;
                incrDiagonal = 5 - 2 * r;
                while (x <= y)
                {
                    if (delta > 0)
                    {
                        y -= 1;
                        delta += incrDiagonal;
                        incrDiagonal += 4;
                    }
                    else
                    {
                        delta += incrVertical;
                        incrDiagonal += 2;
                    }
                    incrVertical += 2;
                    x += 1;
                    SetPixel((X - x) * 10 - 10, pictureBox1.Height - (Y + y) * 10);
                    SetPixel((X - x) * 10 - 10, pictureBox1.Height - (Y - y) * 10);
                    SetPixel((X + x) * 10 - 10, pictureBox1.Height - (Y + y) * 10);
                    SetPixel((X + x) * 10 - 10, pictureBox1.Height - (Y - y) * 10);
                    SetPixel((X - y) * 10 - 10, pictureBox1.Height - (Y + x) * 10);
                    SetPixel((X - y) * 10 - 10, pictureBox1.Height - (Y - x) * 10);
                    SetPixel((X + y) * 10 - 10, pictureBox1.Height - (Y + x) * 10);
                    SetPixel((X + y) * 10 - 10, pictureBox1.Height - (Y - x) * 10);
                }
            }
            else
            {
                SetPixel(X * 10 - 10, pictureBox1.Height - Y * 10);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Initialize();                
            
            dx = X2 - X1;
            dy = Y2 - Y1;
                      
            if (dx >= dy && dx >=0 && dy >=0)
            {
                int x = X1;
                int y = Y1;

                SetPixel(x * 10 - 10, pictureBox1.Height - y * 10);

                DrawRightUp(x, y);
            }
            else if (dy >= dx && dx >= 0 && dy >= 0)
            {
                int x = X1;
                int y = Y1;

                SetPixel(x * 10 - 10, pictureBox1.Height - y * 10);

                DrawRightUpper(x, y);
            }
            else if (dx >= Math.Abs(dy) && dx >= 0 && dy <= 0)
            {
                int x = X1;
                int y = Y1;
                dy = Math.Abs(dy);

                SetPixel(x * 10 - 10, pictureBox1.Height - y * 10);

                DrawRightDown(x, y);
            }
            else if (Math.Abs(dy) >= dx && dx >= 0 && dy <= 0)
            {
                int x = X1;
                int y = Y1;
                dy = Math.Abs(dy);

                SetPixel(x * 10 - 10, pictureBox1.Height - y * 10);

                DrawRightDowner(x, y);
            }
            else if (Math.Abs(dx) >= Math.Abs(dy) && dx <= 0 && dy <= 0)
            {
                int x = X2;
                int y = Y2;
                dx = Math.Abs(dx);
                dy = Math.Abs(dy);

                SetPixel(x * 10 - 10, pictureBox1.Height - y * 10);

                DrawRightUp(x, y);
            }
            else if (Math.Abs(dy) >= Math.Abs(dx) && dx <= 0 && dy <= 0)
            {
                int x = X2;
                int y = Y2;
                dx = Math.Abs(dx);
                dy = Math.Abs(dy);

                SetPixel(x * 10 - 10, pictureBox1.Height - y * 10);

                DrawRightUpper(x, y);
            }
            else if (Math.Abs(dx) >= dy && dx <= 0 && dy >= 0)
            {
                int x = X2;
                int y = Y2;
                dx = Math.Abs(dx);

                SetPixel(x * 10 - 10, pictureBox1.Height - y * 10);

                DrawRightDown(x, y);
            }
            else if (dy >= Math.Abs(dx) && dx <= 0 && dy >= 0)
            {
                int x = X2;
                int y = Y2;
                dx = Math.Abs(dx);

                SetPixel(x * 10 - 10, pictureBox1.Height - y * 10);

                DrawRightDowner(x, y);
            }

            DrawCircle(X, Y, R);
            
            p = new Pen(Brushes.Red, 2);
            drawArea.DrawLine(p, X1 * 10 - 5, pictureBox1.Height - Y1 * 10 + 5, X2 * 10 - 5, pictureBox1.Height - Y2 * 10 + 5);
            drawArea.DrawEllipse(p, (X - R) * 10 - 5, pictureBox1.Height - (Y + R) * 10 + 5, R * 20, R * 20);
        }
    }
}

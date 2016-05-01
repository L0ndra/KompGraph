using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace KG_LABA1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void DDACiz(Graphics grafik, Color renk, int x1, int y1, int x2, int y2, int fl = 1)
        {

            int PikselSayisi;

            int dx, dy;
            float x, xFark;
            float y, yFark;

            dx = x2 - x1;
            dy = y2 - y1;

            PikselSayisi = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);

            xFark = (float)dx / (float)PikselSayisi;
            yFark = (float)dy / (float)PikselSayisi;

            x = (float)x1;
            y = (float)y1;

            while (PikselSayisi != 0)
            {
                PutPixel(grafik, renk, (int)Math.Floor(x + 0.5F), (int)Math.Floor(y + 0.5f), 255);
                if (fl == 1)
                    x += xFark;
                else if (fl == 0)
                    x += (float)1;
                y += yFark;
                PikselSayisi--;
            }
        }

        private static void PutPixel(Graphics g, Color col, int x, int y, int alpha)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, col)), 10 * x, 10 * y, 10, 10);
        }
        private void dDAЛініяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pen myPen;
            myPen = new Pen(Color.Black);
            Graphics gr = CreateGraphics();
            gr.Clear(Color.White);
            Stopwatch time = new Stopwatch();
            time.Start();
            DDACiz(gr, Color.Black, 1, 3, 10, 22);
            time.Stop();
            TimeSpan t = time.Elapsed;
            MessageBox.Show("Time = " + t.ToString());
            myPen.Dispose();
            gr.Dispose();
        }

        private void несиметричнаDDAЛініяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pen myPen;
            myPen = new Pen(Color.Black);
            Graphics gr = CreateGraphics();
            gr.Clear(Color.White);
            Stopwatch time = new Stopwatch();
            time.Start();
            DDACiz(gr, Color.Black, 1, 3, 11, 22);
            time.Stop();
            TimeSpan t = time.Elapsed;
            MessageBox.Show("Time = " + t.ToString());
            myPen.Dispose();
            gr.Dispose();
        }

        private void модифікованийАлгортимБрезенхемаГенеруванняЛінійToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pen myPen;
            myPen = new Pen(Color.Black);
            Graphics gr = CreateGraphics();
            gr.Clear(Color.White);
            Stopwatch time = new Stopwatch();
            time.Start();
            Bresenham8Line(gr, Color.Black, 1, 3, 10, 22);
            time.Stop();
            TimeSpan t = time.Elapsed;
            MessageBox.Show("Time = " + t.ToString());
            myPen.Dispose();
            gr.Dispose();
        }

        static public void Bresenham8Line(Graphics g, Color clr, int x0, int y0, int x1, int y1)
        {
            //Изменения координат
            int dx = (x1 > x0) ? (x1 - x0) : (x0 - x1);
            int dy = (y1 > y0) ? (y1 - y0) : (y0 - y1);
            //Направление приращения
            int sx = (x1 >= x0) ? (1) : (-1);
            int sy = (y1 >= y0) ? (1) : (-1);

            if (dy < dx)
            {
                int d = (dy << 1) - dx;
                int d1 = dy << 1;
                int d2 = (dy - dx) << 1;
                PutPixel(g, clr, x0, y0, 255);
                int x = x0 + sx;
                int y = y0;
                for (int i = 1; i <= dx; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        y += sy;
                    }
                    else
                        d += d1;
                    PutPixel(g, clr, x, y, 255);
                    x++;
                }
            }
            else
            {
                int d = (dx << 1) - dy;
                int d1 = dx << 1;
                int d2 = (dx - dy) << 1;
                PutPixel(g, clr, x0, y0, 255);
                int x = x0;
                int y = y0 + sy;
                for (int i = 1; i <= dy; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        x += sx;
                    }
                    else
                        d += d1;
                    PutPixel(g, clr, x, y, 255);
                    y++;
                }
            }
        }

        private void алгоритмБрезенхемаГенеруванняКолаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pen myPen;
            myPen = new Pen(Color.Black);
            Graphics gr = CreateGraphics();
            gr.Clear(Color.White);
            Stopwatch time = new Stopwatch();
            time.Start();
            BresenhamCircle(gr, Color.Black, 15, 15, 10);
            time.Stop();
            TimeSpan t = time.Elapsed;
            MessageBox.Show("Time = " + t.ToString());
            myPen.Dispose();
            gr.Dispose();
        }

        public static void BresenhamCircle(Graphics g, Color clr, int _x, int _y, int radius, int fl = 1)
        {
            int x = 0, y = radius, gap = 0, delta = (2 - 2 * radius);
            while (y >= 0)
            {
                if (fl == 1)
                {
                    PutPixel(g, clr, _x + x, _y + y, 255);
                    PutPixel(g, clr, _x + x, _y - y, 255);
                    PutPixel(g, clr, _x - x, _y - y, 255);
                    PutPixel(g, clr, _x - x, _y + y, 255);
                }
                else if (fl == 0) 
                {
                    PutPixel(g, clr, _x + x, _y + y, 255);
                    PutPixel(g, clr, _x + x, _y - y, 255);
                }

                gap = 2 * (delta + y) - 1;
                if (delta < 0 && gap <= 0)
                {
                    x++;
                    delta += 2 * x + 1;
                    continue;
                }
                if (delta > 0 && gap > 0)
                {
                    y--;
                    delta -= 2 * y + 1;
                    continue;
                }
                x++;
                delta += 2 * (x - y);
                y--;
            }
        }

        private void алгоритмВуГенеруванняЛініїToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pen myPen;
            myPen = new Pen(Color.Black);
            Graphics gr = CreateGraphics();
            gr.Clear(Color.White);
            Stopwatch time = new Stopwatch();
            time.Start();
            DrawWuLine(gr, Color.Black, 1, 3, 10, 22);
            time.Stop();
            TimeSpan t = time.Elapsed;
            MessageBox.Show("Time = " + t.ToString());
            myPen.Dispose();
            gr.Dispose();
        }
        public static void DrawWuLine(Graphics g, Color clr, int x0, int y0, int x1, int y1)
        {
            //Вычисление изменения координат
            int dx = (x1 > x0) ? (x1 - x0) : (x0 - x1);
            int dy = (y1 > y0) ? (y1 - y0) : (y0 - y1);
            //Если линия параллельна одной из осей, рисуем обычную линию - заполняем все пикселы в ряд
            if (dx == 0 || dy == 0)
            {
                g.DrawLine(new Pen(clr, 10), 10 * x0, 10 * y0, 10 * x1, 10 * y1);
                return;
            }

            //Для Х-линии (коэффициент наклона < 1)
            if (dy < dx)
            {
                //Первая точка должна иметь меньшую координату Х
                if (x1 < x0)
                {
                    x1 += x0; x0 = x1 - x0; x1 -= x0;
                    y1 += y0; y0 = y1 - y0; y1 -= y0;
                }
                //Относительное изменение координаты Y
                float grad = (float)dy / dx;
                //Промежуточная переменная для Y
                float intery = y0 + grad;
                //Первая точка
                PutPixel(g, clr, x0, y0, 255);

                for (int x = x0 + 1; x < x1; x++)
                {
                    //Верхняя точка
                    PutPixel(g, clr, x, IPart(intery), (int)(255 - FPart(intery) * 255));
                    //Нижняя точка
                    PutPixel(g, clr, x, IPart(intery) + 1, (int)(FPart(intery) * 255));
                    //Изменение координаты Y
                    intery += grad;
                }
                //Последняя точка
                PutPixel(g, clr, x1, y1, 255);
            }
            //Для Y-линии (коэффициент наклона > 1)
            else
            {
                //Первая точка должна иметь меньшую координату Y
                if (y1 < y0)
                {
                    x1 += x0; x0 = x1 - x0; x1 -= x0;
                    y1 += y0; y0 = y1 - y0; y1 -= y0;
                }
                //Относительное изменение координаты X
                float grad = (float)dx / dy;
                //Промежуточная переменная для X
                float interx = x0 + grad;
                //Первая точка
                PutPixel(g, clr, x0, y0, 255);

                for (int y = y0 + 1; y < y1; y++)
                {
                    //Верхняя точка
                    PutPixel(g, clr, IPart(interx), y, 255 - (int)(FPart(interx) * 255));
                    //Нижняя точка
                    PutPixel(g, clr, IPart(interx) + 1, y, (int)(FPart(interx) * 255));
                    //Изменение координаты X
                    interx += grad;
                }
                //Последняя точка
                PutPixel(g, clr, x1, y1, 255);
            }
        }
        private static int IPart(float x)
        {
            return (int)x;
        }
        //дробная часть числа
        private static float FPart(float x)
        {
            while (x >= 0)
                x--;
            x++;
            return x;
        }
        public static void DrawWuCircle(Graphics g, Color clr, int _x, int _y, int radius)
        {
            //Установка пикселов, лежащих на осях системы координат с началом в центре
            PutPixel(g, clr, _x + radius, _y, 255);
            PutPixel(g, clr, _x, _y + radius, 255);
            PutPixel(g, clr, _x - radius + 1, _y, 255);
            PutPixel(g, clr, _x, _y - radius + 1, 255);

            float iy = 0;
            for (int x = 0; x <= radius * Math.Cos(Math.PI / 4); x++)
            {
                //Вычисление точного значения координаты Y 
                iy = (float)Math.Sqrt(radius * radius - x * x);

                //IV квадрант, Y
                PutPixel(g, clr, _x - x, _y + IPart(iy), 255 - (int)(FPart(iy) * 255));
                PutPixel(g, clr, _x - x, _y + IPart(iy) + 1, (int)(FPart(iy) * 255));
                //I квадрант, Y
                PutPixel(g, clr, _x + x, _y + IPart(iy), 255 - (int)(FPart(iy) * 255));
                PutPixel(g, clr, _x + x, _y + IPart(iy) + 1, (int)(FPart(iy) * 255));
                //I квадрант, X
                PutPixel(g, clr, _x + IPart(iy), _y + x, 255 - (int)(FPart(iy) * 255));
                PutPixel(g, clr, _x + IPart(iy) + 1, _y + x, (int)(FPart(iy) * 255));
                //II квадрант, X
                PutPixel(g, clr, _x + IPart(iy), _y - x, 255 - (int)(FPart(iy) * 255));
                PutPixel(g, clr, _x + IPart(iy) + 1, _y - x, (int)(FPart(iy) * 255));

                //С помощью инкремента устраняется ошибка смещения на 1 пиксел
                x++;
                //II квадрант, Y
                PutPixel(g, clr, _x + x, _y - IPart(iy), (int)(FPart(iy) * 255));
                PutPixel(g, clr, _x + x, _y - IPart(iy) + 1, 255 - (int)(FPart(iy) * 255));
                //III квадрант, Y
                PutPixel(g, clr, _x - x, _y - IPart(iy), (int)(FPart(iy) * 255));
                PutPixel(g, clr, _x - x, _y - IPart(iy) + 1, 255 - (int)(FPart(iy) * 255));
                //III квадрант, X
                PutPixel(g, clr, _x - IPart(iy), _y - x, (int)(FPart(iy) * 255));
                PutPixel(g, clr, _x - IPart(iy) + 1, _y - x, 255 - (int)(FPart(iy) * 255));
                //IV квадрант, X
                PutPixel(g, clr, _x - IPart(iy), _y + x, (int)(FPart(iy) * 255));
                PutPixel(g, clr, _x - IPart(iy) + 1, _y + x, 255 - (int)(FPart(iy) * 255));
                //Возврат значения
                x--;
            }
        }

        public static void Bresenham4Line(Graphics g, Color clr, int x0, int y0, int x1, int y1)
        {
            int dx = x1 - x0;
            int dy = y1 - y0;
            int d = 0;
            int d1 = dy << 1;
            int d2 = -(dx << 1);
            PutPixel(g, clr, x0, y0, 255);
            int x = x0;
            int y = y0;

            for (int i = 1; i <= dx + dy; i++)
            {
                if (d > 0)
                {
                    d += d2;
                    y++;
                }
                else
                {
                    d += d1;
                    x++;
                }
                PutPixel(g, clr, x, y, 255);
            }
        }

        private void прізвищеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pen myPen;
            myPen = new Pen(Color.Black);
            Graphics gr = CreateGraphics();
            gr.Clear(Color.White);

            //Г
            DDACiz(gr, Color.Black, 1, 6, 8, 6);
            DDACiz(gr, Color.Black, 1, 6, 1, 18);
            
            //Н
            DDACiz(gr, Color.Black, 10, 6, 10, 18);
            DDACiz(gr, Color.Black, 18, 6, 18, 18);
            DDACiz(gr, Color.Black, 10, 10, 18, 10);

            //і
            DDACiz(gr, Color.Black, 20, 4, 20, 5);
            DDACiz(gr, Color.Black, 20, 6, 20, 18);

            //Д
            DDACiz(gr, Color.Black, 24, 6, 32, 6);
            DDACiz(gr, Color.Black, 32, 6, 32, 18);
            DDACiz(gr, Color.Black, 24, 6, 24, 18);
            DDACiz(gr, Color.Black, 22, 18, 34, 18);
            DDACiz(gr, Color.Black, 22, 18, 22, 20);
            DDACiz(gr, Color.Black, 34, 18, 34, 20);

            //И
            DDACiz(gr, Color.Black, 36, 6, 36, 18);
            DDACiz(gr, Color.Black, 44, 6, 44, 18);
            DDACiz(gr, Color.Black, 36, 17, 44, 6);

            //Й
            DDACiz(gr, Color.Black, 46, 6, 46, 18);
            DDACiz(gr, Color.Black, 54, 6, 54, 18);
            DDACiz(gr, Color.Black, 46, 17, 54, 6);
            DDACiz(gr, Color.Black, 49, 4, 52, 4);

            //ь
            //DDACiz(gr, Color.Black, 63, 3, 63, 12);
            //BresenhamCircle(gr, Color.Black, 63, 9, 2, 0);

            myPen.Dispose();
            gr.Dispose();
        }

        private void проАвтораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}

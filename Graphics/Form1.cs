using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Test
{
    public partial class Form1 : Form
    {
        Point start;
        Point midCur;
        Point midPrev;
        Point cur;
        Point prev;
        Size stSize;
        System.Drawing.Graphics g;
        Pen p;
        Pen track;
        Brush stBrush;
        Brush actBrush;
        Rectangle r;
        string file;
        string fileIn;
        string s;

        private int toInt(string s)
        {
            int a = 0;
            for (int i = s.Length - 1; i >= 0; --i)
                if (s[i] == '1')
                    a += (int)Math.Pow(2, s.Length - i - 1);
            return a;
        }

        private string toByte(int a)
        {
            string s = "";
            byte[] ans = new byte[16];
            int i = 0;
            int fl = 0;
            int b = a;
            for (i = 0; i < a; ++i)
            {
                --b;
                ++ans[15];
                for (int j = 15; j > 0; --j)
                    if (ans[j] > 1)
                    {
                        ans[j] = 0;
                        ++ans[j - 1];
                    }
            }
            for (int j = 0; j <= 15; ++j)
                s += ans[j].ToString();
            return s;
        }

        public Form1()
        {
            InitializeComponent();
            file = "C:\\Test\\graphOut.txt";
            fileIn = "C:\\Test\\graphIn.txt";
            s = "";
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);
        }
        private void Init(int x, int y)
        {
            g = this.CreateGraphics();
            g.Clear(System.Drawing.Color.White);
            p = new Pen(System.Drawing.Color.Black, 1);
            track = new Pen(System.Drawing.Color.Red, 2);
            stBrush = new SolidBrush(System.Drawing.Color.Black);
            actBrush = new SolidBrush(System.Drawing.Color.Blue);
            for (int i = 1; i < 30; ++i)
                for (int j = 1; j < 30; ++j)
                {
                    r = new Rectangle(10 + 20 * (i - 1), 10 + 20 * (j - 1), 20, 20);
                    g.DrawRectangle(p, r);
                }
            start = new Point(10 + 20 * (x - 1), 10 + 20 * (y - 1));
            cur = start;
            prev = start;
            stSize = new Size(20, 20);
            r = new Rectangle(start, stSize);
            g.FillRectangle(actBrush, r);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.IO.File.WriteAllText(file, string.Empty);
            Init(15, 15);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (int)Keys.W:
                    if (cur.Y >= 30)
                    {
                        g = this.CreateGraphics();
                        track = new Pen(System.Drawing.Color.Red, 2);
                        prev = cur;
                        cur = new Point(cur.X, cur.Y - 20);
                        midCur = new Point(cur.X + 10, cur.Y + 10);
                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                        g.DrawLine(track, midCur, midPrev);
                        if (s.Length - s.LastIndexOf(System.Environment.NewLine) == 18)
                            s += System.Environment.NewLine + "0";
                        s += "000";
                    }
                    break;
                case (int)Keys.A:
                    if (cur.X >= 30)
                    {
                        g = this.CreateGraphics();
                        track = new Pen(System.Drawing.Color.Red, 2);
                        prev = cur;
                        cur = new Point(cur.X - 20, cur.Y);
                        midCur = new Point(cur.X + 10, cur.Y + 10);
                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                        g.DrawLine(track, midCur, midPrev);
                        if (s.Length - s.LastIndexOf(System.Environment.NewLine) == 18)
                            s += System.Environment.NewLine + "0";
                        s += "110";
                    }
                    break;
                case (int)Keys.D:
                    if (cur.X <= 560)
                    {
                        g = this.CreateGraphics();
                        track = new Pen(System.Drawing.Color.Red, 2);
                        prev = cur;
                        cur = new Point(cur.X + 20, cur.Y);
                        midCur = new Point(cur.X + 10, cur.Y + 10);
                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                        g.DrawLine(track, midCur, midPrev);
                        if (s.Length - s.LastIndexOf(System.Environment.NewLine) == 18)
                            s += System.Environment.NewLine + "0";
                        s += "010";
                    }
                    break;
                case (int)Keys.S:
                    if (cur.Y <= 560)
                    {
                        g = this.CreateGraphics();
                        track = new Pen(System.Drawing.Color.Red, 2);
                        prev = cur;
                        cur = new Point(cur.X, cur.Y + 20);
                        midCur = new Point(cur.X + 10, cur.Y + 10);
                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                        g.DrawLine(track, midCur, midPrev);
                        if (s.Length - s.LastIndexOf(System.Environment.NewLine) == 18)
                            s += System.Environment.NewLine + "0";
                        s += "100";
                    }
                    break;
                case (int)Keys.Q:
                    if (cur.Y >= 30 && cur.X >= 30)
                    {
                        g = this.CreateGraphics();
                        track = new Pen(System.Drawing.Color.Red, 2);
                        prev = cur;
                        cur = new Point(cur.X - 20, cur.Y - 20);
                        midCur = new Point(cur.X + 10, cur.Y + 10);
                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                        g.DrawLine(track, midCur, midPrev);
                        if (s.Length - s.LastIndexOf(System.Environment.NewLine) == 18)
                            s += System.Environment.NewLine + "0";
                        s += "111";
                    }
                    break;
                case (int)Keys.E:
                    if (cur.X <= 560 && cur.Y >= 30)
                    {
                        g = this.CreateGraphics();
                        track = new Pen(System.Drawing.Color.Red, 2);
                        prev = cur;
                        cur = new Point(cur.X + 20, cur.Y - 20);
                        midCur = new Point(cur.X + 10, cur.Y + 10);
                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                        g.DrawLine(track, midCur, midPrev);
                        if (s.Length - s.LastIndexOf(System.Environment.NewLine) == 18)
                            s += System.Environment.NewLine + "0";
                        s += "001";
                    }
                    break;
                case (int)Keys.Z:
                    if (cur.Y <= 560 && cur.X >= 30)
                    {
                        g = this.CreateGraphics();
                        track = new Pen(System.Drawing.Color.Red, 2);
                        prev = cur;
                        cur = new Point(cur.X - 20, cur.Y + 20);
                        midCur = new Point(cur.X + 10, cur.Y + 10);
                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                        g.DrawLine(track, midCur, midPrev);
                        if (s.Length - s.LastIndexOf(System.Environment.NewLine) == 18)
                            s += System.Environment.NewLine + "0";
                        s += "101";
                    }
                    break;
                case (int)Keys.X:
                    if (cur.Y <= 560 && cur.X <= 560)
                    {
                        g = this.CreateGraphics();
                        track = new Pen(System.Drawing.Color.Red, 2);
                        prev = cur;
                        cur = new Point(cur.X + 20, cur.Y + 20);
                        midCur = new Point(cur.X + 10, cur.Y + 10);
                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                        g.DrawLine(track, midCur, midPrev);
                        if (s.Length - s.LastIndexOf(System.Environment.NewLine) == 18)
                            s += System.Environment.NewLine + "0";
                        s += "011";
                    }
                    break;
                case (int)Keys.Enter:
                    System.IO.BinaryWriter b = new System.IO.BinaryWriter(System.IO.File.Open("C:\\Test\\In.dat", System.IO.FileMode.OpenOrCreate));
                    while (s.Length > 14)
                    {
                        s = "0" + s;
                        b.Write((Int16)toInt(s.Substring(0, 16)));
                        s = s.Remove(0, 16);
                    }
                    if (s.Length > 0)
                    {
                        s = "0" + s;
                        while (s.Length < 16)
                            s += "0";
                        b.Write((Int16)toInt(s));
                    }
                    break;
                case (int)Keys.I:
                    Init(15, 15);
                    break;
                case (int)Keys.O:
                    System.IO.BinaryReader d = new System.IO.BinaryReader(System.IO.File.Open("C:\\Test\\Out.dat", System.IO.FileMode.Open));
                    string rd = System.IO.File.ReadAllText(fileIn);
                    rd = "";
                    try
                    {
                        while (true)
                        {
                            rd = toByte(d.ReadInt16());
                            for (int i = 0; i < 5; ++i)
                            switch (toInt(rd.Substring(1 + 3 * i, 3)))
                            {
                                case 0:
                                    if (cur.Y >= 30)
                                    {
                                        g = this.CreateGraphics();
                                        track = new Pen(System.Drawing.Color.Red, 2);
                                        prev = cur;
                                        cur = new Point(cur.X, cur.Y - 20);
                                        midCur = new Point(cur.X + 10, cur.Y + 10);
                                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                                        g.DrawLine(track, midCur, midPrev);
                                        for (int time = 0; time < 10000000; ++time) ;
                                    }
                                    break;
                                case 6:
                                    if (cur.X >= 30)
                                    {
                                        g = this.CreateGraphics();
                                        track = new Pen(System.Drawing.Color.Red, 2);
                                        prev = cur;
                                        cur = new Point(cur.X - 20, cur.Y);
                                        midCur = new Point(cur.X + 10, cur.Y + 10);
                                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                                        g.DrawLine(track, midCur, midPrev);
                                        for (int time = 0; time < 10000000; ++time) ;
                                    }
                                    break;
                                case 2:
                                    if (cur.X <= 560)
                                    {
                                        g = this.CreateGraphics();
                                        track = new Pen(System.Drawing.Color.Red, 2);
                                        prev = cur;
                                        cur = new Point(cur.X + 20, cur.Y);
                                        midCur = new Point(cur.X + 10, cur.Y + 10);
                                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                                        g.DrawLine(track, midCur, midPrev);
                                        for (int time = 0; time < 10000000; ++time) ;
                                    }
                                    break;
                                case 4:
                                    if (cur.Y <= 560)
                                    {
                                        g = this.CreateGraphics();
                                        track = new Pen(System.Drawing.Color.Red, 2);
                                        prev = cur;
                                        cur = new Point(cur.X, cur.Y + 20);
                                        midCur = new Point(cur.X + 10, cur.Y + 10);
                                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                                        g.DrawLine(track, midCur, midPrev);
                                        for (int time = 0; time < 10000000; ++time) ;
                                    }
                                    break;
                                case 7:
                                    if (cur.Y >= 30 && cur.X >= 30)
                                    {
                                        g = this.CreateGraphics();
                                        track = new Pen(System.Drawing.Color.Red, 2);
                                        prev = cur;
                                        cur = new Point(cur.X - 20, cur.Y - 20);
                                        midCur = new Point(cur.X + 10, cur.Y + 10);
                                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                                        g.DrawLine(track, midCur, midPrev);
                                        for (int time = 0; time < 10000000; ++time) ;
                                    }
                                    break;
                                case 1:
                                    if (cur.X <= 560 && cur.Y >= 30)
                                    {
                                        g = this.CreateGraphics();
                                        track = new Pen(System.Drawing.Color.Red, 2);
                                        prev = cur;
                                        cur = new Point(cur.X + 20, cur.Y - 20);
                                        midCur = new Point(cur.X + 10, cur.Y + 10);
                                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                                        g.DrawLine(track, midCur, midPrev);
                                        for (int time = 0; time < 10000000; ++time) ;
                                    }
                                    break;
                                case 5:
                                    if (cur.Y <= 560 && cur.X >= 30)
                                    {
                                        g = this.CreateGraphics();
                                        track = new Pen(System.Drawing.Color.Red, 2);
                                        prev = cur;
                                        cur = new Point(cur.X - 20, cur.Y + 20);
                                        midCur = new Point(cur.X + 10, cur.Y + 10);
                                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                                        g.DrawLine(track, midCur, midPrev);
                                        for (int time = 0; time < 10000000; ++time) ;
                                    }
                                    break;
                                case 3:
                                    if (cur.Y <= 560 && cur.X <= 560)
                                    {
                                        g = this.CreateGraphics();
                                        track = new Pen(System.Drawing.Color.Red, 2);
                                        prev = cur;
                                        cur = new Point(cur.X + 20, cur.Y + 20);
                                        midCur = new Point(cur.X + 10, cur.Y + 10);
                                        midPrev = new Point(prev.X + 10, prev.Y + 10);
                                        g.DrawLine(track, midCur, midPrev);
                                        for (int time = 0; time < 10000000; ++time) ;
                                    }
                                    break;
                            }
                        }
                    }
                    catch (Exception) { }
                    d.Close();
                    break;
            }
        }
        private void Form1_Paint()
        {

        }
    }
}

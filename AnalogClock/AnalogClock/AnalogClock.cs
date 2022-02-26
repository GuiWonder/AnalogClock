using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnalogClock
{
    public partial class AnalogClock : Form
    {
        Timer timer = new Timer();
        public static int a, edge, oldedge;
        public static bool topmost;
        public static bool showsec;
        int r, l1, l2, lh, lm, lf, f;
        DateTime time = DateTime.Now;
        int maxa;
        bool dark = false;

        public AnalogClock()
        {
            InitializeComponent();
            DoubleBuffered = true;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            SetStyle(ControlStyles.ResizeRedraw, true);
            Paint += new PaintEventHandler(AnalogClock_Paint);
            Resize += AnalogClock_Resize;
            a = 300;
            edge = 2;
            showsec = true;
            ShowIcon = false;
            BackColor = Color.White;
            topmost = false;
            SetSize();
            ClientSize = new Size(a, a);
            MouseDown += AnalogClock_MouseDown;

            //BackColor = Color.Black;
            //dark = true;
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
            //darkToolStripMenuItem.Checked = true;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        
        private void AnalogClock_MouseDown(object sender, MouseEventArgs e)
        {
            if (!fullScreenToolStripMenuItem.Checked)
            {
                ReleaseCapture();
                SendMessage(Handle, 0x0112, 0xF010 + 0x0002, 0);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time = DateTime.Now;
            Invalidate();
            if (soundToolStripMenuItem.Checked)
            {
                if (time.Minute == 0 && time.Second == 0)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.zheng);
                    player.Play();
                }
                else if (time.Minute == 30 && time.Second == 0)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.half);
                    player.Play();
                }
                else if (time.Second == 0)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.da2);
                    player.Play();
                }
                else if (!(time.Minute == 0 && time.Second == 1) && showSecondHandToolStripMenuItem.Checked)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.da);
                    player.Play();
                }
            }
        }

        private void soundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            soundToolStripMenuItem.Checked = !soundToolStripMenuItem.Checked;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showToolStripMenuItem.Checked = !showToolStripMenuItem.Checked;
            if (showToolStripMenuItem.Checked)
            {
                edge = oldedge;
                FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                oldedge = edge;
                maxa = a;
                edge = 1;
                FormBorderStyle = FormBorderStyle.None;
                CircleForm();
            }
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            darkToolStripMenuItem.Checked = !darkToolStripMenuItem.Checked;
            dark = darkToolStripMenuItem.Checked;
            BackColor = darkToolStripMenuItem.Checked ? Color.Black : Color.White;
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fullScreenToolStripMenuItem.Checked = !fullScreenToolStripMenuItem.Checked;
            if (fullScreenToolStripMenuItem.Checked)
            {
                //BackColor = Color.Black;
                //dark = true;
                //darkToolStripMenuItem.Checked = true;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }
        }

        private void CircleForm()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                ClientSize = new Size(maxa, maxa);
                WindowState = FormWindowState.Normal;
            }
            else
            {
                ClientSize = new Size(a, a);
            }
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, Width, Height);
            Graphics g = CreateGraphics();
            g.DrawEllipse(new Pen(Color.Black, 2), 1, 1, Width - 2, Height - 2);
            Region = new Region(path);
        }

        private void AnalogClock_Paint(object sender, PaintEventArgs e)
        {
            Color color1 = dark ? Color.White : Color.Black;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2);
            Pen p = new Pen(Color.Goldenrod, 3);
            Pen p2 = new Pen(color1, 6);
            for (int i = 0; i < 360; i += 6)
            {
                if (i % 30 == 0)
                {
                    continue;
                }
                double hudu = i * Math.PI / 180;
                int nei = r - l1;
                g.DrawLine(p, (float)(Math.Sin(hudu) * r), (float)(Math.Cos(hudu) * r), (float)(Math.Sin(hudu) * nei), (float)(Math.Cos(hudu) * nei));
            }
            for (int i = 0; i < 360; i += 30)
            {
                double hudu = i * Math.PI / 180;
                int nei = r - l2;
                g.DrawLine(p2, (float)(Math.Sin(hudu) * r), (float)(Math.Cos(hudu) * r), (float)(Math.Sin(hudu) * nei), (float)(Math.Cos(hudu) * nei));
            }
            for (int i = 0; i < 360; i += 30)
            {
                double hudu = (i - 90) * Math.PI / 180;
                string txt = (i / 30).ToString();
                if (txt == "0")
                {
                    txt = "12";
                }
                int nei = r - lf;
                if (txt.Length > 1)
                {
                    g.DrawString(txt, new Font("Verdana", f), new SolidBrush(color1), (float)(Math.Cos(hudu) * nei - (f * 1)), (float)(Math.Sin(hudu) * nei - (f * 0.85)));
                }
                else
                {
                    g.DrawString(txt, new Font("Verdana", f), new SolidBrush(color1), (float)(Math.Cos(hudu) * nei - (f * 0.65)), (float)(Math.Sin(hudu) * nei - (f * 0.85)));

                }
            }
            g.DrawEllipse(p, -r, -r, 2 * r, 2 * r);
            Pen ph = new Pen(color1, 5);
            Pen pm = new Pen(Color.Blue, 3);
            Pen ps = new Pen(Color.Red, 2);
            double duh = (30 * time.Hour) + (0.5 * time.Minute) - 90;
            double dum = (6 * time.Minute) + (0.1 * time.Second) - 90;
            int b = 6;
            double huduh = duh * Math.PI / 180;
            g.DrawLine(ph, (float)(Math.Cos(huduh) * lh), (float)(Math.Sin(huduh) * lh), (float)(Math.Cos(huduh - Math.PI) * r / b), (float)(Math.Sin(huduh - Math.PI) * r / b));
            double hudum = dum * Math.PI / 180;
            g.DrawLine(pm, (float)(Math.Cos(hudum) * lm), (float)(Math.Sin(hudum) * lm), (float)(Math.Cos(hudum - Math.PI) * r / b), (float)(Math.Sin(hudum - Math.PI) * r / b));
            if (showsec)
            {
                double hudus = (6 * time.Second - 90) * Math.PI / 180;
                g.DrawLine(ps, (float)(Math.Cos(hudus) * r), (float)(Math.Sin(hudus) * r), (float)(Math.Cos(hudus - Math.PI) * r / b), (float)(Math.Sin(hudus - Math.PI) * r / b));
            }
            SolidBrush dcolor = new SolidBrush(Color.Green);
            g.DrawString($"{time.Year}-{time.Month}-{time.Day} {time.DayOfWeek}", new Font("Verdana", r * 9 / 100), dcolor, -r * 60 / 100, r * 33 / 100);
            dcolor.Dispose();
            Pen p3 = new Pen(Color.Red, 4);
            g.DrawEllipse(p3, -2, -2, 4, 4);
        }

        private void AnalogClock_Resize(object sender, EventArgs e)
        {
            int size = Math.Min(ClientSize.Width, ClientSize.Height);
            if (size > edge * 2 + 25)
            {
                a = size;
                SetSize();
            }
        }

        private void SetSize()
        {
            r = a / 2 - edge; ;
            l1 = a * 2 / 100;
            l2 = a * 3 / 100;
            lh = r * 78 / 100;
            lm = r * 94 / 100;
            lf = r * 15 / 100;
            f = r * 10 / 100;
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting set = new Setting();
            int olda = a;
            int oldedg = edge;
            if (set.ShowDialog() == DialogResult.OK)
            {
                TopMost = topmost;
                if (olda != a || oldedg != edge)
                {
                    if (!showToolStripMenuItem.Checked)
                    {
                        edge = 1;
                    }
                    SetSize();
                    ClientSize = new Size(a, a);
                    if (WindowState == FormWindowState.Maximized)
                    {
                        WindowState = FormWindowState.Normal;
                    }
                    if (!showToolStripMenuItem.Checked)
                    {
                        CircleForm();
                    }
                }
            }
        }

        private void topmostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            topmostToolStripMenuItem.Checked = !topmostToolStripMenuItem.Checked;
            topmost = topmostToolStripMenuItem.Checked;
            TopMost = topmost;
        }

        private void showSecondHandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSecondHandToolStripMenuItem.Checked = !showSecondHandToolStripMenuItem.Checked;
            showsec = showSecondHandToolStripMenuItem.Checked;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

using OpenTK.Platform.Windows;
using OpenTK;
using OpenTK.Graphics;

namespace HelloOpenGL
{
    public partial class Form1 : Form
    {
        private byte nRedByte;
        private GLControl? glControl1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nRedByte = 0;
            glControl1 = new GLControl();
            glControl1.BackColor = Color.Black;
            glControl1?.Dock = DockStyle.Fill;
            glControl1?.Paint += GLControl1_Paint;
            this.Controls.Add(glControl1);
            Application.Idle += Application_Idle;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            glControl1?.Invalidate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Idle -= Application_Idle;
            glControl1?.Paint -= GLControl1_Paint;
            this.Controls?.Remove(glControl1);
            glControl1?.Dispose();
        }

        private void Application_Idle(object? sender, EventArgs e)
        {
            nRedByte++;
            Invalidate();
        }

        private void GLControl1_Paint(object? sender, PaintEventArgs e)
        {
            var glColor = Color.FromArgb(nRedByte, 0, 0);
            GL.ClearColor(glColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.StencilBufferBit);
            GL.ClearDepth(0);
            glControl1?.SwapBuffers();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public void Draw(Graphics g, Matrix4x4 cameraMat)
        {
            List<Vector4> lines = new List<Vector4>();

            for (int i = -20; i <= 20; i++)
            {
                lines.Add(new Vector4(i, 0, 21, 1));
                lines.Add(new Vector4(i, 0, 100, 1));
            }

            Pen[] pens = new Pen[] {
                Pens.Red,
                Pens.Green,
                Pens.Blue,
            };

            var translateMat = Matrix4x4.CreateTranslation(new Vector4(0, -23f, 0, 1));
            var rotateMat = Matrix4x4.CreateRotationX((float)(2.5 * Math.PI / 180));
            var scaleMat = Matrix4x4.CreateScale(1f);

            var totMat = translateMat * rotateMat * scaleMat;

            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = Vector4.NormalizeW(cameraMat * totMat * lines[i]);

            }

            for (int i = 0; i < lines.Count - 1; i += 2)
            {
                float newX1 = (float)((lines[i].X * Width) / (2.0 * lines[i].W) + pictureBox1.Width / 2);
                float newY1 = (float)((lines[i].Y * Height) / (2.0 * lines[i].W) + pictureBox1.Height / 2);

                float newX2 = (float)((lines[i + 1].X * Width) / (2.0 * lines[i + 1].W) + pictureBox1.Width / 2);
                float newY2 = (float)((lines[i + 1].Y * Height) / (2.0 * lines[i + 1].W) + pictureBox1.Height / 2);

                g.DrawLine(pens[i / 2 % pens.Length], newX1, newY1, newX2, newY2);

                Console.WriteLine("(" + newX1 + " " + newY1 + ") - (" + newX2 + " " + newY2 + ")");
            }


        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Draw(
                e.Graphics,
                Matrix4x4.CreatePerspectiv(
                    120,
                    (float)pictureBox1.Width / pictureBox1.Height,
                    20,
                    100)
                );
        }
    }


}
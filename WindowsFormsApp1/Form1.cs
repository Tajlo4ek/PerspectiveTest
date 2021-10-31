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
            List<Vector4> lines = new List<Vector4>()
            {
                //cube
                new Vector4(-0.5f,-0.5f,-0.5f,1),
                new Vector4(0.5f,-0.5f,-0.5f,1),

                new Vector4(-0.5f,-0.5f,-0.5f,1),
                new Vector4(-0.5f,0.5f,-0.5f,1),

                new Vector4(-0.5f,-0.5f,-0.5f,1),
                new Vector4(-0.5f,-0.5f,0.5f,1),


                new Vector4(0.5f,0.5f,0.5f,1),
                new Vector4(-0.5f,0.5f,0.5f,1),

                new Vector4(0.5f,0.5f,0.5f,1),
                new Vector4(0.5f,-0.5f,0.5f,1),

                new Vector4(0.5f,0.5f,0.5f,1),
                new Vector4(0.5f,0.5f,-0.5f,1),


                new Vector4(0.5f,-0.5f,-0.5f,1),
                new Vector4(0.5f,-0.5f,0.5f,1),

                new Vector4(0.5f,-0.5f,-0.5f,1),
                new Vector4(0.5f,0.5f,-0.5f,1),


                new Vector4(-0.5f,0.5f,-0.5f,1),
                new Vector4(0.5f,0.5f,-0.5f,1),

                new Vector4(-0.5f,0.5f,-0.5f,1),
                new Vector4(-0.5f,0.5f,0.5f,1),


                new Vector4(-0.5f,-0.5f,0.5f,1),
                new Vector4(0.5f,-0.5f,0.5f,1),

                new Vector4(-0.5f,-0.5f,0.5f,1),
                new Vector4(-0.5f,0.5f,0.5f,1),

                //line y
                new Vector4(0,0,0,1),
                new Vector4(0,1,0,1),

                //line x
                new Vector4(0,0,0,1),
                new Vector4(1,0,0,1),

                //line z
                new Vector4(0,0,0,1),
                new Vector4(0,0,1,1),
            };


            Pen[] pens = new Pen[] {
                Pens.Red,
                Pens.Green,
                Pens.Blue,
            };

            var translateMat = Matrix4x4.CreateTranslation(new Vector4(0, 0, 5, 1));
            float angleX = (float)(tbRotX.Value * Math.PI / 180);
            float angleY = (float)(tbRotY.Value * Math.PI / 180);
            float angleZ = (float)(tbRotZ.Value * Math.PI / 180);
            var rotateMat = Matrix4x4.CreateFromYawPitchRoll(angleX, angleY, angleZ);
            var scaleMat = Matrix4x4.CreateScale(2f);

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
                    60,
                    (float)pictureBox1.Width / pictureBox1.Height,
                    20,
                    60)
                );
        }

        private void tbRot_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    public struct Matrix4x4
    {
        public float V00 { get; private set; }
        public float V01 { get; private set; }
        public float V02 { get; private set; }
        public float V03 { get; private set; }
        public float V10 { get; private set; }
        public float V11 { get; private set; }
        public float V12 { get; private set; }
        public float V13 { get; private set; }
        public float V20 { get; private set; }
        public float V21 { get; private set; }
        public float V22 { get; private set; }
        public float V23 { get; private set; }
        public float V30 { get; private set; }
        public float V31 { get; private set; }
        public float V32 { get; private set; }
        public float V33 { get; private set; }

        public static Matrix4x4 Identity
        {
            get
            {
                Matrix4x4 m = new Matrix4x4();
                m.V00 = 1;
                m.V11 = 1;
                m.V22 = 1;
                m.V33 = 1;
                return m;
            }
        }

        public static Matrix4x4 CreateScale(float scale)
        {
            var m = new Matrix4x4();
            m.V00 = scale;
            m.V11 = scale;
            m.V22 = scale;
            m.V33 = 1f;

            return m;
        }


        public static Matrix4x4 CreateRotationY(float radians)
        {
            Matrix4x4 m = Matrix4x4.Identity;

            float cos = (float)System.Math.Cos(radians);
            float sin = (float)System.Math.Sin(radians);

            m.V00 = cos;
            m.V22 = cos;
            m.V02 = sin;
            m.V20 = -sin;

            return m;
        }

        public static Matrix4x4 CreateRotationX(float radians)
        {
            Matrix4x4 m = Matrix4x4.Identity;

            float cos = (float)System.Math.Cos(radians);
            float sin = (float)System.Math.Sin(radians);

            m.V11 = cos;
            m.V22 = cos;
            m.V12 = -sin;
            m.V21 = sin;

            return m;
        }

        public static Matrix4x4 CreateRotationZ(float radians)
        {
            Matrix4x4 m = Matrix4x4.Identity;

            float cos = (float)System.Math.Cos(radians);
            float sin = (float)System.Math.Sin(radians);

            m.V00 = cos;
            m.V11 = cos;
            m.V01 = -sin;
            m.V10 = sin;

            return m;
        }

        public static Matrix4x4 CreateFromYawPitchRoll(float yaw, float pitch, float roll)
        {
            return (CreateRotationY(yaw) * CreateRotationX(pitch)) * CreateRotationZ(roll);
        }

        public static Matrix4x4 CreateTranslation(Vector4 position)
        {
            Matrix4x4 m = Matrix4x4.Identity;

            m.V03 = position.X;
            m.V13 = position.Y;
            m.V23 = position.Z;

            return m;
        }

        public static Matrix4x4 CreatePerspectiv(float fov, float aspect, float near, float far)
        {
            Matrix4x4 mat = Matrix4x4.Identity;

            fov = (float)(1 / Math.Tan(fov / 2 * Math.PI / 180));

            mat.V00 = fov / aspect;
            mat.V11 = fov;
            mat.V22 = (far + near) / (far - near);
            mat.V23 = 1;
            mat.V32 = (-2 * far + near) / (far - near);

            /*mat.V00 = fov * aspect;
            mat.V11 = fov;
            mat.V22 = (far + near) / (far - near);
            mat.V23 = 1;
            mat.V32 = (2 * far + near) / (far - near);*/


            return mat;
        }

        public static Matrix4x4 operator *(Matrix4x4 matrix1, Matrix4x4 matrix2)
        {
            Matrix4x4 m = new Matrix4x4
            {
                V00 = matrix1.V00 * matrix2.V00 + matrix1.V01 * matrix2.V10 + matrix1.V02 * matrix2.V20 + matrix1.V03 * matrix2.V30,
                V01 = matrix1.V00 * matrix2.V01 + matrix1.V01 * matrix2.V11 + matrix1.V02 * matrix2.V21 + matrix1.V03 * matrix2.V31,
                V02 = matrix1.V00 * matrix2.V02 + matrix1.V01 * matrix2.V12 + matrix1.V02 * matrix2.V22 + matrix1.V03 * matrix2.V32,
                V03 = matrix1.V00 * matrix2.V03 + matrix1.V01 * matrix2.V13 + matrix1.V02 * matrix2.V23 + matrix1.V03 * matrix2.V33,

                V10 = matrix1.V10 * matrix2.V00 + matrix1.V11 * matrix2.V10 + matrix1.V12 * matrix2.V20 + matrix1.V13 * matrix2.V30,
                V11 = matrix1.V10 * matrix2.V01 + matrix1.V11 * matrix2.V11 + matrix1.V12 * matrix2.V21 + matrix1.V13 * matrix2.V31,
                V12 = matrix1.V10 * matrix2.V02 + matrix1.V11 * matrix2.V12 + matrix1.V12 * matrix2.V22 + matrix1.V13 * matrix2.V32,
                V13 = matrix1.V10 * matrix2.V03 + matrix1.V11 * matrix2.V13 + matrix1.V12 * matrix2.V23 + matrix1.V13 * matrix2.V33,

                V20 = matrix1.V20 * matrix2.V00 + matrix1.V21 * matrix2.V10 + matrix1.V22 * matrix2.V20 + matrix1.V23 * matrix2.V30,
                V21 = matrix1.V20 * matrix2.V01 + matrix1.V21 * matrix2.V11 + matrix1.V22 * matrix2.V21 + matrix1.V23 * matrix2.V31,
                V22 = matrix1.V20 * matrix2.V02 + matrix1.V21 * matrix2.V12 + matrix1.V22 * matrix2.V22 + matrix1.V23 * matrix2.V32,
                V23 = matrix1.V20 * matrix2.V03 + matrix1.V21 * matrix2.V13 + matrix1.V22 * matrix2.V23 + matrix1.V23 * matrix2.V33,

                V30 = matrix1.V30 * matrix2.V00 + matrix1.V31 * matrix2.V10 + matrix1.V32 * matrix2.V20 + matrix1.V33 * matrix2.V30,
                V31 = matrix1.V30 * matrix2.V01 + matrix1.V31 * matrix2.V11 + matrix1.V32 * matrix2.V21 + matrix1.V33 * matrix2.V31,
                V32 = matrix1.V30 * matrix2.V02 + matrix1.V31 * matrix2.V12 + matrix1.V32 * matrix2.V22 + matrix1.V33 * matrix2.V32,
                V33 = matrix1.V30 * matrix2.V03 + matrix1.V31 * matrix2.V13 + matrix1.V32 * matrix2.V23 + matrix1.V33 * matrix2.V33
            };

            return m;
        }

        public static Vector4 operator *(Matrix4x4 matrix, Vector4 vector)
        {
            return new Vector4(
                matrix.V00 * vector.X + matrix.V01 * vector.Y + matrix.V02 * vector.Z + matrix.V03 * vector.W,
                matrix.V10 * vector.X + matrix.V11 * vector.Y + matrix.V12 * vector.Z + matrix.V13 * vector.W,
                matrix.V20 * vector.X + matrix.V21 * vector.Y + matrix.V22 * vector.Z + matrix.V23 * vector.W,
                matrix.V30 * vector.X + matrix.V31 * vector.Y + matrix.V32 * vector.Z + matrix.V33 * vector.W
                );
        }
    }

}

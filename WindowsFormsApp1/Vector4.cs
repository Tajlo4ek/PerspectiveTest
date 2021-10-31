using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Vector4
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }
        public float W { get; private set; }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static Vector4 NormalizeW(Vector4 vector)
        {
            float x = vector.X / vector.W;
            float y = vector.Y / vector.W;
            float z = vector.Z / vector.W;
            float w = vector.W / vector.W;

            return new Vector4(x, y, z, w);
        }
    }
}

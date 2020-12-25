using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Shortokei
{
    [SerializableAttribute, XmlInclude(typeof(Color))]
    public struct ColorEx
    {
        /// <summary>
        /// 透明度
        /// </summary>
        public int A { get; set; }

        /// <summary>
        /// 赤度
        /// </summary>
        public int R { get; set; }

        /// <summary>
        /// 緑度
        /// </summary>
        public int G { get; set; }

        /// <summary>
        /// 青度
        /// </summary>
        public int B { get; set; }

        public static ColorEx FromArgb(int a, int r, int g, int b)
        {
            return new ColorEx() { A = a, R = r, G = g, B = b };
        }

        public ColorEx ToRgb()
        {
            return new ColorEx() { A = 255, R = R, G = G, B = B };
        }

        public static implicit operator Color(ColorEx data)
        {
            // 変換コード
            return Color.FromArgb(data.A, data.R, data.G, data.B);
        }

        public static implicit operator ColorEx(Color data)
        {
            // 変換コード
            return ColorEx.FromArgb(data.A, data.R, data.G, data.B);
        }

        public static bool operator ==(Color v1, ColorEx v2)
        {
            return v1.A == v2.A && v1.R == v2.R && v1.B == v2.B && v1.G == v2.G;
        }

        public static bool operator ==(ColorEx v1, ColorEx v2)
        {
            return v1.A == v2.A && v1.R == v2.R && v1.B == v2.B && v1.G == v2.G;
        }

        public static bool operator !=(Color v1, ColorEx v2)
        {
            return v1.A != v2.A || v1.R != v2.R || v1.B != v2.B || v1.G != v2.G;
        }

        public static bool operator !=(ColorEx v1, ColorEx v2)
        {
            return v1.A != v2.A || v1.R != v2.R || v1.B != v2.B || v1.G != v2.G;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return A ^ R ^ G ^ B;
        }
    }
}

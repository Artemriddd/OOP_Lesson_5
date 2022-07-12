using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lesson_5
{
    internal class CompNumber
    {
        private int _x;
        private int _y;

        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }

        public CompNumber(int a, int b)
        {
            X = a;
            Y = b;
        }
        public static CompNumber operator +(CompNumber n1, CompNumber n2)
        {
            return new CompNumber(n1.X + n2.X, n1.Y + n2.Y);
        }
        public static CompNumber operator -(CompNumber n1, CompNumber n2)
        {
            return new CompNumber(n1.X - n2.X, n1.Y - n2.Y);
        }
        public static CompNumber operator *(CompNumber n1, CompNumber n2)
        {
            return new CompNumber((n1.X * n2.X) - (n1.Y * n2.Y), (n1.X * n2.Y) + (n2.X * n1.Y));
        }
        public static bool operator ==(CompNumber n1, CompNumber n2)
        {
            return (n1.X == n2.X && n1.Y == n2.Y);
        }
        public static bool operator !=(CompNumber n1, CompNumber n2)
        {
            return (n1.X != n2.X || n1.Y != n2.Y);
        }
        public override bool Equals(object? obj)
        {
            if (obj is CompNumber number) return X == number.X && Y == number.Y;
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
        public override string ToString()
        {
            string txt = $"{X}+({Y})i";
            return txt;
        }

    }
}


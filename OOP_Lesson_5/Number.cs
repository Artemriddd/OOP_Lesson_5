using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lesson_5
{
    class Number
    {
        private int _x;

        private int _y;

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (value <= 0) throw new Exception("Знаменатель меньше или равен 0");
                _y = value;
            }
        }
        public Number(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Number number) return X == number.X && Y == number.Y;
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
        public static bool operator ==(Number n1, Number n2)
        {
            return (n1.X == n2.X && n1.Y == n2.Y);
        }
        public static bool operator !=(Number n1, Number n2)
        {
            return (n1.X != n2.X || n1.Y != n2.Y);
        }
        public static bool operator >(Number n1, Number n2)
        {
            return (n1.X > n2.X && n1.Y == n2.Y);
        }
        public static bool operator <(Number n1, Number n2)
        {
            return (n1.X < n2.X || n1.Y == n2.Y);
        }
        public static bool operator >=(Number n1, Number n2)
        {
            return (n1.X >= n2.X && n1.Y == n2.Y);
        }
        public static bool operator <=(Number n1, Number n2)
        {
            return (n1.X <= n2.X || n1.Y == n2.Y);
        }
        public static Number operator +(Number n1, Number n2)
        {
            int Y_common; // Общий знаменатель
            int i = 2; // Множитель для поиска наименьшего общего знаменателя
            if (n1.Y > n2.Y) // Поиск большего знаменателя
            {
                if (n1.Y % n2.Y == 0) // Если знаменатели деляться друг на друга без остатка
                {
                    i = n1.Y / n2.Y; // Множитель равен отношению знаменателей

                    return CutNumber(new Number((n1.X) + (n2.X * i), n1.Y)); // Домнажаем числитель с меньшим знаменателем
                }
                while (true) // Поиск наименьшего общего знаменателя, в наихудшем случае наименьший общий знаменатель равен перемножению знаменателей, следует цикл бесконечным быть не может
                {
                    Y_common = n1.Y * i;
                    if (Y_common % n2.Y == 0)
                    {
                        break;
                    }
                    i++;
                }
                return CutNumber(new Number((n1.X * i) + (n2.X * (i + 1)), Y_common));
            }
            else
            {
                if (n2.Y % n1.Y == 0)
                {
                    i = n2.Y / n1.Y;
                    return CutNumber(new Number((n1.X * i) + (n2.X), n2.Y));
                }
                while (true)
                {
                    Y_common = n2.Y * i;
                    if (Y_common % n1.Y == 0)
                    {
                        break;
                    }
                    i++;
                }
                return CutNumber(new Number((n1.X * (i + 1)) + (n2.X * i), Y_common));
            }

        }
        public static Number operator -(Number n1, Number n2)
        {
            int Y_common; 
            int i = 2; 
            if (n1.Y > n2.Y) 
            {
                if (n1.Y % n2.Y == 0) 
                {
                    i = n1.Y / n2.Y; 
                    return CutNumber(new Number((n1.X) - (n2.X * i), n1.Y));
                }
                while (true) 
                {
                    Y_common = n1.Y * i;
                    if (Y_common % n2.Y == 0)
                    {
                        break;
                    }
                    i++;
                }
                return CutNumber(new Number((n1.X * i) - (n2.X * (i + 1)), Y_common));
            }
            else
            {
                if (n2.Y % n1.Y == 0)
                {
                    i = n2.Y / n1.Y;
                    return CutNumber(new Number((n1.X * i) - (n2.X), n2.Y));
                }
                while (true)
                {
                    Y_common = n2.Y * i;
                    if (Y_common % n1.Y == 0)
                    {
                        break;
                    }
                    i++;
                }
                return CutNumber(new Number((n1.X * (i + 1)) - (n2.X * i), Y_common));
            }
        }
        public static Number operator ++(Number n1)
        {
            return new Number(n1.X + 1, n1.Y);
        }
        public static Number operator --(Number n1)
        {
            return new Number(n1.X - 1, n1.Y);
        }
        public static Number operator *(Number n1, Number n2)
        {
            return new Number(n1.X * n2.X, n1.Y * n2.Y);
        }
        public static Number operator /(Number n1, Number n2)
        {
            return new Number(n1.X * n2.Y, n1.Y * n2.X);
        }
        public static Number operator %(Number n1, Number n2)
        {
            int Y_common; // Общий знаменатель
            int i = 2; // Множитель для поиска наименьшего общего знаменателя
            if (n1.Y > n2.Y) // Поиск большего знаменателя
            {
                if (n1.Y % n2.Y == 0) // Если знаменатели деляться друг на друга без остатка
                {
                    i = n1.Y / n2.Y; // Множитель равен отношению знаменателей
                    return CutNumber(new Number((n1.X) % (n2.X * i), n1.Y)); // Домнажаем числитель с меньшим знаменателем
                }
                while (true) // Поиск наименьшего общего знаменателя, в наихудшем случае наименьший общий знаменатель равен перемножению знаменателей, следует цикл бесконечным быть не может
                {
                    Y_common = n1.Y * i;
                    if (Y_common % n2.Y == 0)
                    {
                        break;
                    }
                    i++;
                }
                return CutNumber(new Number((n1.X * i) % (n2.X * (i + 1)), Y_common));
            }
            else
            {
                if (n2.Y % n1.Y == 0)
                {
                    i = n2.Y / n1.Y;
                    return CutNumber(new Number((n1.X * i) % (n2.X), n2.Y));
                }
                while (true)
                {
                    Y_common = n2.Y * i;
                    if (Y_common % n1.Y == 0)
                    {
                        break;
                    }
                    i++;
                }
                return CutNumber(new Number((n1.X * (i + 1)) % (n2.X * i), Y_common));
            }
        }
        public static implicit operator float(Number number)
        {
            return (float)number.X / number.Y;
        }
        public static implicit operator int(Number number)
        {
            return number.X / number.Y;
        }


        /// <summary>
        /// Алгоритм Евклида для сокращения дробей
        /// </summary>
        /// <param name="n1"></param>
        /// <returns></returns>
        public static Number CutNumber(Number n1)
        {
            int d;
            int a;
            int b;
            if (n1.X < n1.Y)
            {
                b = n1.X;
                a = n1.Y;
            }
            else
            {
                b = n1.Y;
                a = n1.X;
            }
            while (true)
            {
                if (a % b == 0)
                {
                    return new Number(n1.X / b, n1.Y / b);
                }
                d = a % b;
                a = b;
                b = d;
            }
        }
        public override string ToString()
        {
            string txt = $"{X}/{Y}";
            return txt;
        }

    }
}

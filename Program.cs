using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        class RationalNumber : IComparable
        {
            private int N;
            private int M;
            public char[] sep = { ' ', '/', ':' };
            public RationalNumber()
            {
                N = 0;
                M = 0;
            }
            public RationalNumber(int n, int m)
            {
                N = n;
                M = m;
            }
            public RationalNumber(string s)
            {
                s = s.Trim();
                while (s.Contains("  "))
                    s = s.Replace("  ", " ");
                string[] result = s.Split(sep);
                N = Convert.ToInt32(result[0]);
                M = Convert.ToInt32(result[1]);
            }

            public void Print()
            {
                Console.WriteLine(N + "/" + M);
            }
            public override string ToString()
            {
                return N + "/" + M;
            }

            public static implicit operator int(RationalNumber rationalNumber)
            {
                return rationalNumber.N / rationalNumber.M;
            }

            public static explicit operator double(RationalNumber rationalNumber)
            {
                return rationalNumber.N / rationalNumber.M;
            }

            public static RationalNumber operator +(RationalNumber rationalNumber1, RationalNumber rationalNumber2)
            {
                RationalNumber result = new RationalNumber();
                result.N = (rationalNumber1.N * rationalNumber2.M) + (rationalNumber2.N * rationalNumber1.M);
                result.M = rationalNumber1.M * rationalNumber2.M;
                return result;
            }

            public static RationalNumber operator -(RationalNumber rationalNumber1, RationalNumber rationalNumber2)
            {
                RationalNumber result = new RationalNumber();
                result.N = (rationalNumber1.N * rationalNumber2.M) - (rationalNumber2.N * rationalNumber1.M);
                result.M = rationalNumber1.M * rationalNumber2.M;
                return result;
            }

            public static RationalNumber operator *(RationalNumber rationalNumber1, RationalNumber rationalNumber2)
            {
                RationalNumber result = new RationalNumber();
                result.N = rationalNumber1.N * rationalNumber2.N;
                result.M = rationalNumber1.M * rationalNumber2.M;
                return result;
            }

            public static RationalNumber operator /(RationalNumber rationalNumber1, RationalNumber rationalNumber2)
            {
                RationalNumber result = new RationalNumber();
                result.N = rationalNumber1.N * rationalNumber2.M;
                result.M = rationalNumber1.M * rationalNumber2.N;
                return result;
            }

            public int CompareTo(object obj)
            {
                RationalNumber rationalNum = obj as RationalNumber;
                return (this.N / this.M).CompareTo(rationalNum.N / rationalNum.M);
            }

            public static bool operator <(RationalNumber rationalNumber1, RationalNumber rationalNumber2)
            {
                return rationalNumber1.CompareTo(rationalNumber2) < 0;
            }
            public static bool operator >(RationalNumber rationalNumber1, RationalNumber rationalNumber2)
            {
                return rationalNumber1.CompareTo(rationalNumber2) > 0;
            }
            public static bool operator !=(RationalNumber rationalNumber1, RationalNumber rationalNumber2)
            {
                return rationalNumber1.CompareTo(rationalNumber2) != 0;
            }
            public static bool operator ==(RationalNumber rationalNumber1, RationalNumber rationalNumber2)
            {
                return rationalNumber1.CompareTo(rationalNumber2) == 0;
            }
        }

        static void Main(string[] args)
        {
            RationalNumber rationalNumber1 = new RationalNumber(1, 4);
            RationalNumber rationalNumber2 = new RationalNumber(" 20/3");
            rationalNumber1.Print();
            Console.WriteLine(rationalNumber2.ToString());
            int intValue = rationalNumber1;
            double doubleValue = (double)rationalNumber2;

            Console.WriteLine("Целая часть первого числа(int): " + intValue);
            Console.WriteLine("Целое часть второго числа(double): " + doubleValue);
            Console.WriteLine((rationalNumber1 + rationalNumber2).ToString());
            Console.WriteLine((rationalNumber1 - rationalNumber2).ToString());
            Console.WriteLine((rationalNumber1 * rationalNumber2).ToString());
            Console.WriteLine((rationalNumber1 / rationalNumber2).ToString());
            Console.WriteLine(rationalNumber1 < rationalNumber2);
            Console.WriteLine(rationalNumber1 > rationalNumber2);
            Console.WriteLine(rationalNumber1 == rationalNumber2);

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интерфейсы
{
    interface IMath
    {
        IMath Sum(IMath x);
        IMath Sub(IMath x);
        IMath Muth_Value(double x);
        IMath Dev_Value(double x);
        void Print();
    }
    interface IArray
    {
        int Lenghs { get; }
        double this[int i] { get; set; }
    }
    class Equation : IMath
    {
        protected double a, b, c;
        public Equation() { }
        public Equation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public IMath Sum(IMath x)
        {
            Equation temp = x as Equation;
            return new Equation(a + temp.a, b + temp.b, c + temp.c);
        }
        public IMath Sub(IMath x)
        {
            Equation temp = x as Equation;
            return new Equation(a - temp.a, b - temp.b, c - temp.c);
        }
        public IMath Muth_Value(double x)
        {
            return new Equation(a * x, b * x, c * x);
        }
        public IMath Dev_Value(double x)
        {
            return new Equation(a / x, b / x, c / x);
        }
        public void Print()
        {
            Console.WriteLine($"{a}*x^2 + {b}*x + {c}");
        }
    }
    class Polin : IMath, IArray
    {
        double[] a;
        int lenghs;
        public Polin() { }
        public Polin(int n)
        {
            a = new double[n];
            lenghs = n;
        }
        public Polin(double[] x)
        {
            a = new double[x.Length];
            lenghs = x.Length;
            for (int i = 0; i < lenghs; i++)
                a[i] = x[i];
        }
        public int Lenghs
        {
            get => lenghs;
        }
        public double this[int i]
        {
            get
            {
                if (i < 0 || i >= lenghs)
                    throw new Exception("Ingext out of range");
                return a[i];
            }
            set
            {
                if (i < 0 || i >= lenghs)
                    throw new Exception("Ingext out of range");
                a[i] = value;
            }
        }

        public IMath Sum(IMath x)
        {
            Polin temp = x as Polin;
            Polin z;
            if (lenghs > temp.Lenghs)
                z = new Polin(lenghs);
            else
                z = new Polin(temp.Lenghs);
            for (int i = 0; i < lenghs; i++)
                z[i] = a[i];
            for (int i = 0; i < temp.Lenghs; i++)
                z[i] += temp[i];
            return z;
        }
        public IMath Sub(IMath x)
        {
            Polin temp = x as Polin;
            Polin z;
            if (lenghs > temp.Lenghs)
                z = new Polin(lenghs);
            else
                z = new Polin(temp.Lenghs);
            for (int i = 0; i < lenghs; i++)
                z[i] = a[i];
            for (int i = 0; i < temp.Lenghs; i++)
                z[i] -= temp[i];
            return z;
        }
        public IMath Muth_Value(double x)
        {
            Polin z = new Polin(lenghs);
            for (int i = 0; i < lenghs; i++)
                z[i] = a[i] * x;
            return z;
        }
        public IMath Dev_Value(double x)
        {
            Polin z = new Polin(lenghs);
            for (int i = 0; i < lenghs; i++)
                z[i] = a[i] / x;
            return z;
        }
        string ToString()
        {
            string s = "";
            s += a[0];
            for (int i = 1; i < lenghs; i++)
                s += " + " + a[i] + "*x^" + i;
            return s;
        }
        public void Print()
        {
            string s = ToString();
            Console.WriteLine(s);
        }
    }
}

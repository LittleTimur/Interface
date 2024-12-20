namespace Интерфейсы
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] a = new double[] { 5, 6, 2, 7, 2, 8, 1};
            double[] a1 = new double[] { 5, 9, 2, 7, 2, 8, 5, 10, 35};
            IMath x = new Polin(a);
            IMath y = new Polin(a1);
            IMath z = x.Sub(y);
            IMath p = x.Sum(y);
            x.Print();
            y.Print();
            z.Print();
            p.Print();
            IMath x1 = new Equation(1, 2, 1);
            IMath y1 = new Equation(9, 6, 1);
            x1.Print();
            y1.Print();
            IMath z1 = x1.Sub(y1);
            IMath p1 = x1.Sum(y1);
            z1.Print();
            p1.Print();
            IMath[] All = new IMath[] { new Polin(a), new Equation(1, 2, 1), new Polin(a1), new Equation(9, 6, 1) };
            IMath eq = new Equation();
            IMath pl = new Polin();
            foreach(IMath all in All)
            {
                if (all is Polin)
                    pl = pl.Sum(all);
                else
                    eq = eq.Sum(all);
            }
            pl.Print();
            eq.Print();

        }
    }
}

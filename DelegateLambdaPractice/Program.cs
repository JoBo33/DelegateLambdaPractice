using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLambdaPractice
{
    internal class Program
    {

        public delegate double Operator(double a, double b);

        public static double add(double a, double b)
        {
            return a + b;
        }
        public static double sub(double a, double b)
        {
            return a - b;
        }
        public static double mul(double a, double b)
        {
            return a * b;
        }
        public static double div(double a, double b)
        {
            return a / b;
        }
        public static double mod(double a, double b)
        {
            return a % b;
        }
        public static double nu(double a, double b)
        {
            return 0;
        }

        public static double Calculate(double a, double b, char opr)
        {
            var opDel = new Operator(nu);

            switch (opr)
            {
                case ('+'):
                    opDel = add; // alternatively opDel = new Calculate(add);
                    break;
                case ('-'):
                    opDel = sub; // alternatively opDel = new Calculate(sub);
                    break;
                case ('*'):
                    opDel = mul; // alternatively opDel = new Calculate(mul);
                    break;
                case ('/'):
                    opDel = div; // alternatively opDel = new Calculate(div);
                    break;
                case ('%'):
                    opDel = mod; // alternatively opDel = new Calculate(mod);
                    break;
                default:
                    opDel = nu; // alternatively opDel = new Calculate(nu);
                    break;
            }

            return opDel(a, b);
        }



        /* Func is a generic delegate included in the System namespace. 
         * It has zero or more input parameters and one out parameter (the last one).
         * Here: the first 2 double parameters are input parameters and the third is the output parameter.
         * public delegate GetOperator(methodsParams) Func<in T1, in T2, out double>(T1 arg, T2 arg)
         * On call -> GetOperator(char opr)(double a, double b);
         */
        public static Func<double, double, double> GetOperator(char opr)
        {
            if (opr == '+')
                return (x, y) => x + y;
            if (opr == '-')
                return (x, y) => x - y;
            if (opr == '*')
                return (x, y) => x * y;
            if (opr == '/')
                return (x, y) => x / y;
            if (opr == '%')
                return (x, y) => x % y;
            return (x, y) => 0;
        }






        static void Main(string[] args)
        {
            Console.WriteLine(Calculate(8, 4, '+'));
            Console.WriteLine(Calculate(8, 4, '-'));
            Console.WriteLine(Calculate(8, 4, '*'));
            Console.WriteLine(Calculate(8, 4, '/'));
            Console.WriteLine(Calculate(8, 4, '%'));
            Console.WriteLine(Calculate(8, 4, 'i'));


            Console.WriteLine(GetOperator('*')(8, 9));
            Console.ReadLine();
        }
    }
}

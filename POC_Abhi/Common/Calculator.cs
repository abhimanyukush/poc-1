using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Calculator
    {
        public static int Add(int a,int b)
        {
            return a + b;
        }
        public static int Add(int a, int b,int c)
        {
            return a + b + c;
        }
        public static float Multiply(int a, int b)
        {
            return a * b;
        }
        public static float Divide(int a, int b)
        {
            return a / b;
        }
        public static int Fibonaci(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            else
                return n * Fibonaci(n - 1); 
        }
       
    }
}

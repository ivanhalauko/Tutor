using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Final cal = new Final();
            Console.WriteLine(new string('_', 20));
            double[] calarray = cal.AddArray();
            double[] result = cal.CalArray(calarray);
            Console.WriteLine(new string('_', 20));
            cal.ShowArray(result);
            Console.WriteLine(new string('_', 20));
            double[] res = cal.CountArray(data);
            cal.ShowArray(res);
            Console.WriteLine(new string('_', 20));
            cal.MyReverse(result);
        }
    }
    class Final
    {
        public double Add()
        {
            double x;
            x = Convert.ToDouble(Console.ReadLine());
            return x;
        }
        public double Cal(double param)
        {
            double cal;
            cal = (param);
            return cal;
        }
        public void Show(double cal)
        {
            Console.WriteLine(cal);
        }
        public double[] AddArray()
        {
             double start = 0;
            double end = 0;
            int quantity = 0;
            Final cal = new Final();
            for (int i = 0; i < 3; i++)
            {
                if (i==0)
                {
                    Console.WriteLine("Add first element");
                    start = cal.Add();
                }
                else if (i==1)
                {
                    Console.WriteLine("Add second element");
                    end = cal.Add();
                }
                else if (i == 2)
                {
                    Console.WriteLine("Add qountity elements");
                    quantity = Convert.ToInt32(cal.Add());
                }
            }
            double step = (end - start) / quantity;
            double[] array = new double[quantity];
            double temp = start;
            for (int i = 0; i < quantity; i++)
            {
                array[i] = temp;
                temp = temp + step;
            }
            return array;
        }
        public double[] CalArray(double[] array)
        {
            Final cal = new Final();
            double[] result = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                double param = array[i];
                result[i] = cal.Cal(param);
            }
            return result;
        }
        public void ShowArray(double[] result)
        {
            Final cal = new Final();
            for (int i = 0; i < result.Length; i++)
            {
                cal.Show(result[i]);
            }
        }
        public double[] CountArray(double [] result)
        {
            int k = 2;
            double[] data = new double[k];
            for (int i = 0; i < data.Length; i++)
            {
                double ostatok = data[i] % 2;
                if (ostatok == 0)
                {
                    double element = data[i];
                    k++;
                    result = new double[k];
                    result[k] = element;
                }
            }
            return result;
        }
        internal void MyReverse(double[] result)
        {
            Console.WriteLine("Reverse");
            Array.Reverse(result);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}

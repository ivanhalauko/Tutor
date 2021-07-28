using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculation calculation = new Calculation();
            double[] calarray = calculation.AddArray();
            double[] result=calculation.CalArray(calarray);
            calculation.ShowArray(result);
            int dataLength = calculation.GetLength(result);
            calculation.ShowArray(dataLength);
            Console.WriteLine(new string('_',20));
            int datsRank = calculation.GetRank(result);
            calculation.ShowArray(datsRank);
            Console.WriteLine(new string('_', 20));
            // double[] countData = calculation.GetCountablNumbers(result);
            //calculation.ShowArray(countData);
            calculation.ShowArrayWithForeach(result);
        }
    }
    class Calculation
    {
        public double Add()
        {
            double x;
             x= Convert.ToDouble(Console.ReadLine());
            return x;
        }

        internal double Cal(double param)
        {
            double cal;
            cal = (param);
            return cal;
        }

        internal void Show(double cal)
        {
            Console.WriteLine(cal);
        }
        public double[] AddArray()
        {
            double start=0;
            double end=0;
            int qountity=0;
           // double[] array=null;
            Calculation calculation = new Calculation();
            for (int i = 0; i < 3; i++)
            {
                if (i==0)
                {
                    Console.WriteLine("Enter first element");
                    start=calculation.Add();
                }
                else if (i==1)
                {
                    Console.WriteLine("Enter last element");
                    end = calculation.Add();
                }
                else if (i==2)
                {
                    Console.WriteLine("Enter qountity elements");
                    qountity =Convert.ToInt32(calculation.Add());
                }
            }
            double step = (end - start) / qountity;
            double[] array = new double[qountity];
            double temp = start;
            for (int i = 0; i < qountity; i++)
            {
                array[i] = temp;
                temp=temp + step;
            }
            return array;
        }
        public double[] CalArray(double[] array)
        {
            Calculation calculation = new Calculation();
            double[] result=new double[array.Length] ;
            for (int i = 0; i < array.Length; i++)
            {
                double param=array[i];
                result[i] =calculation.Cal(param);
            }
            return result;
        }

        internal void ShowArray(double[] result)
        {
            Calculation calculation = new Calculation();
            for (int i = 0; i < result.Length; i++)
            {
                calculation.Show(result[i]);
            }
        }
        public int GetLength(double[] data)
        {
            int result=0;
            result=data.Length;
            return result;
        }
        public void ShowArray(int dataLength)
        {
            Console.WriteLine(dataLength);
        }
        public int GetRank(double [] dats)
        {
            int result = 0;
            result = dats.Rank;
            return result;
        }
        public double [] GetCountablNumbers(double [] data)
        {
            double[] result=new double[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                double ostatok = data[i] % 2;
                if (ostatok==0)
                {
                    double element = data[i];
                    result[i] = element;
                }
            }
            return result;
        }
        public void ShowArrayWithForeach(double [] data)
        {
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
    }
}

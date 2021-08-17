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
            Console.WriteLine(new string('_', 20));
            calculation.ShowFindArray();
            Console.WriteLine(new string('_', 20));
            calculation.GetRandomArray();
            double[] calarray = calculation.AddArray();
            double[] result=calculation.CalArray(calarray);
            calculation.ShowArray(result);
            int dataLength = calculation.GetLength(result);
            calculation.ShowArray(dataLength);
            Console.WriteLine(new string('_',20));
            int datsRank = calculation.GetRank(result);
            calculation.ShowArray(datsRank);
            Console.WriteLine(new string('_', 20));
            double[] countData = calculation.GetCountablNumbers(result);
            calculation.ShowArray(countData);
            Console.WriteLine(new string('_', 20));
            calculation.ShowArrayWithForeach(result);
            Console.WriteLine(new string('_', 20));
            calculation.ShowReverseArray(result);
            Console.WriteLine(new string('_', 20));
            calculation.ShowCopyArray(result);
            Console.WriteLine(new string('_', 20));
            calculation.ShowSortArray();
           
            Console.WriteLine(new string('_', 20));
            calculation.ShowClearArray(result);
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
            Console.WriteLine("Countabl Numbers");
            int k = 2;
            double[] result=new double[k];
            for (int i = 0; i < data.Length; i++)
            {
                double ostatok = data[i] % 2;
                if (ostatok==0)
                {
                    double element = data[i];
                    k++;
                    result = new double[k];
                    result[k] = element;
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
        public void ShowClearArray(double[] data)
        {
            Console.WriteLine("Array clear");
            Array.Clear(data, 0, data.Length);
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
        public double[] GetCountNum(double[] data)
        {
            double[] result = new double[2];
            for (int i = 0; i < data.Length; i++)
            {
                double ost = data[i] % 1;
                if (ost==0)
                {
                    double elem = data[i];
                    result[i] = elem;
                }
            }
            return result;
        }
        public void ShowCopyArray(double[] array)
        {
            double[] res = new double[array.Length];
            Console.WriteLine("Array copy");
            Array.Copy(array, 0,res, 0, res.Length);//
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
        public void ShowReverseArray(double [] data)
        {
            Console.WriteLine("Array reverse");
            Array.Reverse(data);
            double[] result = new double[5];
            Array.Copy(data, 5,result,0,result.Length);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        public void ShowSortArray()
        {
            Console.WriteLine("Array sort");
            double[] res = {-5,2,5,6,2,12,4,1,0,22,-43};
            Array.Sort(res);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
        public void ShowFindArray()
        {
            Console.WriteLine("Array find");
            double[] res = { 5, 25, 2, 6, 2, 1, 5, 6, 6, 8, 4, 5, 6, 4, 2, 1, 1, 5, 6, 4, 47, 1 };
            double m = 5;
            double k = 10;
           double[] elems=Array.FindAll(res, i=>i==m && i==k);
            foreach (var item in elems)
            {
                Console.WriteLine(item);
            }
        }
        public void  GetRandomArray()
        {
            Console.WriteLine("Random");
            var rand = new Random();
            byte[] elems = new byte[5];
            rand.NextBytes(elems);
            foreach (var item in elems)
            {
                Console.WriteLine(item);
            }
        }
    }
}

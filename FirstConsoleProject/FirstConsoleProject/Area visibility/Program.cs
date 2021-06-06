using System;

namespace Area_visibility
{
    class Program
    {
        static void Main(string[] args)
        {
            int b=5;
            {
                int a;
                b +=3;
                Console.WriteLine(b);
            }
            {
                int a;
                //int a;
                b += 4;
                Console.WriteLine(b);
            }
            
         
        }
    }
}

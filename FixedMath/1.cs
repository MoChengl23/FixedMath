using System;

namespace FixedMath
{
    class Program
    {
        static void Main(string[] args)
        {

            FixedInt a = 2;
            FixedInt b = (FixedInt)0.5f;
            FixedInt c = a/b;
            Console.WriteLine(c.ToString());

        Console.ReadKey();


                   }
    }
}

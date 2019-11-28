using System;

namespace Naming.Task3
{
    public class H
    {
        // print some Harshad numbers
        private static void Main(string[] args)
        {
            long l = 1000; // limit the seq of Harshad numbers
            for (int i = 1; i <= l; i++)
            {
                if (i % Loop(i) == 0)
                {
                    Console.WriteLine(i);
                }
            }

            Console.Write("Press key...");
            Console.ReadKey();
        }

        private static int Loop(int n)
        {
            int s = 0;
            while (n != 0)
            {
                s += n % 10;
                n = n / 10;
            }
            return s;
        }
    }
}

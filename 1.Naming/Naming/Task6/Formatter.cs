using System;
using System.Linq;

namespace Naming.Task6
{
    public static class Formatter
    {
        private const string Plus = "+";
        private const string Pipe = "|";
        private const string Minus = "-";
        private const string Underscore = " _ ";

        public static void Main(string[] args)
        {
            Console.WriteLine(FormatKyeValue("enable", "true"));
            Console.WriteLine(FormatKyeValue("name", "Bob"));

            Console.Write("Press key...");
            Console.ReadKey();
        }

        private static string FormatKyeValue(string key, string value)
        {
            string content = key + Underscore + value;
            string minuses = Repeat(Minus, content.Length);
            return Plus + minuses + Plus + "\n" +
                   Pipe + content + Pipe + "\n" +
                   Plus + minuses + Plus + "\n";
        }

        private static string Repeat(string symbol, int times)
        {
            return string.Join(string.Empty, Enumerable.Repeat(symbol, times));
        }
    }
}

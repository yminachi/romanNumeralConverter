using System;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var converter = new RomanArabicNumeralConverter();
            while (true)
            {
                Console.WriteLine("Please input Roman or Arabic numeral for conversion:");
                string input = Console.ReadLine();
                int numeral;
                try
                {
                    if (Int32.TryParse(input, out numeral))
                    {
                        Console.WriteLine("Roman Numeral: " + converter.ConvertArabicToRoman(numeral));
                    }
                    else
                    {
                        Console.WriteLine("Arabic Numeral: " + converter.ConvertRomanToArabic(input));
                    }
                }
                catch (RomanNumeralNotValidExeption e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("\n");
            }

        }
    }
}

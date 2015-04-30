using System;

namespace Kata
{
    public class RomanNumeralNotValidExeption : Exception
    {
        public RomanNumeralNotValidExeption()
            :base("Roman Numeral Coversion Error: Input Not Valid")
        {
        }
    }
}

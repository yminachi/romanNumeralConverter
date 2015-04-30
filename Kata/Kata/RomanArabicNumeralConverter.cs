using System;

namespace Kata
{
    public class RomanArabicNumeralConverter
    {
        private readonly char[] _tens = { 'I', 'X', 'C', 'M' };
        private readonly char[] _fives = { 'V', 'L', 'D' };

        public string ConvertArabicToRoman(int arabicNumeral)
        {
            if (arabicNumeral <= 0) throw new RomanNumeralNotValidExeption();
            if (arabicNumeral >= 4000) throw new RomanNumeralNotValidExeption();

            var romanNumeral = "";
            var numDigits = arabicNumeral.ToString().Length;

            for (var i = numDigits - 1; i >= 0; i-- )
            {
                var digit = (int)(arabicNumeral / Math.Pow(10, i));
                arabicNumeral -= digit * (int)Math.Pow(10, i);

                if (digit == 9)
                {
                    romanNumeral += _tens[i].ToString() +_tens[i + 1].ToString();
                    continue;
                }
                if (digit == 4)
                {
                    romanNumeral += _tens[i].ToString() + _fives[i].ToString();
                    continue;
                }
                if (digit >= 5)
                {
                    romanNumeral += _fives[i].ToString();
                    digit -= 5;
                }

                for (int j = 0; j < digit; j++)
                {
                    romanNumeral += _tens[i].ToString();
                }
            }
            return romanNumeral;
        }

        public int ConvertRomanToArabic(string romanNumeral)
        {
            var arabicNumeral = 0;

            int lastTensIndex = -1;
            int lastFivesIndex = -1;
            int timesRepeted = 0;

            for (int i = romanNumeral.Length - 1; i >= 0; i--)
            {
                var tensIndex = Array.IndexOf(_tens, romanNumeral[i]);
                var fivesIndex = Array.IndexOf(_fives, romanNumeral[i]);

                //check if digit is valid
                if (tensIndex == -1 && fivesIndex == -1) throw new RomanNumeralNotValidExeption();
                if ((tensIndex != -1 && tensIndex < lastFivesIndex) || (tensIndex != -1 && tensIndex < lastTensIndex - 1) ||
                    (fivesIndex != -1 && fivesIndex < lastTensIndex) || (fivesIndex != -1 && fivesIndex < lastFivesIndex))
                {
                    throw new RomanNumeralNotValidExeption();
                }
                if (tensIndex != -1 && tensIndex == lastTensIndex) timesRepeted++;
                else timesRepeted = 0;

                if (fivesIndex != -1 && fivesIndex == lastFivesIndex) throw new RomanNumeralNotValidExeption();
                if (timesRepeted >= 3) throw new RomanNumeralNotValidExeption();

                //convert digit
                if (tensIndex != -1 && (tensIndex == lastTensIndex - 1 || tensIndex == fivesIndex))
                {
                    arabicNumeral -= (int)Math.Pow(10, tensIndex);
                }
                else
                {
                    arabicNumeral += (tensIndex != -1) ? (int)Math.Pow(10, tensIndex) : (int)Math.Pow(10, fivesIndex) * 5;
                }

                lastTensIndex = tensIndex;
                lastFivesIndex = fivesIndex;
            }

            return arabicNumeral;
        }
    }
}

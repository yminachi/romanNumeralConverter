using System;
using Kata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class RomanArabicNumeralConverterTests
    {
        RomanArabicNumeralConverter converter = new RomanArabicNumeralConverter();

        [TestMethod]
        public void WhenPassed1ReturnsI()
        {
            Assert.AreEqual("I", converter.ConvertArabicToRoman(1));
        }
        
        [TestMethod]
        public void WhenPassed3ReturnsIII()
        {
            Assert.AreEqual("III", converter.ConvertArabicToRoman(3));
        }

        [TestMethod]
        public void WhenPassed9ReturnsIX()
        {
            Assert.AreEqual("IX", converter.ConvertArabicToRoman(9));
        }

        [TestMethod]
        public void WhenPassed1066ReturnsMLXVI()
        {
            Assert.AreEqual("MLXVI", converter.ConvertArabicToRoman(1066));
        }

        [TestMethod]
        public void WhenPassed1986ReturnsMCMLXXXIX()
        {
            Assert.AreEqual("MCMLXXXIX", converter.ConvertArabicToRoman(1989));
        }

        [TestMethod]
        public void WhenPassedIReturns1()
        {
            Assert.AreEqual(1, converter.ConvertRomanToArabic("I"));
        }

        [TestMethod]
        public void WhenPassedIIIReturns3()
        {
            Assert.AreEqual(3, converter.ConvertRomanToArabic("III"));
        }

        [TestMethod]
        public void WhenPassedIXReturns9()
        {
            Assert.AreEqual(9, converter.ConvertRomanToArabic("IX"));
        }

        [TestMethod]
        public void WhenPassedMLXVIReturns1066()
        {
            Assert.AreEqual(1066, converter.ConvertRomanToArabic("MLXVI"));
        }

        [TestMethod]
        public void WhenPassedMCMLXXXIXReturns1989()
        {
            Assert.AreEqual(1989, converter.ConvertRomanToArabic("MCMLXXXIX"));
        }

        [TestMethod]
        [ExpectedException(typeof(RomanNumeralNotValidExeption))]
        public void WhenPassedNegativeNumeralThrowsExpection()
        {
            converter.ConvertArabicToRoman(-3);
        }

        [TestMethod]
        [ExpectedException(typeof(RomanNumeralNotValidExeption))]
        public void WhenPassedZeroThrowsExpection()
        {
            converter.ConvertArabicToRoman(0);
        }

        [TestMethod]
        [ExpectedException(typeof(RomanNumeralNotValidExeption))]
        public void WhenPassedInvalidCharactersThrowsExpection()
        {
            converter.ConvertRomanToArabic("IIP");
        }

        [TestMethod]
        [ExpectedException(typeof(RomanNumeralNotValidExeption))]
        public void WhenPassedRomanNumeralWithTooManyRepeatingValuesThrowsExection()
        {
            converter.ConvertRomanToArabic("IIII");
        }

        [TestMethod]
        [ExpectedException(typeof(RomanNumeralNotValidExeption))]
        public void WhenPassedRomanNumeralWithRepetingFivesThrowsExpection()
        {
            converter.ConvertRomanToArabic("VV");
        }

        [TestMethod]
        [ExpectedException(typeof(RomanNumeralNotValidExeption))]
        public void WhenPassedRomanNumeralWronglyOrderedLettersThrowsExpection()
        {
            converter.ConvertRomanToArabic("IC");
        }
    }
}

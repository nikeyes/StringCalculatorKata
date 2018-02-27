using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata.src;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.tests
{
    [TestClass]
    public class CalculatorParserShould
    {
        [TestMethod]
        public void Return_Clean_Sumandos()
        {
            CalculatorParser parserString = new CalculatorParser("//;1\n2;3");

            CollectionAssert.AreEqual(new List<int>() { 1, 2, 3 }, parserString.Sumandos.ToList());
        }
    }
}

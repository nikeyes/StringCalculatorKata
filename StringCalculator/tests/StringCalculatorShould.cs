using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata.src;

namespace StringCalculatorKata.tests
{
    [TestClass]
    public class StringCalculatorShould
    {
        [TestMethod]
        public void Return_0_When_Numbers_Are_Empty()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int actual = stringCalculator.Add(String.Empty);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Return_The_Same_Number_When_Pass_Only_One_Number_()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int actual = stringCalculator.Add("1");

            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void Return_The_Sum_When_Pass_Two_Numbers()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int actual = stringCalculator.Add("1,2");

            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void Return_The_Sum_When_Pass_More_Than_Two_Numbers()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int actual = stringCalculator.Add("1,2,3");

            Assert.AreEqual(6, actual);
        }

        [TestMethod]
        public void Return_The_Sum_When_Pass_More_Than_Two_Numbers_With_BreakLine_Separator()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int actual = stringCalculator.Add("1\n2,3");

            Assert.AreEqual(6, actual);
        }

        [TestMethod]
        public void Return_The_Sum_When_Define_Special_Separator_Character()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int actual = stringCalculator.Add("//;1\n2;3");

            Assert.AreEqual(6, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Have_Throw_Exception_When_Negtive_Numbers()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int actual = stringCalculator.Add("//;1\n-2;-3");

            Assert.Fail();
        }

        [TestMethod]
        public void Have_Throw_Exception_With_Negative_Numbers()
        {
            StringCalculator stringCalculator = new StringCalculator();
            try
            {
                int actual = stringCalculator.Add("//;1\n-2;-3");
            }
            catch(ArgumentException ex)
            {
                Assert.AreEqual("negatives not allowed: -2,-3", ex.Message);
            } 
        }

        [TestMethod]
        public void Have_Not_Sum_Numbers_Above_1000()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int actual = stringCalculator.Add("//;1\n2;1001");
            
            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void Have_Delimiter_Of_More_Than_One_Character()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int actual = stringCalculator.Add("//[*****]1*****2*****3");

            Assert.AreEqual(6, actual);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.src
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (String.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            CalculatorParser calculatorParser = new CalculatorParser(numbers);

            if (calculatorParser.IsMultipleNumber())
            {
                return Sum(calculatorParser);
            }
            else
            {
                return calculatorParser.Sumandos.First();
            }
        }
        
        private int Sum(CalculatorParser calculatorParser)
        {
            int suma = 0;

            foreach (int sumando in calculatorParser.Sumandos)
            {
                suma += sumando;
            }

            return suma;
        }
    }
}

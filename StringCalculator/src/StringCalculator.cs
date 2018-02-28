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
            return calculatorParser.Sumandos.Sum();
        }
    }
}

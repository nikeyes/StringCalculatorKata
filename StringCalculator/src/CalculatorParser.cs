using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.src
{
    public class CalculatorParser
    {
        private IEnumerable<int> _sumandosList;

        public IEnumerable<int> Sumandos
        {
            get
            {
                return _sumandosList;
            }
        }
        public CalculatorParser(string numbers)
        {
            CalculatorMapper calculatorMapper = new CalculatorMapper();
            CalculatorValidator calculatorValidator = new CalculatorValidator();

            _sumandosList = calculatorMapper.MapTo(numbers);
            calculatorValidator.Validate(_sumandosList);
        }

        public bool IsMultipleNumber()
        {
            return _sumandosList.Count() > 1;
        }
    }
}
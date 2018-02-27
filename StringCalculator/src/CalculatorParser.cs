using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.src
{
    public class CalculatorParser
    {
        public const char SALTO_DE_LINEA = '\n';
        private const string SPECIAL_DELIMITER = "//";
        private const char DEFAULT_DELIMITER = ',';

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
            char delimiter = DEFAULT_DELIMITER;
            delimiter = GetDelimiter(numbers);
            numbers = ReplaceSaltoDeLineaPorDelimiter(numbers, delimiter);
            numbers = RemoveSpecialDelmiter(numbers);
            _sumandosList = GetListOfInts(numbers, delimiter);
            ValidateSumandos(_sumandosList);
            _sumandosList = RemoveNumbersAbove1000(_sumandosList);
            
        }
       
        public bool IsMultipleNumber()
        {
            return _sumandosList.Count() > 1;
        }

        private void ValidateSumandos(IEnumerable<int> sumandosList)
        {
            int[] negativeSumandos = sumandosList.Where(sumando => sumando < 0).ToArray();
            if (negativeSumandos.Any())
            {
                throw new ArgumentException("negatives not allowed: " + string.Join(",",negativeSumandos));
            }  
        }

        private IEnumerable<int> GetListOfInts(string sumandos, char delimiter)
        {
            return sumandos.Split(delimiter).Select(sumando => int.Parse(sumando));
        }

        private string ReplaceSaltoDeLineaPorDelimiter(string sumandos, char delimiter)
        {
            return sumandos.Replace(SALTO_DE_LINEA, delimiter);
        }
        
        private char GetDelimiter(string sumandos)
        {
            if (sumandos.Contains(SPECIAL_DELIMITER) )
            {
                return sumandos.Substring(2, 1)[0];
            }

            return DEFAULT_DELIMITER;
        }

        private string RemoveSpecialDelmiter(string sumandos)
        {
            if (sumandos.Contains(SPECIAL_DELIMITER))
            {
                return sumandos.Substring(3);
            }

            return sumandos;
        }

        private IEnumerable<int> RemoveNumbersAbove1000(IEnumerable<int> sumandosList)
        {
            return sumandosList.Where(sumando => sumando <= 1000);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.src
{
    public class CalculatorParser
    {
        public const string SALTO_DE_LINEA = "\n";
        private const string SPECIAL_DELIMITER = "//";
        private const string DEFAULT_DELIMITER = ",";

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
            string delimiter = DEFAULT_DELIMITER;
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

        private IEnumerable<int> GetListOfInts(string sumandos, string delimiter)
        {
            return sumandos.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(sumando => int.Parse(sumando));
        }

        private string ReplaceSaltoDeLineaPorDelimiter(string sumandos, string delimiter)
        {
            return sumandos.Replace(SALTO_DE_LINEA, delimiter);
        }
        
        private string GetDelimiter(string sumandos)
        {
            if (sumandos.Contains(SPECIAL_DELIMITER))
            {
                if (sumandos.Contains("["))
                {
                    int startIndex = sumandos.IndexOf("[") + 1;
                    int length = sumandos.IndexOf("]") - startIndex;
                    return sumandos.Substring(startIndex, length);
                }
                else
                { 
                    return sumandos.Substring(2, 1);
                }
            }

            return DEFAULT_DELIMITER;
        }

        private string RemoveSpecialDelmiter(string sumandos)
        {
            if (sumandos.Contains(SPECIAL_DELIMITER))
            {
                if (sumandos.Contains("]"))
                { 
                    int startIndex = sumandos.IndexOf("]") + 1;
                    return sumandos.Substring(startIndex);
                }
                else
                {
                    return sumandos.Substring(3);
                }
                
            }

            return sumandos;
        }

        private IEnumerable<int> RemoveNumbersAbove1000(IEnumerable<int> sumandosList)
        {
            return sumandosList.Where(sumando => sumando <= 1000);
        }

    }
}
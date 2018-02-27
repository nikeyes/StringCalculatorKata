using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.src
{
   public class CalculatorDelimiter
   {
        private const string DEFAULT_DELIMITER = ",";
        private const string SPECIAL_DELIMITER = "//";
        public const string SALTO_DE_LINEA = "\n";

        public string GetDelimiter(string sumandos)
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

        public string GetNumbersWithoutDelimiters(string numbers)
        {
            string delimiter = GetDelimiter(numbers);
            numbers = ReplaceSaltoDeLineaPorDelimiter(numbers, delimiter);
            numbers = RemoveSpecialDelmiter(numbers);
            return numbers;
        }

        private string ReplaceSaltoDeLineaPorDelimiter(string sumandos, string delimiter)
        {
            return sumandos.Replace(SALTO_DE_LINEA, delimiter);
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
    }
}

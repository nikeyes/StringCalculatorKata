using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.src
{
    public class CalculatorMapper
    {
        public IEnumerable<int> MapTo(string sumandos)
        {
            CalculatorDelimiter calculatorDelimiter = new CalculatorDelimiter();

            string delimiter = calculatorDelimiter.GetDelimiter(sumandos);
            sumandos = calculatorDelimiter.GetNumbersWithoutDelimiters(sumandos);

            IEnumerable<int> sumandosList = sumandos.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(sumando => int.Parse(sumando));

            //TODO [REFACTOR] ¿Esto tiene serntido q ue vaya aquí? Es una 
            //regla de negocio dentro del mapper...
            sumandosList = RemoveNumbersAbove1000(sumandosList);

            return sumandosList;
        }

        private IEnumerable<int> RemoveNumbersAbove1000(IEnumerable<int> sumandosList)
        {
            return sumandosList.Where(sumando => sumando <= 1000);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.src
{
    public class CalculatorValidator
    {
       public void Validate(IEnumerable<int> sumandos)
       {
            int[] negativeSumandos = sumandos.Where(sumando => sumando < 0).ToArray();
            if (negativeSumandos.Any())
            {
                throw new ArgumentException("negatives not allowed: " + string.Join(",", negativeSumandos));
            }
        }
    }
}

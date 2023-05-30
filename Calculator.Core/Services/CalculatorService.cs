using Calculator.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Services
{
    // IAdditionService
    // SubtractionService
    // Then ISimpleCalculator : IAdditionService, SubtractionService 

    public class CalculatorService : ISimpleCalculator
    {
        public int Add(int start, int amount)
        {
            long result = (long)start + (long)amount;
            return Convert.ToInt32(result);
        }

        public int Subtract(int start, int amount)
        {
            // doing this as 2 ints cam exceed int(max), but int will rollback rather than through an exception
            // caues our result to wrong on these edge cases if we don't force it - tests accompy this

            long result = (long)start - (long)amount; 
            return Convert.ToInt32(result);
        }

        // ^ feels horrible but without changing the interface to long its the easiest way
    }
}

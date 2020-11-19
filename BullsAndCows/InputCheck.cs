using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class InputCheck
    {
        public string CheckInput(string input)
        {
            var resultString = input.Trim();
            var splitResult = resultString.Split(' ');
            if (splitResult.Length != 4)
            {
                Console.WriteLine("Input length incorrect.");
                return string.Empty;
            }

            foreach (var element in splitResult)
            {
                if (!int.TryParse(element, out var parsedResult))
                {
                    Console.WriteLine("Input content is not a number.");
                    return string.Empty;
                }

                if (parsedResult > 9 || parsedResult < 0)
                {
                    Console.WriteLine("Input content is not between 0 and 9.");
                    return string.Empty;
                }
            }

            if (splitResult.Distinct().Count() < 4)
            {
                Console.WriteLine("Input repeated number.");
                return string.Empty;
            }

            return resultString;
        }
    }
}

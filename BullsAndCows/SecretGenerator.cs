using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public virtual string GenerateSecret()
        {
            var length = 4;
            var result = string.Empty;
            while (result.Length < length)
            {
                var r = new Random(Guid.NewGuid().GetHashCode()).Next(0, 10).ToString();
                result += result.Contains(r) ? string.Empty : r;
            }

            Console.WriteLine("secret is : " + result + '\n');
            return result;
        }
    }
}
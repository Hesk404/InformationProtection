using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Models
{
    public class Key
    {
        public BigInteger First { get; set; }
        public BigInteger Second { get; set; }

        public override string ToString()
        {
            return $"{{{First.ToString()}; {Second.ToString()}}}";
        }
    }
}

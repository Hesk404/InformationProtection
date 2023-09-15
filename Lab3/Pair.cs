using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Pair
    {
        public Pair(char key, float value)
        {
            Key = key;
            Value = value;
        }

        public char Key { get; set; }
        public float Value { get; set; }
    }
}

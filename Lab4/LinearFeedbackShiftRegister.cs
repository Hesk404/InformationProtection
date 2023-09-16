using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class LinearFeedbackShiftRegister
    {
        private List<int> _condition;
        private int _bitDepth;

        public LinearFeedbackShiftRegister(int bitDepth) 
        {
            _bitDepth = bitDepth;

            _condition = new List<int>();
            Random rnd = new Random();
            for(int i = 0; i < _bitDepth; i++)
            {
                if(i != _bitDepth - 1)
                    _condition.Add(rnd.Next(0, 2));
                else
                    _condition.Add(1);
            }
        }    

        public LinearFeedbackShiftRegister(List<int> condition) 
        {
            _condition = condition.ToList();
            _bitDepth = condition.Count;
        }


        private int Xor(int a, int b)
        {
            if ((a == 0 && b == 1) || (a == 1 && b == 0)) return 1;
            else return 0;
        }

        public int Tick()
        {
            int next = _condition.Last();
            int newbie = Xor(_condition[_condition.Count - 1], _condition[_condition.Count - 2]);

            for(int i = _condition.Count - 2; i >= 0; i--)
            {
                _condition[i + 1] = _condition[i];
            }

            _condition[0] = newbie;

            return next;
        }
    }   
}

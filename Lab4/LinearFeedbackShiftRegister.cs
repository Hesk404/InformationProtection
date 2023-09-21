using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class LinearFeedbackShiftRegister
    {
        private List<int> _condition;
        private int _bitDepth;
        private bool _isDefaultTick;

        public LinearFeedbackShiftRegister(int bitDepth, bool isRandomCondition) 
        {
            _bitDepth = bitDepth;
            _condition = new List<int>();
            _isDefaultTick = false;
            if (isRandomCondition)
            {
                _isDefaultTick = true;
                GenerateInitialCondition();
            }
                
        }    

        public LinearFeedbackShiftRegister(List<int> condition) 
        {
            _condition = condition.ToList();
            _bitDepth = condition.Count;
        }

        private void GenerateInitialCondition()
        {    
            Random rnd = new Random();
            for (int i = 0; i < _bitDepth; i++)
            {
                if (i != _bitDepth - 1)
                    _condition.Add(rnd.Next(0, 2));
                    //_condition.Add(0);
                else
                    _condition.Add(1);
            }
        }

        public void SetCondition(List<int> condition) 
        {
            _condition = condition;
        }

        private int Xor(int a, int b)
        {
            if ((a == 0 && b == 1) || (a == 1 && b == 0)) return 1;
            else return 0;
        }

        public int Tick()
        {
            if(_isDefaultTick)
                return TickDefault();
            else
                return TickFromCondition();
        }

        private int TickDefault()
        {
            int next = _condition.Last();
            int newbie = Xor(_condition[_condition.Count - 1], _condition[_condition.Count - 2]);

            int shift = 1;

            _condition[_condition.Count() - 1] = newbie;

            var tmpList = _condition.GetRange(_condition.Count - shift, shift);
            tmpList.AddRange(_condition.GetRange(0, _condition.Count - shift));
            _condition = tmpList.ToList();

            //_condition[0] = newbie;

            return next;
        }

        private int TickFromCondition()
        {
            int next = _condition.Last();
            int shift = 1;

            if (_condition[0] == 1)
                shift = 2;

            var tmpList = _condition.GetRange(_condition.Count - shift, shift);
            tmpList.AddRange(_condition.GetRange(0, _condition.Count - shift));
            _condition = tmpList.ToList();

            return next;
        }
    }   
}

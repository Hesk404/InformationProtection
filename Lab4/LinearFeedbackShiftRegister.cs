using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class LinearFeedbackShiftRegister
    {
        private List<int> _condition;
        private int _bitDepth;
        private bool _isDefaultTick = true;
        private List<int> _feedback;

        public LinearFeedbackShiftRegister(int bitDepth, bool isRandomCondition, List<int> feedback) 
        {
            _bitDepth = bitDepth;
            _condition = new List<int>();
            _feedback = feedback;
            //_isDefaultTick = false;
            if (isRandomCondition)
            {
                //_isDefaultTick = true;
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

        public void PrintCondition()
        {
            //Console.Write("Condition: ");
            for(int i = 0; i < _condition.Count; i++)
            {
                if(i < _feedback.Count)
                {
                    if (_feedback[i] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(_condition[i]);
                        Console.ResetColor();
                    }
                    else
                        Console.Write(_condition[i]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(_condition[i]);
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }

        public void PrintFeedback()
        {
            foreach (var item in _feedback)
                Console.Write(item);
            Console.WriteLine();
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
            // next = _condition.Last();
            //int newbie = Xor(_condition[_condition.Count - 1], _condition[_condition.Count - 2]);
            //newbie = Xor(_condition[_condition.Count - 3], newbie);
            //int next = newbie;
            int shift = 1;
            int newbie = _condition.Last();

            for(int i = _condition.Count - 2; i >= 0; i--)
            {
                if (_feedback[i] == 1)
                {
                    newbie = Xor(newbie, _condition[i]);
                }
            }



            _condition[_condition.Count() - 1] = newbie;

            var tmpList = _condition.GetRange(_condition.Count - shift, shift);
            tmpList.AddRange(_condition.GetRange(0, _condition.Count - shift));
            _condition = tmpList.ToList();

            //_condition[0] = newbie;

            return newbie;
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

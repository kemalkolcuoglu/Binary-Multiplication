using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryMultiplication
{
    class FirstMethod : Multiplication
    {
        public FirstMethod(int digits, int multiplicand, int multiplier) : base(digits, multiplicand, multiplier)
        {
            Algorithm();
        }

        public override void Algorithm()
        {
            for (int i = 0; i < digits; i++) // Operation will return for digits lenght
            {
                if (multiplier % 2 == 1) // Control unit will check the least bit of multiplier
                    register += multiplicand;
                RecordDatas(); // x.a Recording
                multiplicand = multiplicand << 1; // Shift Left a digit to multiplicand
                multiplier = multiplier >> 1; // Shift Right a digit to multiplier
                RecordDatas(); //x.b Recording
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryMultiplication
{
    class SecondMethod : Multiplication
    {
        public SecondMethod(int digits, int multiplicand, int multiplier) : base(digits, multiplicand, multiplier)
        {
            Algorithm();
        }

        public override void Algorithm()
        {
            long temp; string sTemp;
            temp = multiplicand << digits;
            sTemp = GetIntBinaryStringLeft(temp);
            for (int i = 0; i < digits; i++)
            {
                if (multiplier % 2 == 1)
                {
                    register += temp;
                }
                RecordDatas(); // x.a Recording
                register = register >> 1; // Shift Right to a digit of multiplier
                multiplier = multiplier >> 1; // Shift Right to a digit of multiplier
                RecordDatas(); // x.b Recording
            }
        }
    }
}

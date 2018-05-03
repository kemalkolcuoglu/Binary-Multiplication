using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryMultiplication
{
    class ThirdMethod : Multiplication
    {
        public ThirdMethod(int digits, int multiplicand, int multiplier) : base(digits, multiplicand, multiplier)
        {
            registerstates = new string[digits * 3];
            multiplicandstates = new string[digits * 3];
            multiplierstates = new string[digits * 3];
            Algorithm();
        }

        public override void Algorithm()
        {
            string sTemp; long temp;
            register += multiplier;
            temp = multiplicand << digits;
            sTemp = GetIntBinaryStringLeft(temp);
            for (int i = 0; i < digits; i++)
            {
                RecordDatas(); // x.a Recording
                if (multiplier % 2 == 1)
                {
                    register += temp;
                }
                RecordDatas(); // x.b Recording
                register = register >> 1;
                multiplier = multiplier >> 1;
                RecordDatas(); // x.c Recording
            }
        }
    }
}

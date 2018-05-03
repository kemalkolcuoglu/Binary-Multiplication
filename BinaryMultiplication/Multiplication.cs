using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryMultiplication
{
    public abstract class Multiplication
    {
        protected int digits;
        protected int multiplicand;
        protected int multiplier;
        protected long register;
        public string[] registerstates;
        public string[] multiplicandstates;
        public string[] multiplierstates;
        protected int reg;

        protected Multiplication(int digits, int multiplicand, int multiplier)
        {
            this.digits = digits;
            this.multiplicand = multiplicand;
            this.multiplier = multiplier;
            this.register = 0;
            this.reg = 0; // A counter for arrays
            registerstates = new string[digits*2];
            multiplicandstates = new string[digits * 2];
            multiplierstates = new string[digits * 2];
        }

        public abstract void Algorithm();

        protected string GetIntBinaryStringLeft(long value)
        {
            // Use Convert class and PadLeft.
            return Convert.ToString(value, 2).PadLeft(digits*2, '0');
        }
        protected string GetIntBinaryStringRight(long value)
        {
            // Use Convert class and PadRight.
            return Convert.ToString(value, 2).PadRight(digits, '0');
        }

        protected string GetIntBinaryStringLeftFourDigits(long value)
        {
            return Convert.ToString(value, 2).PadLeft(digits, '0');
        }

        protected void RecordDatas()
        {
            registerstates[reg] = GetIntBinaryStringLeft(register);
            multiplicandstates[reg] = GetIntBinaryStringLeft(multiplicand);
            multiplierstates[reg] = GetIntBinaryStringLeft(multiplier);
            reg++;
        }
    }
}

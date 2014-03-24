using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relogger.Console
{
    public class TargetClass
    {
        public virtual int Gcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            return Gcd(b, a % b);
        }
    }
}

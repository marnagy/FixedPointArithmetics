using System;
using System.Collections.Generic;
using System.Text;

namespace Cuni.Arithmetics.FixedPoint
{
    public abstract class Q
    {
        public abstract int GetLower();
    }
    public class Q24_8 : Q
    {
        public override int GetLower() => 8;
    }
    public class Q16_16 : Q
    {
        public override int GetLower() => 16;
    }
    public class Q8_24 : Q
    {
        public override int GetLower() => 24;
    }
}

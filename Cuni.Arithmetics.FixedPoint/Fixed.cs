using System;
using System.Collections.Generic;
using System.Text;

namespace Cuni.Arithmetics.FixedPoint
{
    public struct Fixed<T> where T: Q, new()
    {
        public readonly int Value;
        public static int LowerBits;
        static Fixed()
        {
            LowerBits = new T().GetLower();
        }
        public Fixed(int value) : this()
        {
            this.Value = value << LowerBits;
        }
        internal Fixed(long value) : this()
        {
            this.Value = (int)value;
        }


        public Fixed<T> Add(Fixed<T> f) =>
            new Fixed<T>((long)this.Value + f.Value);
        public Fixed<T> Subtract(Fixed<T> f) =>
            new Fixed<T>((long)this.Value - f.Value);
        public Fixed<T> Multiply(Fixed<T> f) =>
            new Fixed<T>(((long)this.Value * f.Value) >> LowerBits);
        public Fixed<T> Divide(Fixed<T> f) =>
            new Fixed<T>(((long)this.Value << LowerBits) / f.Value);
        public override string ToString()
        {
            return (Value / powerOfTwo(LowerBits)).ToString();
        }
        private double powerOfTwo(int power)
        {
            long res = 1;
            for (int i = 0; i < power; i++)
            {
                res *= 2;
            }
            return res;
        }
    }
}

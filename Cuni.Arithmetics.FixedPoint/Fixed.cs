using System;
using System.Collections.Generic;
using System.Text;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("FixedPointTests")]

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
            //Console.WriteLine("Int32 .ctor");
            this.Value = value << LowerBits;
        }
        internal Fixed(long value) : this()
        {
            //Console.WriteLine("Int64 .cctor");
            this.Value = (int)value;
        }


        public Fixed<T> Add(Fixed<T> f) =>
            new Fixed<T>((long)this.Value + f.Value);
        public Fixed<T> Subtract(Fixed<T> f) =>
            new Fixed<T>((long)this.Value - f.Value);
        public Fixed<T> Multiply(Fixed<T> f) =>
            new Fixed<T>(((long)this.Value * f.Value) >> LowerBits);
        public Fixed<T> Divide(Fixed<T> f) =>
            new Fixed<T>(((long)this.Value << LowerBits ) / f.Value);
        public override string ToString()
        {
            return "" + (Value / powerOfTwo((uint)LowerBits));
        }
        private double powerOfTwo(uint power)
        {
            int res = 1;
            for (int i = 0; i < power; i++)
            {
                res *= 2;
            }
            return res;
        }
    }
}

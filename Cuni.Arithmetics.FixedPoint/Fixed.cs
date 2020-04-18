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
            this.Value = value << LowerBits;
        }
        internal Fixed(int value, bool change = true)
        {
            this.Value = value;
        }
        internal Fixed(long value) : this()
        {
            this.Value = (int)value;
        }

        // conversions
        public static explicit operator Fixed<T>(int d) => new Fixed<T>(d);

        // operators
        public static Fixed<T> operator +(Fixed<T> a, Fixed<T> b)
        {
            return a.AddWithoutLong(b);
        }
        public static Fixed<T> operator -(Fixed<T> a, Fixed<T> b)
        {
            return a.SubtractWithoutLong(b);
        }
        public static Fixed<T> operator *(Fixed<T> a, Fixed<T> b)
        {
            return a.Multiply(b);
        }
        public static Fixed<T> operator /(Fixed<T> a, Fixed<T> b)
        {
            return a.Divide(b);
        }
        public static Fixed<T> operator /(int a, Fixed<T> b)
        {
            return new Fixed<T>(a).Divide(b);
        }
        public static Fixed<T> operator /(Fixed<T> a, int b)
        {
            return a.Divide(new Fixed<T>(b));
        }

        // comparators
        public static bool operator ==(Fixed<T> a, int b)
        {
            return a.Value == b << LowerBits;
        }
        public static bool operator !=(Fixed<T> a, int b)
        {
            return a.Value != b << LowerBits;
        }
        public static bool operator ==(Fixed<T> a, Fixed<T> b)
        {
            return a.Value == b.Value;
        }
        public static bool operator !=(Fixed<T> a, Fixed<T> b)
        {
            return a.Value != b.Value;
        }

        // methods
        public Fixed<T> Add(Fixed<T> f) =>
            new Fixed<T>((long)this.Value + f.Value);
        public Fixed<T> AddWithoutLong(Fixed<T> f) =>
            new Fixed<T>(this.Value + f.Value, change: false);
        public Fixed<T> Subtract(Fixed<T> f) =>
            new Fixed<T>((long)this.Value - f.Value);
        public Fixed<T> SubtractWithoutLong(Fixed<T> f) =>
            new Fixed<T>(this.Value - f.Value, change: false);
        public Fixed<T> Multiply(Fixed<T> f) =>
            new Fixed<T>(((long)this.Value * f.Value) >> LowerBits);
        public Fixed<T> MultiplyWithoutLong(Fixed<T> f) =>
            new Fixed<T>((int)(((long)this.Value * f.Value) >> LowerBits), change: false);
        public Fixed<T> Divide(Fixed<T> f) =>
            new Fixed<T>(((long)this.Value << LowerBits) / f.Value);
        public Fixed<T> DivideWithoutLong(Fixed<T> f) =>
            new Fixed<T>((int)(((long)this.Value << LowerBits) / f.Value), change: false);
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

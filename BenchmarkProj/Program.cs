using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Cuni.Arithmetics.FixedPoint;

namespace BenchmarkProj
{
	[MemoryDiagnoser]
	public class Program
	{
		public static Fixed<Q24_8> a;
		public static Fixed<Q24_8> b;
		static Program()
		{
			a = new Fixed<Q24_8>(10);
			b = new Fixed<Q24_8>(15);
		}
		[Benchmark]
		public void AddWithLong()
		{
			var res = a.Add(b);
		}
		[Benchmark]
		public void AddWithoutLong()
		{
			var res = a.AddWithoutLong(b);
		}
		[Benchmark]
		public void SubtractWithLong()
		{
			var res = a.Subtract(b);
		}
		[Benchmark]
		public void SubtractWithoutLong()
		{
			var res = a.SubtractWithoutLong(b);
		}
		[Benchmark]
		public void MultiplyWithLong()
		{
			var res = a.Multiply(b);
		}
		[Benchmark]
		public void MultiplyWithoutLong()
		{
			var res = a.MultiplyWithoutLong(b);
		}
		[Benchmark]
		public void DivideWithLong()
		{
			var res = a.Divide(b);
		}
		[Benchmark]
		public void DivideWithoutLong()
		{
			var res = a.DivideWithoutLong(b);
		}
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<Program>();
		}
	}
}
